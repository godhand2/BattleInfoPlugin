using System;
using System.ComponentModel.Composition;
using BattleInfoPlugin.ViewModels;
using BattleInfoPlugin.Views;
using Grabacr07.KanColleViewer.Composition;
using Grabacr07.KanColleWrapper;
using Grabacr07.KanColleWrapper.Models.Raw;

namespace BattleInfoPlugin
{
    [Export(typeof(IPlugin))]
    [Export(typeof(ITool))]
    [Export(typeof(IRequestNotify))]
	[ExportMetadata("Guid", "3CFE46C3-E3AF-4737-BFB7-CAD1865C10CA")]
    [ExportMetadata("Title", "BattleInfo")]
	[ExportMetadata("Description", "전투정보를 표시합니다. 대파알림 및 랭크예측등을 제공합니다")]
	[ExportMetadata("Version", "1.7.0")]
    [ExportMetadata("Author", "@veigr")]
    public class Plugin : IPlugin, ITool, IRequestNotify
    {
        private readonly ToolViewModel vm;
        internal static KcsResourceWriter ResourceWriter { get; private set; }
        internal static SortieDataListener SortieListener { get; private set; }
        internal static kcsapi_start2 RawStart2 { get; private set; }

        public Plugin()
        {
            this.vm = new ToolViewModel(this);
        }

        public void Initialize()
        {
            KanColleClient.Current.Proxy.api_start2.TryParse<kcsapi_start2>().Subscribe(x =>
            {
                RawStart2 = x.Data;
                Models.Repositories.Master.Current.Update(x.Data);
            });
            ResourceWriter = new KcsResourceWriter();
            SortieListener = new SortieDataListener();
        }

        public string Name => "BattleInfo";

        // タブ表示するたびに new されてしまうが、今のところ new しないとマルチウィンドウで正常に表示されない
        public object View => new ToolView {DataContext = this.vm};

        public event EventHandler<NotifyEventArgs> NotifyRequested;

        public void InvokeNotifyRequested(NotifyEventArgs e) => this.NotifyRequested?.Invoke(this, e);
    }
}
