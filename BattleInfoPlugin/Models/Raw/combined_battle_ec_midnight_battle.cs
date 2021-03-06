﻿namespace BattleInfoPlugin.Models.Raw
{
	/// <summary>
	/// 심해연합함대 - 야전
	/// </summary>
	public class combined_battle_ec_midnight_battle : ICommonEachBattleMembers
	{
		public int[] api_active_deck { get; set; }
		public int api_deck_id { get; set; }
		public int[] api_ship_ke { get; set; }
		public int[] api_ship_ke_combined { get; set; }
		public int[] api_ship_lv { get; set; }
		public int[] api_ship_lv_combined { get; set; }
		public int[] api_nowhps { get; set; }
		public int[] api_maxhps { get; set; }
		public int[] api_nowhps_combined { get; set; }
		public int[] api_maxhps_combined { get; set; }
		public int[][] api_eSlot { get; set; }
		public int[][] api_eSlot_combined { get; set; }
		public int[][] api_eKyouka { get; set; }
		public int[][] api_fParam { get; set; }
		public int[][] api_eParam { get; set; }
		public int[][] api_fParam_combined { get; set; }
		public int[][] api_eParam_combined { get; set; }
		public int[] api_touch_plane { get; set; }
		public int[] api_flare_pos { get; set; }
		public Midnight_Hougeki api_hougeki { get; set; }
	}

}
