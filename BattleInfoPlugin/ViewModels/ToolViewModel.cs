using System;
using System.Linq;
using settings=BattleInfoPlugin.Properties.Settings;
using BattleInfoPlugin.Models;
using BattleInfoPlugin.Models.Notifiers;
using Livet;
using Livet.EventListeners;
using Livet.Messaging;

namespace BattleInfoPlugin.ViewModels
{
	public class ToolViewModel : ViewModel
	{
		private readonly BattleEndNotifier notifier;

		private BattleData BattleData { get; } = new BattleData();

		public string BattleName
			=> this.BattleData?.Name ?? "";

		public string UpdatedTime
			=> this.BattleData != null && this.BattleData.UpdatedTime != default(DateTimeOffset)
				? this.BattleData.UpdatedTime.ToString("yyyy/MM/dd HH:mm:ss")
				: "No Data";

		public string BattleSituation
			=> this.BattleData != null && this.BattleData.BattleSituation != Models.BattleSituation.없음
				? this.BattleData.BattleSituation.ToString()
				: "";

		public string FriendAirSupremacy
			=> this.BattleData != null && this.BattleData.FriendAirSupremacy != AirSupremacy.항공전없음
				? this.BattleData.FriendAirSupremacy.ToString()
				: "";

		public string Cell
			=> MapAreaData.MapAreaTable.SingleOrDefault(x => x.Key == this.BattleData?.Cell).Value ?? this.BattleData?.Cell;
		public string CellEvent
			=> this.BattleData?.CellEvent.ToString();
		public string RankResult
			=> this.BattleData.RankResult.ToString();
		public string DropShipName
			=> this.BattleData?.DropShipName;

		public AirCombatResult[] AirCombatResults
			=> this.BattleData?.AirCombatResults ?? new AirCombatResult[0];
		

