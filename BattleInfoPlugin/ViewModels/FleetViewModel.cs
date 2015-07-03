using System;
using System.Linq;
using BattleInfoPlugin.Models;
using Livet;
using Livet.EventListeners;
using Grabacr07.KanColleWrapper;

namespace BattleInfoPlugin.ViewModels
{
	public class FleetViewModel : ViewModel
	{

		#region Name変更通知プロパティ
		private string _Name;

		public string Name
		{
			get
			{ return this._Name; }
			set
			{
				if (this._Name == value)
					return;
				this._Name = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion


		#region FleetGauge変更通知プロパティ

		public string FleetGauge
		{
			get
			{
				return (this.Fleet != null && this.Fleet.AttackGauge != string.Empty)
				  ? this.Fleet.AttackGauge
				  : string.Empty;
			}
		}
		#endregion


		#region Fleet変更通知プロパティ
		private FleetData _Fleet;

		public FleetData Fleet
		{
			get
			{ return this._Fleet; }
			set
			{
				if (this._Fleet == value)
					return;
				this._Fleet = value;
				this.RaisePropertyChanged();

				this.RaisePropertyChanged(() => this.FleetFormation);
				this.RaisePropertyChanged(() => this.IsVisible);
				this.RaisePropertyChanged(() => this.FleetGauge);

				this.Name = !string.IsNullOrWhiteSpace(value.Name)
					? value.Name
					: this.defaultName;
			}
		}
		#endregion


		#region IsVisible変更通知プロパティ

		public bool IsVisible
		{
			get
			{ return this.Fleet != null && this.Fleet.Ships.Count() != 0; }
		}
		#endregion


		#region FleetFormation変更通知プロパティ

		public string FleetFormation
		{
			get
			{
				return (this.Fleet != null && this.Fleet.Formation != Formation.없음)
					  ? this.Fleet.Formation.ToString()
					  : "";
			}
		}

		#endregion

		public FleetViewModel()
			: this("")
		{
		}

		public FleetViewModel(string name, FleetData fleet = null)
		{
			this.Name = KanColleClient.Current.Translations.GetTranslation(name, Grabacr07.KanColleWrapper.Models.TranslationType.OperationSortie, true);
			this.Fleet = fleet;
			this.defaultName = name;
		}

		private readonly string defaultName;
	}
}
