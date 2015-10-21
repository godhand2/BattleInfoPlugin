using System;
using System.Reactive.Linq;
using System.Windows;
using BattleInfoPlugin.Properties;
using Grabacr07.KanColleViewer;
using Grabacr07.KanColleViewer.Composition;
using Grabacr07.KanColleWrapper;
using Livet;

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

            monitor.ConfirmPursuit += () => this.Notify(NotificationType.ConfirmPursuit, "추격확인", "야전을 실시할지 선택하시기 바랍니다");
        }

        private void NotifyEndOfBattle()
        {
            this.Notify(NotificationType.BattleEnd, "전투종료", "전투가 종료되었습니다");
        }

        private void Notify(string type, string title, string message)
        {
            var isActive = DispatcherHelper.UIDispatcher.Invoke(() => Application.Current.MainWindow.IsActive);
            if (this.IsEnabled && (!isActive || !this.IsNotifyOnlyWhenInactive))
                this.plugin.InvokeNotifyRequested(new NotifyEventArgs(type, title, message)
                {
                    Activated = () =>
                    {
                        DispatcherHelper.UIDispatcher.Invoke(() =>
                        {
                            var window = Application.Current.MainWindow;
                            if (window.WindowState == WindowState.Minimized)
                                window.WindowState = WindowState.Normal;
                            window.Activate();
                        });
                    },
                });
        }
    }
}
