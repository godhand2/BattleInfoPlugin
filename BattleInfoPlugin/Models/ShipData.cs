using System;
using System.Collections.Generic;
using System.Linq;
using Grabacr07.KanColleWrapper.Models;
using Livet;

namespace BattleInfoPlugin.Models
{
	public class ShipData : NotificationObject
	{
		#region Id変更通知プロパティ
		private int _Id;
		public int Id
		{
			get { return this._Id; }
			set
			{
				if (this._Id != value)
				{
					this._Id = value;
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion

		#region MasterId変更通知プロパティ
		private int _MasterId;
		public int MasterId
		{
			get { return this._MasterId; }
			set
			{
				if (this._MasterId != value)
				{
					this._MasterId = value;
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion

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

		#region AdditionalName変更通知プロパティ
		private string _AdditionalName;

		public string AdditionalName
		{
			get
			{ return this._AdditionalName; }
			set
			{ 
				if (this._AdditionalName == value)
					return;
				this._AdditionalName = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion

		#region ShipSpeed変更通知プロパティ
		private ShipSpeed _ShipSpeed;
		public ShipSpeed ShipSpeed
		{
			get { return this._ShipSpeed; }
			set
			{
				if (this._ShipSpeed != value)
				{
					this._ShipSpeed = value;
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion

		#region ShipType変更通知プロパティ
		private int _ShipType;
		public int ShipType
		{
			get { return this._ShipType; }
			set
			{
				if (this._ShipType != value)
				{
					this._ShipType = value;
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion

		#region TypeName変更通知プロパティ
		private string _TypeName;

		public string TypeName
		{
			get
			{ return this._TypeName; }
			set
			{ 
				if (this._TypeName == value)
					return;
				this._TypeName = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion

		#region Level変更通知プロパティ
		private int _Level;
		public int Level
		{
			get { return this._Level; }
			set
			{
				if (this._Level == value)
					return;
				this._Level = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion

		#region Situation変更通知プロパティ
		private ShipSituation _Situation;

		public ShipSituation Situation
		{
			get
			{ return _Situation; }
			set
			{ 
				if (_Situation == value)
					return;
				_Situation = value;
				RaisePropertyChanged();
			}
		}
		#endregion

		#region MaxHP変更通知プロパティ
		private int _MaxHP;
		public int MaxHP
		{
			get { return this._MaxHP; }
			set
			{
				if (this._MaxHP == value)
					return;
				this._MaxHP = value;
				this.RaisePropertyChanged();
				this.RaisePropertyChanged(() => this.HP);
			}
		}
		#endregion

		#region NowHP変更通知プロパティ
		private int _NowHP;
		public int NowHP
		{
			get { return this._NowHP; }
			set
			{
				if (this._NowHP == value)
					return;
				this._NowHP = value;
				this.RaisePropertyChanged();
				this.RaisePropertyChanged(() => this.HP);
			}
		}
		#endregion

		#region BeforeNowHP変更通知プロパティ
		private int _BeforeNowHP;
		public int BeforeNowHP
		{
			get { return this._BeforeNowHP; }
			set
			{
				if (this._BeforeNowHP == value)
					return;
				this._BeforeNowHP = value;
			}
		}
		#endregion

		#region Firepower 変更通知プロパティ

		private int _Firepower;

		/// <summary>
		/// 火力ステータス値を取得します。
		/// </summary>
		public int Firepower
		{
			get { return this._Firepower; }
			set
			{
				this._Firepower = value;
				this.RaisePropertyChanged();

			}
		}

		#endregion

		#region Torpedo 変更通知プロパティ

		private int _Torpedo;

		/// <summary>
		/// 雷装ステータス値を取得します。
		/// </summary>
		public int Torpedo
		{
			get { return this._Torpedo; }
			set
			{
				this._Torpedo = value;
				this.RaisePropertyChanged();

			}
		}

		#endregion

		#region AA 変更通知プロパティ

		private int _AA;

		/// <summary>
		/// 対空ステータス値を取得します。
		/// </summary>
		public int AA
		{
			get { return this._AA; }
			set
			{
				this._AA = value;
				this.RaisePropertyChanged();
			}

		}

		#endregion

		#region Armer 変更通知プロパティ

		private int _Armer;

		/// <summary>
		/// 装甲ステータス値を取得します。
		/// </summary>
		public int Armer
		{
			get { return this._Armer; }
			set
			{
				this._Armer = value;
				this.RaisePropertyChanged();

			}
		}

		#endregion

		#region Luck 変更通知プロパティ

		private int _Luck;

		/// <summary>
		/// 運のステータス値を取得します。
		/// </summary>
		public int Luck
		{
			get { return this._Luck; }
			set
			{
				this._Luck = value;
				this.RaisePropertyChanged();
			}
		}

		#endregion

		#region ASW 変更通知プロパティ

		private int _ASW;

		/// <summary>
		/// 対潜のステータス値を取得します。
		/// </summary>
		public int ASW
		{
			get { return this._ASW; }
			set
			{
				this._ASW = value;
				this.RaisePropertyChanged();
			}
		}

		#endregion

		#region Evade 変更通知プロパティ

		private int _Evade;

		/// <summary>
		/// 回避のステータス値を取得します。
		/// </summary>
		public int Evade
		{
			get { return this._Evade; }
			set
			{
				this._Evade = value;
				this.RaisePropertyChanged();
			}
		}

		#endregion

		#region Slots変更通知プロパティ
		private IEnumerable<ShipSlotData> _Slots;

		public IEnumerable<ShipSlotData> Slots
		{
			get
			{ return this._Slots; }
			set
			{ 
				if (this._Slots == value)
					return;
				this._Slots = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion

		#region ExSlot変更通知プロパティ
		private ShipSlotData _ExSlot;

		public ShipSlotData ExSlot
		{
			get
			{ return this._ExSlot; }
			set
			{
				if (this._ExSlot == value)
					return;
				this._ExSlot = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion

		#region IsUsedDamecon 変更通知プロパティ

		private bool _IsUsedDamecon;

		/// <summary>
		/// 運のステータス値を取得します。
		/// </summary>
		public bool IsUsedDamecon
		{
			get { return this._IsUsedDamecon; }
			set
			{
				this._IsUsedDamecon = value;
				this.RaisePropertyChanged();
			}
		}

		#endregion

		#region Condition変更通知プロパティ
		private int _Condition;
		public int Condition
		{
			get { return this._Condition; }
			set
			{
				if (this._Condition == value)
					return;
				this._Condition = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion

		#region ConditionType変更通知プロパティ
		private ConditionType _ConditionType;
		public ConditionType ConditionType
		{
			get { return this._ConditionType; }
			set
			{
				if (this._ConditionType == value)
					return;
				this._ConditionType = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion

		#region IsMvp 変更通知プロパティ
		private bool _IsMvp;
		public bool IsMvp
		{
			get { return this._IsMvp; }
			set
			{
				if (this._IsMvp != value)
				{
					this._IsMvp = value;
					this.RaisePropertyChanged();
				}
			}
		}
		#endregion

		public int SlotsFirepower => this.Slots.Sum(x => x.Firepower) + (this.ExSlot?.Firepower ?? 0);
		public int SlotsTorpedo => this.Slots.Sum(x => x.Torpedo) + (this.ExSlot?.Torpedo ?? 0);
		public int SlotsAA => this.Slots.Sum(x => x.AA) + (this.ExSlot?.AA ?? 0);
		public int SlotsArmer => this.Slots.Sum(x => x.Armer) + (this.ExSlot?.Armer ?? 0);
		public int SlotsASW => this.Slots.Sum(x => x.ASW) + (this.ExSlot?.ASW ?? 0);
		public int SlotsHit => this.Slots.Sum(x => x.Hit) + (this.ExSlot?.Hit ?? 0);
		public int SlotsEvade => this.Slots.Sum(x => x.Evade) + (this.ExSlot?.Evade ?? 0);

		public int SumFirepower => 0 < this.Firepower ? this.Firepower + this.SlotsFirepower : this.Firepower;
		public int SumTorpedo => 0 < this.Torpedo ? this.Torpedo + this.SlotsTorpedo : this.Torpedo;
		public int SumAA => 0 < this.AA ? this.AA + this.SlotsAA : this.AA;
		public int SumArmer => 0 < this.Armer ? this.Armer + this.SlotsArmer : this.Armer;
		public int SumASW => this.ASW + this.SlotsASW;
		public int SumEvade => this.Evade; // + this.SlotsEvade;

		public int ShipEvade => this.Evade - this.SlotsEvade;

		// 先制対潜状況
		public bool OpeningASW
			=> this.MasterId == 141 ? true // 五十鈴改二
				: this.ShipType == 1 ? SumASW >= 60 // 解放さ
				: this.ShipType == 7 && this.ShipSpeed == ShipSpeed.Slow ? SumASW >= 65 // 低速 軽空母
				: SumASW >= 100;

		public LimitedValue HP => new LimitedValue(this.NowHP, this.MaxHP, 0);

		public AttackType DayAttackType
            => this.HasScout() && this.Count(Type2.主砲) == 2 && this.Count(Type2.徹甲弾) == 1 ? AttackType.カットイン主主
            : this.HasScout() && this.Count(Type2.主砲) == 1 && this.Count(Type2.副砲) == 1 && this.Count(Type2.徹甲弾) == 1 ? AttackType.カットイン主徹
            : this.HasScout() && this.Count(Type2.主砲) == 1 && this.Count(Type2.副砲) == 1 && this.Count(Type2.電探) == 1 ? AttackType.カットイン主電
            : this.HasScout() && this.Count(Type2.主砲) >= 1 && this.Count(Type2.副砲) >= 1 ? AttackType.カットイン主副
            : this.HasScout() && this.Count(Type2.主砲) >= 2 ? AttackType.連撃
            : this.CountFighter() >= 1 && this.CountDiveBomber() >= 1 && this.CountTorpedoBomber() >= 1 ? AttackType.カットイン艦戦艦爆艦攻
            : this.CountDiveBomber() >= 2 && this.CountTorpedoBomber() >= 1 ? AttackType.カットイン艦爆艦爆艦攻
            : this.CountDiveBomber() >= 1 && this.CountTorpedoBomber() >= 1 ? AttackType.カットイン艦爆艦攻
            : AttackType.通常;

		public AttackType NightAttackType
			=> this.SubmarineRaderCount() >= 1 && this.LateModelTorpedoCount() >= 1 ? AttackType.カットイン後期魚雷逆探
			: this.LateModelTorpedoCount() >= 2 ? AttackType.カットイン後期魚雷
			: this.Count(Type2.魚雷) >= 2 ? AttackType.カットイン雷
			: this.Count(Type2.主砲) >= 3 ? AttackType.カットイン主主主
			: this.Count(Type2.主砲) == 2 && this.Count(Type2.副砲) >= 1 ? AttackType.カットイン主主副
			: this.Count(Type2.主砲) == 2 && this.Count(Type2.副砲) == 0 && this.Count(Type2.魚雷) == 1 ? AttackType.カットイン主雷
			: this.Count(Type2.主砲) == 1 && this.Count(Type2.魚雷) == 1 ? AttackType.カットイン主雷
			: this.Count(Type2.主砲) == 2 && this.Count(Type2.副砲) == 0 && this.Count(Type2.魚雷) == 0 ? AttackType.連撃
			: this.Count(Type2.主砲) == 1 && this.Count(Type2.副砲) >= 1 && this.Count(Type2.魚雷) == 0 ? AttackType.連撃
			: this.Count(Type2.主砲) == 0 && this.Count(Type2.副砲) >= 2 && this.Count(Type2.魚雷) <= 1 ? AttackType.連撃
            : this.NightAerialAttack() == 2 ? AttackType.カットイン夜戦夜攻
            : this.NightAerialAttack() == 1 ? AttackType.カットイン夜戦夜攻2
            : AttackType.通常;

		public ShipData()
		{
			this._Name = "？？？";
			this._AdditionalName = "";
			this._TypeName = "？？？";
			this._ShipType = 0;
			this._Situation = ShipSituation.None;
			this._Slots = new ShipSlotData[0];
			this._ShipSpeed = ShipSpeed.Immovable;
		}
	}

	public static class ShipDataExtensions
	{
		public static int Count(this ShipData data, Type2 type2)
		{
			return data.Slots.Count(x => x.Type2 == type2)
				+ (data.ExSlot?.Type2 == type2 ? 1 : 0);
		}

		public static bool HasScout(this ShipData data)
		{
			return data.Slots
				.Where(x => x.Source.Type == SlotItemType.水上偵察機
							|| x.Source.Type == SlotItemType.水上爆撃機)
				.Any(x => 0 < x.Current);
		}

		public static int SubmarineRaderCount(this ShipData data)
		{
			var SubmarineRaders = new int[]
			{
				210, // 潜水艦搭載電探&水防式望遠鏡
				211, // 潜水艦搭載電探&逆探(E27)
			};
			return data.Slots.Count(x => SubmarineRaders.Contains(x.Source.Id))
				+ (SubmarineRaders.Contains(data.ExSlot?.Source.Id ?? 0) ? 1 : 0);
		}
		public static int LateModelTorpedoCount(this ShipData data)
		{
			var LateModelTorpedos = new int[]
			{
				213, // 後期型艦首魚雷(6門)
				214, // 熟練聴音員+後期型艦首魚雷(6門)
			};
			return data.Slots.Count(x => LateModelTorpedos.Contains(x.Source.Id))
				+ (LateModelTorpedos.Contains(data.ExSlot?.Source.Id ?? 0) ? 1 : 0);
		}
        public static int CountFighter(this ShipData data)
        {
            return data.Slots.Count(x => x.Source.Type == SlotItemType.艦上戦闘機);
        }
        public static int CountDiveBomber(this ShipData data)
        {
            return data.Slots.Count(x => x.Source.Type == SlotItemType.艦上爆撃機);
        }
        public static int CountTorpedoBomber(this ShipData data)
        {
            return data.Slots.Count(x => x.Source.Type == SlotItemType.艦上攻撃機);
        }
        public static int NightAerialAttack(this ShipData data)
        {
            var NightFighter = new int[]
            {
                // 夜戦
                254, // F6F-3N
				255, // F6F-5N
			};
            var NightStriker = new int[]
            {
                // 夜攻
                257, // TBM-3D
			};
            var NightStriker2 = new int[]
            {
                // 夜攻2
                152, // 零戦62型(爆戦/岩井隊)
                242, // Swordfish
                243, // Swordfish Mk.II(熟練)
                244, // Swordfish Mk.III(熟練)
			};
            var NightOperationAviationPersonnel = new int[]
            {
                258, // 夜間作戦航空要員
				259, // 夜間作戦航空要員＋熟練甲板員
			};
            var NightOperationCarrier = new int[]
            {
                345, // Saratoga Mk.II
			};
            if (NightOperationCarrier.Contains(data.MasterId))
            {
                //case for special night operational CV, only Saratoga Mk.II now 
                return data.Slots.Count(x => NightFighter.Contains(x.Source.Id)) >= 2 && data.Slots.Count(x => NightStriker.Contains(x.Source.Id)) >= 1 ? 2 // 夜戦 + 夜戦 + 夜攻 = 1.25
                    : data.Slots.Count(x => NightFighter.Contains(x.Source.Id)) >= 2 && data.Slots.Count(x => NightStriker2.Contains(x.Source.Id)) >= 1 ? 1 // 夜戦 + 夜戦 + 夜攻2 = 1.2
                    : data.Slots.Count(x => NightFighter.Contains(x.Source.Id)) == 1 && data.Slots.Count(x => NightStriker.Contains(x.Source.Id)) >= 1 ? 1  // 夜戦  + 夜攻 = 1.2
                    : data.Slots.Count(x => NightFighter.Contains(x.Source.Id)) == 1 && data.Slots.Count(x => NightStriker2.Contains(x.Source.Id)) >= 2 ? 1 // 夜戦  + 夜攻2 + 夜攻2 =  x 1.2
                    : 0;
            } else if (data.Slots.Count(x => NightOperationAviationPersonnel.Contains(x.Source.Id)) > 0)
            {
                return data.Slots.Count(x => NightFighter.Contains(x.Source.Id)) >= 2 && data.Slots.Count(x => NightStriker.Contains(x.Source.Id)) >= 1 ? 2 // 夜戦 + 夜戦 + 夜攻 = 1.25
                    : data.Slots.Count(x => NightFighter.Contains(x.Source.Id)) >= 2 && data.Slots.Count(x => NightStriker2.Contains(x.Source.Id)) >= 1 ? 1 // 夜戦 + 夜戦 + 夜攻2 = 1.2
                    : data.Slots.Count(x => NightFighter.Contains(x.Source.Id)) == 1 && data.Slots.Count(x => NightStriker.Contains(x.Source.Id)) >= 1 ? 1  // 夜戦  + 夜攻 = 1.2
                    : data.Slots.Count(x => NightFighter.Contains(x.Source.Id)) == 1 && data.Slots.Count(x => NightStriker2.Contains(x.Source.Id)) >= 2 ? 1 // 夜戦  + 夜攻2 + 夜攻2 =  x 1.2
                    : 0;
            }
            return 0;
        }
    }

	public class MembersShipData : ShipData
	{
		#region Source変更通知プロパティ
		private Ship _Source;
		public Ship Source
		{
			get { return this._Source; }
			set
			{
				if (this._Source != value)
				{
					this._Source = value;
					this.RaisePropertyChanged();
					this.UpdateFromSource();
				}
			}
		}
		#endregion

		public MembersShipData()
		{
		}

		public MembersShipData(Ship ship) : this()
		{
			this._Source = ship;
			this.UpdateFromSource();
		}

		private void UpdateFromSource()
		{
			this.Id = this.Source.Id;
			this.MasterId = this.Source.Info.Id;
			this.Name = this.Source.Info.Name;
			this.ShipType = this.Source.Info.ShipType.Id;
			this.ShipSpeed = this.Source.Speed;
			this.TypeName = this.Source.Speed == ShipSpeed.Immovable
				? "陸基"
				: this.Source.Info.ShipType.Name;
			this.Level = this.Source.Level;
			this.Situation = this.Source.Situation;
			this.NowHP = this.Source.HP.Current;
			this.MaxHP = this.Source.HP.Maximum;
			this.Slots = this.Source.Slots
				.Where(s => s != null)
				.Where(s => s.Equipped)
				.Select(s => new ShipSlotData(s))
				.ToArray();

            // resolve build error due to ExSlotExists not exists in original KCV
            //this.ExSlot =
            //	this.Source.ExSlotExists && this.Source.ExSlot.Equipped
            //	? new ShipSlotData(this.Source.ExSlot)
            //	: null;
            this.ExSlot = this.Source.ExSlot.Equipped ? new ShipSlotData(this.Source.ExSlot) : null;

            this.Condition = this.Source.Condition;
			this.ConditionType = this.Source.ConditionType;

			this.Firepower = this.Source.Firepower.Current;
			this.Torpedo = this.Source.Torpedo.Current;
			this.AA = this.Source.AA.Current;
			this.Armer = this.Source.Armer.Current;
			this.Luck = this.Source.Luck.Current;

            // resolve build error due to ASW.Current has different define in original KCV
			//this.ASW = this.Source.ASW.Current;
			this.Evade = this.Source.RawData.api_kaihi[0];
		}
	}

	public class MastersShipData : ShipData
	{
		#region Source変更通知プロパティ
		private ShipInfo _Source;
		public ShipInfo Source
		{
			get { return this._Source; }
			set
			{
				if (this._Source != value)
				{
					this._Source = value;
					this.RaisePropertyChanged();
					this.UpdateFromSource();
				}
			}
		}
		#endregion

		public MastersShipData()
		{
		}

		public MastersShipData(ShipInfo info) : this()
		{
			this._Source = info;
			this.UpdateFromSource();
		}

		private void UpdateFromSource()
		{
			this.Id = this.Source.Id;
			this.Name = this.Source.Name;

			this.Condition = -1;

			var isEnemyID = this.Source?.Id > 1500;
			this.AdditionalName = isEnemyID ? this.Source?.RawData.api_yomi : "";

            // resolve build error due to "Speed" define not exists in original KCV
            //this.ShipSpeed = this.Source?.Speed ?? ShipSpeed.Immovable;
            //this.TypeName = this.Source?.Speed == ShipSpeed.Immovable
            //	? "陸基"
            //	: this.Source?.ShipType.Name;
            this.TypeName = this.Source.ShipType.Name;
        }
	}
}
