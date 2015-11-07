using System;
using System.Reactive.Linq;
using System.Windows;
using BattleInfoPlugin.Properties;
using Grabacr07.KanColleViewer;
using Grabacr07.KanColleViewer.Composition;
using Grabacr07.KanColleWrapper;
using Livet;
using MetroRadiance;
using BattleInfoPlugin.Models.Raw;

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
				.Subscribe(_ => this.NotifyEndOfBattle());

			proxy.api_req_sortie_battleresult
				.Subscribe(_ => this.NotifyEndOfBattle());

			proxy.api_req_map_start
				.Subscribe(_ => this.IsCriticalCheck());

			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_req_map/next")
				.Subscribe(x => this.IsCriticalCheck());

			monitor.ConfirmPursuit += () => this.Notify(NotificationType.ConfirmPursuit, "추격확인", "야전을 실시할지 선택하시기 바랍니다");
		}
		private bool IsCriticalCheck()
		{
			if (!CriticalEnabled) return false;
			if (Settings.Default.FirstIsCritical || Settings.Default.SecondIsCritical)
			{
				this.Notify(
									NotificationType.CriticalState,
									"대파알림",
									"대파된 칸무스가 있습니다!",
									true);
				return true;
			}
			else return false;
		}
		private void NotifyEndOfBattle()
		{
			if (!IsCriticalCheck() || !CriticalEnabled) this.Notify(NotificationType.BattleEnd, "전투종료", "전투가 종료되었습니다");
		}

		private void Notify(string type, string title, string message, bool IsCritical = false)
		{
			if (NotificationType.ConfirmPursuit == type && !IsPursuit) return;
			var isActive = DispatcherHelper.UIDispatcher.Invoke(() => Application.Current.MainWindow.IsActive);
			if (IsCritical && CriticalEnabled)
			{
				ThemeService.Current.ChangeAccent(Accent.Red);
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
