using System;
using System.Reactive.Linq;
using System.Windows;
using System.Threading.Tasks;
using BattleInfoPlugin.Properties;
using Grabacr07.KanColleViewer;
using Grabacr07.KanColleViewer.Composition;
using Grabacr07.KanColleWrapper;
using Livet;
using BattleInfoPlugin.Models.Raw;
using MetroRadiance.UI;

namespace BattleInfoPlugin.Models.Notifiers
{
	public class BattleEndNotifier : NotificationObject
	{
		private static readonly Settings settings = Settings.Default;

		private static readonly BrowserImageMonitor monitor = new BrowserImageMonitor();

		private readonly Plugin plugin;

		#region IsEnabled変更通知プロパティ
				public bool IsEnabled
		{
			get { return settings.IsEnabledBattleEndNotify; }
			set
			{
				if (settings.IsEnabledBattleEndNotify == value)
					return;
				settings.IsEnabledBattleEndNotify = value;
				settings.Save();
				this.RaisePropertyChanged();
			}
		}
		#endregion

		#region IsPursuit
		public bool IsPursuit
		{
			get { return settings.IsPursuitEnabled; }
			set
			{
				if (settings.IsPursuitEnabled == value)
					return;
				settings.IsPursuitEnabled = value;
				settings.Save();
				this.RaisePropertyChanged();
			}
		}
		#endregion

		#region CriticalEnabled
		public bool CriticalEnabled
		{
			get { return settings.CriticalEnabled; }
			set
			{
				if (settings.CriticalEnabled == value)
					return;
				settings.CriticalEnabled = value;
				settings.Save();
				this.RaisePropertyChanged();
			}
		}
		#endregion

		#region IsNotifyOnlyWhenInactive変更通知プロパティ
		public bool IsNotifyOnlyWhenInactive
		{
			get { return settings.IsBattleEndNotifyOnlyWhenInactive; }
			set
			{
				if (settings.IsBattleEndNotifyOnlyWhenInactive == value)
					return;
				settings.IsBattleEndNotifyOnlyWhenInactive = value;
				settings.Save();
				this.RaisePropertyChanged();
			}
		}
		#endregion

		public BattleEndNotifier(Plugin plugin)
		{
			this.plugin = plugin;

			settings.Reload();

			var proxy = KanColleClient.Current.Proxy;

			proxy.api_req_combined_battle_battleresult
				.Subscribe(_ => this.NotifyEndOfBattle());

			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_req_practice/battle_result")
				.Subscribe(_ => this.NotifyEndOfBattle(true));

			proxy.api_req_sortie_battleresult
				.Subscribe(_ => this.NotifyEndOfBattle());

			proxy.api_req_map_start
				.Subscribe(async _ => await this.IsCriticalCheck());

			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_req_map/next")
				.Subscribe(async x => await this.IsCriticalCheck());

			monitor.ConfirmPursuit += () => this.Notify(NotificationType.ConfirmPursuit, "追撃確認", "夜戦を行うかどうか選択してください。");
		}
		private async Task<bool> IsCriticalCheck()
		{
			await Task.Delay(100);

			if (!CriticalEnabled) return false;
			if (Settings.Default.FirstIsCritical || Settings.Default.SecondIsCritical)
			{
				this.Notify(
					NotificationType.CriticalState,
					"大破警告",
					"大破している艦があります!",
					true
				);
				return true;
			}
			else return false;
		}
		private async void NotifyEndOfBattle(bool isPractice = false)
		{
			if (isPractice || !(await IsCriticalCheck()) || !CriticalEnabled)
				this.Notify(NotificationType.BattleEnd, "戦闘終了", "戦闘が終了しました。");
		}

		private void Notify(string type, string title, string message, bool IsCritical = false)
		{
			if (NotificationType.ConfirmPursuit == type && !IsPursuit) return;
			var isActive = DispatcherHelper.UIDispatcher.Invoke(() => System.Windows.Application.Current.MainWindow.IsActive);
			if (IsCritical && CriticalEnabled)
			{
				if(settings.EnableColorChange)
				{
                    //to resolve Accent.Red and ThemeCritialRed build error, but lost the ability to change color when critical state ships exists
					//ThemeService.Current.ChangeAccent(Accent.Red);
					//ThemeService.Current.ChangeTheme(Theme.CritialRed);
				}
				this.plugin.InvokeNotifyRequested(new NotifyEventArgs(type, title, message)
				{
					Activated = () =>
					{
						DispatcherHelper.UIDispatcher.Invoke(() =>
						{
							var window = System.Windows.Application.Current.MainWindow;
							if (window.WindowState == WindowState.Minimized)
								window.WindowState = WindowState.Normal;
							window.Activate();
						});
					},
				});
			}
			else if (this.IsEnabled && (!isActive || !this.IsNotifyOnlyWhenInactive))
				this.plugin.InvokeNotifyRequested(new NotifyEventArgs(type, title, message)
				{
					Activated = () =>
					{
						DispatcherHelper.UIDispatcher.Invoke(() =>
						{
							var window = System.Windows.Application.Current.MainWindow;
							if (window.WindowState == WindowState.Minimized)
								window.WindowState = WindowState.Normal;
							window.Activate();
						});
					},
				});
		}
	}
}
