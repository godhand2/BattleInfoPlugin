using System;
using System.Collections.Generic;
using System.Linq;
using Grabacr07.KanColleWrapper.Models;
using Livet;

namespace BattleInfoPlugin.Models
{
	public class ShipSlotData : NotificationObject
	{
		public SlotItemInfo Source { get; private set; }

		public bool Equipped => this.Source != null;

		#region Maximum 변경통지 프로퍼티
		private int _Maximum { get; set; }
		public int Maximum
		{
			get { return this._Maximum; }
			private set
			{
				if (this._Maximum != value)
				{
					this._Maximum = value;
					this.RaisePropertyChanged();
					this.RaisePropertyChanged(nameof(this.Lost));
				}
			}
		}
		#endregion

		#region Current 변경통지 프로퍼티
		private int _Current { get; set; }
		public int Current
		{
			get { return this._Current; }
			private set
			{
				if (this._Current != value)
				{
					this._Current = value;
					this.RaisePropertyChanged();
					this.RaisePropertyChanged(nameof(this.Lost));
				}
			}
		}
		#endregion

		public int Lost => this.Maximum - this.Current;

		#region Level 변경통지 프로퍼티
		private int _Level { get; set; }
		public int Level
		{
			get { return this._Level; }
			private set
			{
				if (this._Level != value)
				{
					this._Level = value;
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion

		#region Proficiency 변경통지 프로퍼티
		private int _Proficiency { get; set; }
		public int Proficiency
		{
			get { return this._Proficiency; }
			private set
			{
				if (this._Proficiency != value)
				{
					this._Proficiency = value;
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion

		public int Firepower => this.Source?.Firepower ?? 0;
		public int Torpedo => this.Source?.Torpedo ?? 0;
		public int AA => this.Source?.AA ?? 0;
		public int Armer => this.Source?.Armer ?? 0;
		public int Bomb => this.Source?.Bomb ?? 0;
		public int ASW => this.Source?.ASW ?? 0;
		public int Hit => this.Source?.Hit ?? 0;
		public int Evade => this.Source?.Evade ?? 0;
		public int LOS => this.Source?.ViewRange ?? 0;

		public Type2 Type2 => (Type2)this.Source?.RawData.api_type[1];

		public string ToolTip => this.Source?.ToolTipData;

		public ShipSlotData(SlotItemInfo item, int maximum = -1, int current = -1, int level = 0, int proficiency = 0)
		{
			this.Source = item;
			this.Maximum = maximum;
			this.Current = current;
			this.Level = level;
			this.Proficiency = proficiency;
		}

		public ShipSlotData(ShipSlot slot) : this(slot.Item?.Info, slot.Maximum, slot.Current, slot.Item?.Level ?? 0, slot.Item?.Proficiency ?? 0)
		{
		}
	}
}
