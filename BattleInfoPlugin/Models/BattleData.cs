using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using BattleInfoPlugin.Models.Raw;
using BattleInfoPlugin.Models.Repositories;
using Grabacr07.KanColleWrapper;
using Livet;
using Grabacr07.KanColleWrapper.Models;
using BattleInfoPlugin.Properties;
using System.Text;
using System.Diagnostics;
using System.Windows;

namespace BattleInfoPlugin.Models
{
	public class BattleData : NotificationObject
	{
		//FIXME 敵の開幕雷撃&連合艦隊がまだ不明(とりあえず第二艦隊が受けるようにしてる)

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


		#region UpdatedTime変更通知プロパティ
		private DateTimeOffset _UpdatedTime;

		public DateTimeOffset UpdatedTime
		{
			get
			{ return this._UpdatedTime; }
			set
			{
				if (this._UpdatedTime == value)
					return;
				this._UpdatedTime = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion


		#region CellEvent変更通知プロパティ
		private int _CellEvent;

		public int CellEvent
		{
			get
			{ return this._CellEvent; }
			set
			{
				if (this._CellEvent == value)
					return;
				this._CellEvent = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion


		#region Cell変更通知プロパティ
		private string _Cell;

		public string Cell
		{
			get
			{ return this._Cell; }
			set
			{
				if (this._Cell == value)
					return;
				this._Cell = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion


		#region BattleSituation変更通知プロパティ

		private BattleSituation _BattleSituation;

		public BattleSituation BattleSituation
		{
			get
			{ return this._BattleSituation; }
			set
			{
				if (this._BattleSituation == value)
					return;
				this._BattleSituation = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion


		#region FirstFleet変更通知プロパティ
		private FleetData _FirstFleet;

		public FleetData FirstFleet
		{
			get
			{ return this._FirstFleet; }
			set
			{
				if (this._FirstFleet == value)
					return;
				this._FirstFleet = value;
				this._FirstFleet.FleetType = FleetType.First;
				Settings.Default.FirstIsCritical = this._FirstFleet.CriticalCheck();
				this.RaisePropertyChanged();
			}
		}
		#endregion


		#region SecondFleet変更通知プロパティ
		private FleetData _SecondFleet;

		public FleetData SecondFleet
		{
			get
			{ return this._SecondFleet; }
			set
			{
				if (this._SecondFleet == value)
					return;
				this._SecondFleet = value;
				this._SecondFleet.FleetType = FleetType.Second;
				Settings.Default.SecondIsCritical = this._SecondFleet.CriticalCheck();
				this.RaisePropertyChanged();
			}
		}
		#endregion


		#region Enemies変更通知プロパティ
		private FleetData _Enemies;

		public FleetData Enemies
		{
			get
			{ return this._Enemies; }
			set
			{
				if (this._Enemies == value)
					return;
				this._Enemies = value;
				this._Enemies.FleetType = FleetType.Enemy;
				this.RaisePropertyChanged();
			}
		}
		#endregion


		#region RankResult変更通知プロパティ
		private Rank _RankResult;

		public Rank RankResult
		{
			get
			{ return this._RankResult; }
			set
			{
				if (this._RankResult == value)
					return;
				this._RankResult = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion


		#region FriendAirSupremacy変更通知プロパティ
		private AirSupremacy _FriendAirSupremacy = AirSupremacy.항공전없음;

		public AirSupremacy FriendAirSupremacy
		{
			get
			{ return this._FriendAirSupremacy; }
			set
			{
				if (this._FriendAirSupremacy == value)
					return;
				this._FriendAirSupremacy = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion


		#region AirCombatResults変更通知プロパティ
		private AirCombatResult[] _AirCombatResults = new AirCombatResult[0];

		public AirCombatResult[] AirCombatResults
		{
			get
			{ return this._AirCombatResults; }
			set
			{
				if (this._AirCombatResults.Equals(value))
					return;
				this._AirCombatResults = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion


		#region DropShipName変更通知プロパティ
		private string _DropShipName;

		public string DropShipName
		{
			get
			{ return this._DropShipName; }
			set
			{
				if (this._DropShipName == value)
					return;
				this._DropShipName = value;
				this.RaisePropertyChanged();
			}
		}
		#endregion


		private int CurrentDeckId { get; set; }

		public BattleData()
		{
			var proxy = KanColleClient.Current.Proxy;

			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_port/port")
				.TryParse<battle_midnight_battle>().Subscribe(x => this.ResultClear());

			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_req_battle_midnight/battle")
				.TryParse<battle_midnight_battle>().Subscribe(x => this.Update(x.Data));

			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_req_battle_midnight/sp_midnight")
				.TryParse<battle_midnight_sp_midnight>().Subscribe(x => this.Update(x.Data));

			proxy.api_req_combined_battle_airbattle
				.TryParse<combined_battle_airbattle>().Subscribe(x => this.Update(x.Data));

			proxy.api_req_combined_battle_battle
				.TryParse<combined_battle_battle>().Subscribe(x => this.Update(x.Data));

			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_req_combined_battle/battle_water")
				.TryParse<combined_battle_battle_water>().Subscribe(x => this.Update(x.Data));

			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_req_combined_battle/midnight_battle")
				.TryParse<combined_battle_midnight_battle>().Subscribe(x => this.Update(x.Data));

			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_req_combined_battle/sp_midnight")
				.TryParse<combined_battle_sp_midnight>().Subscribe(x => this.Update(x.Data));

			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_req_practice/battle")
				.TryParse<practice_battle>().Subscribe(x => this.Update(x.Data));

			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_req_practice/midnight_battle")
				.TryParse<practice_midnight_battle>().Subscribe(x => this.Update(x.Data));

			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_req_sortie/airbattle")
				.TryParse<sortie_airbattle>().Subscribe(x => this.Update(x.Data));

			proxy.api_req_sortie_battle
				.TryParse<sortie_battle>().Subscribe(x => this.Update(x.Data));

			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_req_sortie/ld_airbattle")
				.TryParse<sortie_ld_airbattle>().Subscribe(x => this.Update(x.Data));

			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_req_combined_battle/ld_airbattle")
				.TryParse<combined_battle_ld_airbattle>().Subscribe(x => this.Update(x.Data));


			proxy.api_req_sortie_battleresult
				.TryParse<battle_result>().Subscribe(x => this.Update(x.Data));

			proxy.api_req_combined_battle_battleresult
				.TryParse<battle_result>().Subscribe(x => this.Update(x.Data));


			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_req_map/start")
				.TryParse<map_start_next>().Subscribe(x => this.UpdateFleetsByStartNext(x.Data, x.Request["api_deck_id"]));

			proxy.ApiSessionSource.Where(x => x.Request.PathAndQuery == "/kcsapi/api_req_map/next")
				.TryParse<map_start_next>().Subscribe(x => this.UpdateFleetsByStartNext(x.Data));

		}

		#region Update From Battle SvData

		public void Update(battle_midnight_battle data)
		{
			this.Name = "통상 - 야전";

			int BeforedayBattleHP = this.FirstFleet.Ships
				.Where(x => !x.Situation.HasFlag(ShipSituation.Tow) && !x.Situation.HasFlag(ShipSituation.Evacuation))
				.Sum(x => x.BeforeNowHP);//리스트 갱신하기전에 아군 HP최대값을 저장
			int EnemyBeforedayBattle = this.Enemies.Ships.Sum(x => x.BeforeNowHP);

			this.UpdateFleets(data.api_deck_id, data);
			this.UpdateMaxHP(data.api_maxhps);
			this.UpdateNowHP(data.api_nowhps);

			this.FirstFleet.CalcDamages(data.api_hougeki.GetFriendDamages());

			this.Enemies.CalcDamages(data.api_hougeki.GetEnemyDamages());

			this.RankResult = this.CalcRank(false, true, BeforedayBattleHP, EnemyBeforedayBattle);
		}

		public void Update(battle_midnight_sp_midnight data)
		{
			this.Name = "통상 - 개막야전";

			this.UpdateFleets(data.api_deck_id, data, data.api_formation);
			this.UpdateMaxHP(data.api_maxhps);
			this.UpdateNowHP(data.api_nowhps);

			this.FirstFleet.CalcDamages(data.api_hougeki.GetFriendDamages());

			this.Enemies.CalcDamages(data.api_hougeki.GetEnemyDamages());

			this.FriendAirSupremacy = AirSupremacy.항공전없음;

			this.RankResult = this.CalcRank();
		}

		public void Update(combined_battle_airbattle data)
		{
			this.Name = "연합함대 - 항공전 - 주간";

			this.UpdateFleets(data.api_deck_id, data, data.api_formation);
			this.UpdateMaxHP(data.api_maxhps, data.api_maxhps_combined);
			this.UpdateNowHP(data.api_nowhps, data.api_nowhps_combined);

			this.FirstFleet.CalcDamages(
				data.api_kouku.GetFirstFleetDamages(),
				data.api_kouku2.GetFirstFleetDamages()
				);

			this.SecondFleet.CalcDamages(
				data.api_kouku.GetSecondFleetDamages(),
				data.api_kouku2.GetSecondFleetDamages()
				);

			this.Enemies.CalcDamages(
				data.api_support_info.GetEnemyDamages(),
				data.api_kouku.GetEnemyDamages(),
				data.api_kouku2.GetEnemyDamages()
				);

			this.FriendAirSupremacy = data.api_kouku.GetAirSupremacy(); //航空戦2回目はスルー

			this.AirCombatResults = data.api_kouku.ToResult("1회차/")
							.Concat(data.api_kouku2.ToResult("2회차/")).ToArray();

			this.RankResult = this.CalcRank(true);
		}

		public void Update(combined_battle_battle data)
		{
			this.Name = "연합함대 - 기동부대 - 주간전";

			this.UpdateFleets(data.api_deck_id, data, data.api_formation);
			this.UpdateMaxHP(data.api_maxhps, data.api_maxhps_combined);
			this.UpdateNowHP(data.api_nowhps, data.api_nowhps_combined);

			this.FirstFleet.CalcDamages(
				data.api_kouku.GetFirstFleetDamages(),
				data.api_hougeki2.GetFriendDamages(),
				data.api_hougeki3.GetFriendDamages()
				);

			this.SecondFleet.CalcDamages(
				data.api_kouku.GetSecondFleetDamages(),
				data.api_opening_atack.GetFriendDamages(),
				data.api_hougeki1.GetFriendDamages(),
				data.api_raigeki.GetFriendDamages()
				);

			this.Enemies.CalcDamages(
				data.api_support_info.GetEnemyDamages(),
				data.api_kouku.GetEnemyDamages(),
				data.api_opening_atack.GetEnemyDamages(),
				data.api_hougeki1.GetEnemyDamages(),
				data.api_raigeki.GetEnemyDamages(),
				data.api_hougeki2.GetEnemyDamages(),
				data.api_hougeki3.GetEnemyDamages()
				);

			this.FriendAirSupremacy = data.api_kouku.GetAirSupremacy();

			this.AirCombatResults = data.api_kouku.ToResult();

			this.RankResult = this.CalcRank(true);
		}

		public void Update(combined_battle_battle_water data)
		{
			this.Name = "연합함대 - 수상부대 - 주간전";

			this.UpdateFleets(data.api_deck_id, data, data.api_formation);
			this.UpdateMaxHP(data.api_maxhps, data.api_maxhps_combined);
			this.UpdateNowHP(data.api_nowhps, data.api_nowhps_combined);

			this.FirstFleet.CalcDamages(
				data.api_kouku.GetFirstFleetDamages(),
				data.api_hougeki1.GetFriendDamages(),
				data.api_hougeki2.GetFriendDamages()
				);

			this.SecondFleet.CalcDamages(
				data.api_kouku.GetSecondFleetDamages(),
				data.api_opening_atack.GetFriendDamages(),
				data.api_hougeki3.GetFriendDamages(),
				data.api_raigeki.GetFriendDamages()
				);

			this.Enemies.CalcDamages(
				data.api_support_info.GetEnemyDamages(),
				data.api_kouku.GetEnemyDamages(),
				data.api_opening_atack.GetEnemyDamages(),
				data.api_hougeki1.GetEnemyDamages(),
				data.api_hougeki2.GetEnemyDamages(),
				data.api_hougeki3.GetEnemyDamages(),
				data.api_raigeki.GetEnemyDamages()
				);

			this.FriendAirSupremacy = data.api_kouku.GetAirSupremacy();

			this.AirCombatResults = data.api_kouku.ToResult();

			this.RankResult = this.CalcRank(true);
		}

		public void Update(combined_battle_midnight_battle data)
		{
			this.Name = "연합함대 - 야전";

			int BeforedayBattleHP = this.FirstFleet.Ships
				.Where(x => !x.Situation.HasFlag(ShipSituation.Tow) && !x.Situation.HasFlag(ShipSituation.Evacuation))
				.Sum(x => x.BeforeNowHP);//리스트 갱신하기전에 아군 HP최대값을 저장
			int EnemyBeforedayBattle = this.Enemies.Ships.Sum(x => x.BeforeNowHP);
			BeforedayBattleHP += this.SecondFleet.Ships
				.Where(x => !x.Situation.HasFlag(ShipSituation.Tow) && !x.Situation.HasFlag(ShipSituation.Evacuation))
				.Sum(x => x.BeforeNowHP);//리스트 갱신하기전에 아군 HP최대값을 저장

			this.UpdateFleets(data.api_deck_id, data);
			this.UpdateMaxHP(data.api_maxhps, data.api_maxhps_combined);
			this.UpdateNowHP(data.api_nowhps, data.api_nowhps_combined);

			this.SecondFleet.CalcDamages(data.api_hougeki.GetFriendDamages());

			this.Enemies.CalcDamages(data.api_hougeki.GetEnemyDamages());

			this.RankResult = this.CalcRank(true, true, BeforedayBattleHP, EnemyBeforedayBattle);
		}

		public void Update(combined_battle_sp_midnight data)
		{
			this.Name = "연합함대 - 개막야전";

			this.UpdateFleets(data.api_deck_id, data, data.api_formation);
			this.UpdateMaxHP(data.api_maxhps, data.api_maxhps_combined);
			this.UpdateNowHP(data.api_nowhps, data.api_nowhps_combined);

			this.SecondFleet.CalcDamages(data.api_hougeki.GetFriendDamages());

			this.Enemies.CalcDamages(data.api_hougeki.GetEnemyDamages());

			this.FriendAirSupremacy = AirSupremacy.항공전없음;

			this.RankResult = this.CalcRank(true);
		}

		public void Update(practice_battle data)
		{
			this.Clear();

			this.Name = "연습 - 주간전";

			this.UpdateFleets(data.api_dock_id, data, data.api_formation);
			this.UpdateMaxHP(data.api_maxhps);
			this.UpdateNowHP(data.api_nowhps);

			this.FirstFleet.CalcPracticeDamages(
				data.api_kouku.GetFirstFleetDamages(),
				data.api_opening_atack.GetFriendDamages(),
				data.api_hougeki1.GetFriendDamages(),
				data.api_hougeki2.GetFriendDamages(),
				data.api_raigeki.GetFriendDamages()
				);

			this.Enemies.CalcPracticeDamages(
				data.api_kouku.GetEnemyDamages(),
				data.api_opening_atack.GetEnemyDamages(),
				data.api_hougeki1.GetEnemyDamages(),
				data.api_hougeki2.GetEnemyDamages(),
				data.api_raigeki.GetEnemyDamages()
				);

			this.FriendAirSupremacy = data.api_kouku.GetAirSupremacy();

			this.AirCombatResults = data.api_kouku.ToResult();

			this.RankResult = this.CalcRank();
		}

		public void Update(practice_midnight_battle data)
		{
			this.Name = "연습 - 야전";

			int BeforedayBattleHP = this.FirstFleet.Ships
				.Where(x => !x.Situation.HasFlag(ShipSituation.Tow) && !x.Situation.HasFlag(ShipSituation.Evacuation))
				.Sum(x => x.BeforeNowHP);//리스트 갱신하기전에 아군 HP최대값을 저장
			int EnemyBeforedayBattle = this.Enemies.Ships.Sum(x => x.BeforeNowHP);

			this.UpdateFleets(data.api_deck_id, data);
			this.UpdateMaxHP(data.api_maxhps);
			this.UpdateNowHP(data.api_nowhps);

			this.FirstFleet.CalcPracticeDamages(data.api_hougeki.GetFriendDamages());

			this.Enemies.CalcPracticeDamages(data.api_hougeki.GetEnemyDamages());

			this.RankResult = this.CalcRank(false, true, BeforedayBattleHP, EnemyBeforedayBattle);
		}

		private void Update(sortie_airbattle data)
		{
			this.Name = "항공전 - 주간전";

			this.UpdateFleets(data.api_dock_id, data, data.api_formation);
			this.UpdateMaxHP(data.api_maxhps);
			this.UpdateNowHP(data.api_nowhps);

			this.FirstFleet.CalcDamages(
				data.api_kouku.GetFirstFleetDamages(),
				data.api_kouku2.GetFirstFleetDamages()
				);

			this.Enemies.CalcDamages(
				data.api_support_info.GetEnemyDamages(),    //将来的に増える可能性を想定して追加しておく
				data.api_kouku.GetEnemyDamages(),
				data.api_kouku2.GetEnemyDamages()
				);

			this.FriendAirSupremacy = data.api_kouku.GetAirSupremacy(); // 航空戦2回目はスルー

			this.AirCombatResults = data.api_kouku.ToResult("1회차/")
							.Concat(data.api_kouku2.ToResult("2회차/")).ToArray();

			this.RankResult = this.CalcRank();
		}

		private void Update(sortie_battle data)
		{
			this.Name = "통상 - 주간전";

			this.UpdateFleets(data.api_dock_id, data, data.api_formation);
			this.UpdateMaxHP(data.api_maxhps);
			this.UpdateNowHP(data.api_nowhps);

			this.FirstFleet.CalcDamages(
				data.api_kouku.GetFirstFleetDamages(),
				data.api_opening_atack.GetFriendDamages(),
				data.api_hougeki1.GetFriendDamages(),
				data.api_hougeki2.GetFriendDamages(),
				data.api_raigeki.GetFriendDamages()
				);

			this.Enemies.CalcDamages(
				data.api_support_info.GetEnemyDamages(),
				data.api_kouku.GetEnemyDamages(),
				data.api_opening_atack.GetEnemyDamages(),
				data.api_hougeki1.GetEnemyDamages(),
				data.api_hougeki2.GetEnemyDamages(),
				data.api_raigeki.GetEnemyDamages()
				);

			this.FriendAirSupremacy = data.api_kouku.GetAirSupremacy();

			this.AirCombatResults = data.api_kouku.ToResult();

			this.RankResult = this.CalcRank();
		}

		private void Update(sortie_ld_airbattle data)
		{
			this.Name = "공습전 - 주간";

			this.UpdateFleets(data.api_dock_id, data, data.api_formation);
			this.UpdateMaxHP(data.api_maxhps);
			this.UpdateNowHP(data.api_nowhps);

			this.FirstFleet.CalcDamages(
				data.api_kouku.GetFirstFleetDamages()
				);

			this.FriendAirSupremacy = data.api_kouku.GetAirSupremacy();

			this.AirCombatResults = data.api_kouku.ToResult();

			//this.RankResult = this.CalcRank();
			this.RankResult = Rank.공습전;
		}

		private void Update(combined_battle_ld_airbattle data)
		{
			this.Name = "연합함대 - 공습전 - 주간";

			this.UpdateFleets(data.api_deck_id, data, data.api_formation);
			this.UpdateMaxHP(data.api_maxhps, data.api_maxhps_combined);
			this.UpdateNowHP(data.api_nowhps, data.api_nowhps_combined);

			this.FirstFleet.CalcDamages(
				data.api_kouku.GetFirstFleetDamages()
				);

			this.SecondFleet.CalcDamages(
				data.api_kouku.GetSecondFleetDamages()
				);

			this.FriendAirSupremacy = data.api_kouku.GetAirSupremacy();

			this.AirCombatResults = data.api_kouku.ToResult();

			//this.RankResult = this.CalcRank();
			this.RankResult = Rank.공습전;
		}

		#endregion

		public void Update(battle_result data)
		{
			//this.DropShipName = KanColleClient.Current.Translations.GetTranslation(data.api_get_ship?.api_ship_name, TranslationType.Ships, true);
			this.DropShipName = KanColleClient.Current.Master.Ships.SingleOrDefault(x => x.Value.Id == data.api_get_ship?.api_ship_id).Value?.Name;
		}

		private void UpdateFleetsByStartNext(map_start_next startNext, string api_deck_id = null)
		{
			this.Clear();

			this.CellEvent = startNext.api_event_id;
			this.Cell = "";
			if (startNext.api_no != 0)
			{
				this.Cell = startNext.api_maparea_id + "-" + startNext.api_mapinfo_no + "-" + startNext.api_no;
			}
			this.RankResult = Rank.없음;

			if (api_deck_id != null) this.CurrentDeckId = int.Parse(api_deck_id);
			if (this.CurrentDeckId < 1) return;

			this.UpdateFriendFleets(this.CurrentDeckId);

			if (this.FirstFleet != null) this.FirstFleet.TotalDamaged = 0;
			if (this.SecondFleet != null) this.SecondFleet.TotalDamaged = 0;
		}

		private void UpdateFleets(
			int api_deck_id,
			ICommonBattleMembers data,
			int[] api_formation = null)
		{
			this.UpdatedTime = DateTimeOffset.Now;
			this.UpdateFriendFleets(api_deck_id);

			var eTotal = 0;
			if (this.Enemies != null) eTotal = this.Enemies.TotalDamaged;
			this.Enemies = new FleetData(
				data.ToMastersShipDataArray(),
				this.Enemies?.Formation ?? Formation.없음,
				this.Enemies?.Name ?? "",
				FleetType.Enemy,
				this.Enemies?.Rank);
			this.Enemies.TotalDamaged = eTotal;

			if (api_formation != null)
			{
				this.BattleSituation = (BattleSituation)api_formation[2];
				if (this.FirstFleet != null) this.FirstFleet.Formation = (Formation)api_formation[0];
				if (this.Enemies != null) this.Enemies.Formation = (Formation)api_formation[1];
			}

			this.CurrentDeckId = api_deck_id;
		}

		private void UpdateFriendFleets(int deckID)
		{
			var organization = KanColleClient.Current.Homeport.Organization;

			int firstTotal = 0;
			int secondTotal = 0;
			if (this.FirstFleet != null) firstTotal = this.FirstFleet.TotalDamaged;
			if (this.SecondFleet != null) secondTotal = this.SecondFleet.TotalDamaged;

			this.FirstFleet = new FleetData(
				organization.Fleets[deckID].Ships.Select(s => new MembersShipData(s)).ToArray(),
				this.FirstFleet?.Formation ?? Formation.없음,
				organization.Fleets[deckID].Name,
				FleetType.First);
			this.FirstFleet.TotalDamaged = firstTotal;

			this.SecondFleet = new FleetData(
				organization.Combined && deckID == 1
					? organization.Fleets[2].Ships.Select(s => new MembersShipData(s)).ToArray()
					: new MembersShipData[0],
				this.SecondFleet?.Formation ?? Formation.없음,
				organization.Fleets[2].Name,
				FleetType.Second);
			this.SecondFleet.TotalDamaged = secondTotal;
		}

		private void UpdateMaxHP(int[] api_maxhps, int[] api_maxhps_combined = null)
		{
			this.FirstFleet.Ships.SetValues(api_maxhps.GetFriendData(), (s, v) => s.MaxHP = v);
			this.Enemies.Ships.SetValues(api_maxhps.GetEnemyData(), (s, v) => s.MaxHP = v);

			if (api_maxhps_combined == null) return;
			this.SecondFleet.Ships.SetValues(api_maxhps_combined.GetFriendData(), (s, v) => s.MaxHP = v);
		}

		private void UpdateNowHP(int[] api_nowhps, int[] api_nowhps_combined = null)
		{
			this.FirstFleet.Ships.SetValues(api_nowhps.GetFriendData(), (s, v) => s.NowHP = v);
			this.Enemies.Ships.SetValues(api_nowhps.GetEnemyData(), (s, v) => s.NowHP = v);
			this.FirstFleet.Ships.SetValues(api_nowhps.GetFriendData(), (s, v) => s.BeforeNowHP = v);
			this.Enemies.Ships.SetValues(api_nowhps.GetEnemyData(), (s, v) => s.BeforeNowHP = v);

			if (api_nowhps_combined == null) return;
			this.SecondFleet.Ships.SetValues(api_nowhps_combined.GetFriendData(), (s, v) => s.NowHP = v);
			this.SecondFleet.Ships.SetValues(api_nowhps_combined.GetFriendData(), (s, v) => s.BeforeNowHP = v);
		}
		private void ResultClear()
		{
			if (this.FirstFleet != null) this.FirstFleet.TotalDamaged = 0;
			if (this.SecondFleet != null) this.SecondFleet.TotalDamaged = 0;
		}
		private void Clear()
		{
			this.UpdatedTime = DateTimeOffset.Now;
			this.Name = "";
			this.DropShipName = null;

			this.BattleSituation = BattleSituation.없음;
			this.FriendAirSupremacy = AirSupremacy.항공전없음;
			this.AirCombatResults = new AirCombatResult[0];
			if (this.FirstFleet != null) this.FirstFleet.Formation = Formation.없음;
			this.Enemies = new FleetData();
		}
		private bool CalcOverKill(int MaxCount, int SinkCount)
		{
			if (MaxCount == 1)
			{
				if (MaxCount == SinkCount) return true;
				else return false;
			}
			if (MaxCount == 2)
			{
				if (SinkCount >= 1) return true;
				else return false;
			}
			if (Convert.ToInt32(Math.Floor((decimal)((decimal)MaxCount / 3m) * 2m)) <= SinkCount)
				return true;
			else return false;
		}
		private Rank CalcRank(bool IsCombined = false, bool IsMidnight = false, int BeforeHP = 0, int EnemyBefore = 0)
		{
			try
			{
				var TotalDamage = this.FirstFleet.TotalDamaged;
				var MaxHPs = this.FirstFleet.Ships
					.Where(x => !x.Situation.HasFlag(ShipSituation.Tow) && !x.Situation.HasFlag(ShipSituation.Evacuation))
					.Sum(x => x.BeforeNowHP);
				var EnemyTotal = this.Enemies.TotalDamaged;
				var EnemyMax = this.Enemies.Ships.Sum(x => x.BeforeNowHP);
				var IsShipSink = this.FirstFleet.SinkCount > 0 ? true : false;
				ShipData EnemyFlag = this.Enemies.Ships.First();

				decimal GreenGauge = (decimal)EnemyTotal / (decimal)EnemyMax;//적이 받은 총 데미지
				decimal RedGauge = (decimal)TotalDamage / (decimal)MaxHPs;//아군이 받은 총 데미지

				bool IsThreeTime = false;
				bool IsOverDamage = false;
				bool IsMidDamage = false;
				bool IsScratch = false;

				int MaxCount = this.FirstFleet.Ships
					.Where(x => !x.Situation.HasFlag(ShipSituation.Tow) && !x.Situation.HasFlag(ShipSituation.Evacuation))
					.Count();
				int EnemyMaxCount = this.Enemies.Ships.Count();
				int SinkCount = this.FirstFleet.SinkCount;

				if (IsCombined)
				{
					TotalDamage += this.SecondFleet.TotalDamaged;
					MaxHPs += this.SecondFleet.Ships.Sum(x => x.BeforeNowHP);
					RedGauge = (decimal)TotalDamage / (decimal)MaxHPs;//아군이 받은 총 데미지

					if (!IsShipSink) IsShipSink = this.SecondFleet.SinkCount > 0 ? true : false;
					MaxCount += this.SecondFleet.Ships
					.Where(x => !x.Situation.HasFlag(ShipSituation.Tow) && !x.Situation.HasFlag(ShipSituation.Evacuation))
					.Count();
					SinkCount += this.SecondFleet.SinkCount;
				}
				if (IsMidnight)
				{
					MaxHPs = BeforeHP;
					EnemyMax = EnemyBefore;

					GreenGauge = (decimal)EnemyTotal / (decimal)EnemyMax;//적이 받은 총 데미지
					RedGauge = (decimal)TotalDamage / (decimal)MaxHPs;//아군이 받은 총 데미지
				}


				this.FirstFleet.AttackGauge = this.MakeGaugeText(EnemyTotal, EnemyMax, GreenGauge);
				this.Enemies.AttackGauge = this.MakeGaugeText(TotalDamage, MaxHPs, RedGauge);


				bool IsOverKill = CalcOverKill(EnemyMaxCount, this.Enemies.SinkCount);
				bool IsOverKilled = CalcOverKill(MaxCount, SinkCount);


				if (TotalDamage > 0)
				{
					decimal gG = Convert.ToDecimal(GreenGauge);
					decimal rG = Convert.ToDecimal(RedGauge);

					var CalcPercent = Math.Round(gG / rG, 2, MidpointRounding.AwayFromZero);
					if (CalcPercent >= 2.5m)
						IsOverDamage = true;//2.5배 초과 데미지
					else if (CalcPercent > 1m)
						IsMidDamage = true;//1초과 2.5이하
					else IsScratch = true;//1미만
					if (IsShipSink)
					{
						if (CalcPercent > 3m)
						{
							IsThreeTime = true;
							IsOverDamage = true;
							IsMidDamage = false;
							IsScratch = false;
						}
					}
				}
				else if (TotalDamage == 0)
				{
					if (EnemyTotal == 0) IsScratch = true;
					else IsOverDamage = true;//아군피해 0인 경우
				}



				if (TotalDamage == 0 && EnemyTotal == 0) return Rank.패배;//d
				if (GreenGauge < 0.0005m) return Rank.패배;//d
				else if (IsShipSink)
				{
					if (EnemyFlag.NowHP <= 0)
					{
						if (IsOverKill) return Rank.B승리;
						else return Rank.패배;//d
					}
					else if (IsMidDamage) return Rank.패배;//c
					else
					{
						if (IsOverKilled) return Rank.패배;//e
						else
						{
							if (!IsOverKill && IsThreeTime) return Rank.B승리;
							if (IsOverKill && IsOverDamage) return Rank.B승리;
							else return Rank.패배;//c
						}
					}
				}
				else
				{
					if (EnemyFlag.NowHP <= 0)
					{
						if (EnemyMaxCount == this.Enemies.SinkCount)
						{
							if (TotalDamage > 0) return Rank.S승리;
							else return Rank.완전승리S;
						}
						else
						{
							if (IsOverKill) return Rank.A승리;
							else return Rank.B승리;
						}
					}
					else
					{
						if (IsOverKill) return Rank.A승리;

						if (IsOverDamage) return Rank.B승리;
						else if (IsMidDamage) return Rank.패배;//c
						else if (IsScratch) return Rank.패배;//d
						else return Rank.패배;//d
					}
				}
			}
			catch (Exception ex)
			{
				//KanColleClient.Current.CatchedErrorLogWriter.ReportException(ex.Source, ex);
				Debug.WriteLine(ex);
				return Rank.에러;
			}
		}

		private string MakeGaugeText(int current, int max, decimal percent)
		{
			StringBuilder temp = new StringBuilder();

			temp.Append("(" + current + "/" + max + ") ");
			temp.Append(Math.Round(percent * 100, 2, MidpointRounding.AwayFromZero) + "%");
			return temp.ToString();
		}
	}
}
