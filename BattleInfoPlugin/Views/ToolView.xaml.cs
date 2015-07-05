using System;
using System.Windows;
using Grabacr07.KanColleViewer.Views;
using MetroRadiance.Controls;

namespace BattleInfoPlugin.Views
{
    /// <summary>
    /// ToolView.xaml の相互作用ロジック
    /// </summary>
	public partial class ToolView : MetroWindow
    {
        public ToolView()
        {
			this.InitializeComponent();
			this.InitializeComponent();
			this.Title = "전투정보";
			WeakEventManager<MainWindow, EventArgs>.AddHandler(
				MainWindow.Current,
				"Closed",
				(_, __) => this.Close());
        }
    }
}