		#region FirstFleet変更通知プロパティ
		private FleetViewModel _FirstFleet;
		public FleetViewModel FirstFleet
		{
			get { return this._FirstFleet; }
			set
			{
				if (this._FirstFleet != value)
				{
					this._FirstFleet = value;
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion

		#region SecondFleet変更通知プロパティ
		private FleetViewModel _SecondFleet;
		public FleetViewModel SecondFleet
		{
			get { return this._SecondFleet; }
			set
			{
				if (this._SecondFleet != value)
				{
					this._SecondFleet = value;
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion

		#region Enemies変更通知プロパティ
		private FleetViewModel _Enemies;
		public FleetViewModel Enemies
		{
			get { return this._Enemies; }
			set
			{
				if (this._Enemies != value)
				{
					this._Enemies = value;
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion


		#region IsCriticalNotiEnabled
		// ここ以外で変更しないのでModel変更通知は受け取らない雑対応
		public bool IsCriticalNotiEnabled
		{
			get { return this.notifier.CriticalEnabled; }
			set
			{
				if (this.notifier.CriticalEnabled != value)
				{
					this.notifier.CriticalEnabled = value;
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion

		#region IsNotifierEnabled変更通知プロパティ
		// ここ以外で変更しないのでModel変更通知は受け取らない雑対応
		public bool IsNotifierEnabled
		{
			get { return this.notifier.IsEnabled; }
			set
			{
				if (this.notifier.IsEnabled != value)
				{
					this.notifier.IsEnabled = value;
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion

		#region IsPursuitEnabled変更通知プロパティ
		public bool IsPursuitEnabled
		{
			get { return this.notifier.IsEnabled; }
			set
			{
				if (this.notifier.IsEnabled != value)
				{
					this.notifier.IsEnabled = value;
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion

		#region EnableColorChange
		public bool EnableColorChange
		{
			get { return settings.Default.EnableColorChange; }
			set
			{
				if (settings.Default.EnableColorChange != value)
				{
					settings.Default.EnableColorChange = value;
					settings.Default.Save();
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion

		#region DetailKouku
		public bool DetailKouku
		{
			get { return settings.Default.DetailKouku; }
			set
			{
				if (settings.Default.DetailKouku != value)
				{
					settings.Default.DetailKouku = value;
					settings.Default.Save();
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion

		#region AutoSelectTab
		public bool AutoSelectTab
		{
			get { return settings.Default.AutoSelectTab; }
			set
			{
				if (settings.Default.AutoSelectTab != value)
				{
					settings.Default.AutoSelectTab = value;
					settings.Default.Save();
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion

		#region IsNotifyOnlyWhenInactive変更通知プロパティ
		// ここ以外で変更しないのでModel変更通知は受け取らない雑対応
		public bool IsNotifyOnlyWhenInactive
		{
			get { return this.notifier.IsNotifyOnlyWhenInactive; }
			set
			{
				if (this.notifier.IsNotifyOnlyWhenInactive != value)
				{
					this.notifier.IsNotifyOnlyWhenInactive = value;
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion


		public ToolViewModel(Plugin plugin)
		{
			this.notifier = new BattleEndNotifier(plugin);
			this._FirstFleet = new FleetViewModel("기본함대");
			this._SecondFleet = new FleetViewModel("호위함대");
			this._Enemies = new FleetViewModel("적함대");

			this.CompositeDisposable.Add(new PropertyChangedEventListener(this.BattleData)
			{
				{
					nameof(this.BattleData.CellEvent),
					(_, __) => this.RaisePropertyChanged(() => this.CellEvent)
				},
				{
					nameof(this.BattleData.Cell),
					(_, __) => this.RaisePropertyChanged(nameof(this.Cell))
				},
				{
					nameof(this.BattleData.Name),
					(_, __) => this.RaisePropertyChanged(nameof(this.BattleName))
				},
				{
					nameof(this.BattleData.UpdatedTime),
					(_, __) => this.RaisePropertyChanged(() => this.UpdatedTime)
				},
				{
					nameof(this.BattleData.BattleSituation),
					(_, __) => this.RaisePropertyChanged(() => this.BattleSituation)
				},
				{
					nameof(this.BattleData.FriendAirSupremacy),
					(_, __) => this.RaisePropertyChanged(() => this.FriendAirSupremacy)
				},
				{
					nameof(this.BattleData.AirCombatResults),
					(_, __) =>
					{
						this.RaisePropertyChanged(() => this.AirCombatResults);
						this.FirstFleet.AirCombatResults = this.AirCombatResults.Select(x => new AirCombatResultViewModel(x, FleetType.First)).ToArray();
						this.SecondFleet.AirCombatResults = this.AirCombatResults.Select(x => new AirCombatResultViewModel(x, FleetType.Second)).ToArray();
						this.Enemies.AirCombatResults = this.AirCombatResults.Select(x => new AirCombatResultViewModel(x, FleetType.Enemy)).ToArray();
					}
				},
				{
					nameof(this.BattleData.DropShipName),
					(_, __) => this.RaisePropertyChanged(() => this.DropShipName)
				},
				{
					nameof(this.BattleData.FirstFleet),
					(_, __) => this.FirstFleet.Fleet = this.BattleData.FirstFleet
				},
				{
					nameof(this.BattleData.SecondFleet),
					(_, __) => this.SecondFleet.Fleet = this.BattleData.SecondFleet
				},
				{
					nameof(this.BattleData.Enemies),
					(_, __) => this.Enemies.Fleet = this.BattleData.Enemies
				},
				{
					nameof(this.BattleData.RankResult),
					(_, __) => this.RaisePropertyChanged(nameof(this.RankResult))
				},
			});
		}

		public void OpenEnemyWindow()
		{
			var message = new TransitionMessage("Show/EnemyWindow")
			{
				TransitionViewModel = new EnemyWindowViewModel()
			};
			this.Messenger.RaiseAsync(message);
		}
	}
}
