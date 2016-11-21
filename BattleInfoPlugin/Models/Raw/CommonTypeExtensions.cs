using System;
using System.Collections.Generic;
using System.Linq;
using BattleInfoPlugin.Properties;

namespace BattleInfoPlugin.Models.Raw
{
	public static class CommonTypeExtensions
	{
		private static readonly FleetDamages defaultValue = new FleetDamages();

		#region 支援

		public static FleetDamages GetEnemyDamages(this Api_Support_Info support)
			=> support?.api_support_airatack?.api_stage3?.api_edam?.GetDamages()
			   ?? support?.api_support_hourai?.api_damage?.GetDamages()
			   ?? defaultValue;

		public static FleetDamages GetEachFirstEnemyDamages(this Api_Support_Info support)
			=> support?.api_support_airatack?.api_stage3?.api_edam?.GetEachDamages()
			   ?? support?.api_support_hourai?.api_damage?.GetEachDamages()
			   ?? defaultValue;

		public static FleetDamages GetEachSecondEnemyDamages(this Api_Support_Info support)
			=> support?.api_support_airatack?.api_stage3?.api_edam?.GetEachDamages(true)
			   ?? support?.api_support_hourai?.api_damage?.GetEachDamages(true)
			   ?? defaultValue;

		#endregion

		#region 砲撃

		public static FleetDamages GetFriendDamages(this Hougeki hougeki)
			=> hougeki?.api_damage?.GetFriendDamages(hougeki.api_df_list)
			   ?? defaultValue;

		public static FleetDamages GetEnemyDamages(this Hougeki hougeki)
			=> hougeki?.api_damage?.GetEnemyDamages(hougeki.api_df_list)
			   ?? defaultValue;

		public static FleetDamages GetEachFirstFriendDamages(this Hougeki hougeki)
			=> hougeki?.api_damage?.GetEachFriendDamages(hougeki.api_df_list, hougeki.api_at_eflag)
			   ?? defaultValue;

		public static FleetDamages GetEachSecondFriendDamages(this Hougeki hougeki)
			=> hougeki?.api_damage?.GetEachFriendDamages(hougeki.api_df_list, hougeki.api_at_eflag, true)
			   ?? defaultValue;

		public static FleetDamages GetEachFirstEnemyDamages(this Hougeki hougeki)
			=> hougeki?.api_damage?.GetEachEnemyDamages(hougeki.api_df_list, hougeki.api_at_eflag)
			   ?? defaultValue;
		public static FleetDamages GetEachSecondEnemyDamages(this Hougeki hougeki)
			=> hougeki?.api_damage?.GetEachEnemyDamages(hougeki.api_df_list, hougeki.api_at_eflag, true)
			   ?? defaultValue;

		#endregion

		#region 夜戦

		public static FleetDamages GetFriendDamages(this Midnight_Hougeki hougeki)
			=> hougeki?.api_damage?.GetFriendDamages(hougeki.api_df_list)
			   ?? defaultValue;

		public static FleetDamages GetEnemyDamages(this Midnight_Hougeki hougeki)
			=> hougeki?.api_damage?.GetEnemyDamages(hougeki.api_df_list)
			   ?? defaultValue;

		#endregion

		#region 航空戦

		public static FleetDamages GetFirstFleetDamages(this Api_Kouku kouku)
			=> kouku?.api_stage3?.api_fdam.GetDamages()
			   ?? defaultValue;

		public static FleetDamages GetSecondFleetDamages(this Api_Kouku kouku)
			=> kouku?.api_stage3_combined?.api_fdam?.GetDamages()
			   ?? defaultValue;

		public static FleetDamages GetEnemyDamages(this Api_Kouku kouku)
			=> kouku?.api_stage3?.api_edam?.GetDamages()
			   ?? defaultValue;

		public static FleetDamages GetSecondEnemyDamages(this Api_Kouku kouku)
			=> kouku?.api_stage3_combined?.api_edam?.GetDamages()
			   ?? defaultValue;

		public static AirSupremacy GetAirSupremacy(this Api_Kouku kouku)
			=> (AirSupremacy)(kouku?.api_stage1?.api_disp_seiku ?? (int)AirSupremacy.항공전없음);

		public static AirCombatResult[] ToResult(this Api_Kouku kouku, string prefixName = "")
		{
			return kouku != null
				? new []
				{
					kouku.api_stage1.ToResult($"{prefixName}공대공"),
					kouku.api_stage2.ToResult($"{prefixName}공대함")
				}
				: new AirCombatResult[0];
		}

		public static AirCombatResult ToResult(this Api_Stage1 stage1, string name)
			=> stage1 == null ? new AirCombatResult(name)
			: new AirCombatResult(name, stage1.api_f_count, stage1.api_f_lostcount, stage1.api_e_count, stage1.api_e_lostcount);

		public static AirCombatResult ToResult(this Api_Stage2 stage2, string name)
			=> stage2 == null ? new AirCombatResult(name)
			: new AirCombatResult(name, stage2.api_f_count, stage2.api_f_lostcount, stage2.api_e_count, stage2.api_e_lostcount);

		#endregion

		#region 기지항공대

		public static FleetDamages GetEnemyDamages(this Api_Air_Base_Attack[] attacks)
			=> attacks?.Select(x => x?.api_stage3?.api_edam?.GetDamages() ?? defaultValue)
			?.Aggregate((a, b) => a.Add(b)) ?? defaultValue;

		public static FleetDamages GetEachFirstEnemyDamages(this Api_Air_Base_Attack[] attacks)
			=> attacks?.Select(x => x?.api_stage3?.api_edam?.GetEachDamages() ?? defaultValue)
			?.Aggregate((a, b) => a.Add(b)) ?? defaultValue;

		public static FleetDamages GetEachSecondEnemyDamages(this Api_Air_Base_Attack[] attacks)
			=> attacks?.Select(x => x?.api_stage3?.api_edam?.GetEachDamages(true) ?? defaultValue)
			?.Aggregate((a, b) => a.Add(b)) ?? defaultValue;

		public static AirCombatResult[] ToResult(this Api_Air_Base_Attack[] attacks)
		{
			return attacks != null && Settings.Default.DetailKouku
				? attacks.SelectMany(x => new[] { x.api_stage1.ToResult($"제 {x.api_base_id}항공대 공대공"), x.api_stage2.ToResult($"제 {x.api_base_id}항공대 공대함") }).ToArray()
				: new AirCombatResult[0];
		}

		#endregion

		#region 雷撃戦

		public static FleetDamages GetFriendDamages(this Raigeki raigeki)
			=> raigeki?.api_fdam?.GetDamages()
			   ?? defaultValue;

		public static FleetDamages GetEnemyDamages(this Raigeki raigeki)
			=> raigeki?.api_edam?.GetDamages()
			   ?? defaultValue;

		public static FleetDamages GetEachFirstFriendDamages(this Raigeki raigeki)
			=> raigeki?.api_fdam?.GetEachDamages()
			   ?? defaultValue;

		public static FleetDamages GetEachSecondFriendDamages(this Raigeki raigeki)
			=> raigeki?.api_fdam?.GetEachDamages(true)
			   ?? defaultValue;

		public static FleetDamages GetEachFirstEnemyDamages(this Raigeki raigeki)
			=> raigeki?.api_edam?.GetEachDamages()
			   ?? defaultValue;

		public static FleetDamages GetEachSecondEnemyDamages(this Raigeki raigeki)
			=> raigeki?.api_edam?.GetEachDamages(true)
			   ?? defaultValue;

		#endregion

		#region ダメージ計算

		/// <summary>
		/// 12項目中先頭6項目取得
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="origin">ゴミ-1が付いてる場合1オリジン</param>
		/// <returns></returns>
		public static IEnumerable<T> GetFriendData<T>(this IEnumerable<T> source, int origin = 1)
			=> source.Skip(origin).Take(6);

		/// <summary>
		/// 12項目中末尾6項目取得
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="origin">ゴミ-1が付いてる場合1オリジン</param>
		/// <returns></returns>
		public static IEnumerable<T> GetEnemyData<T>(this IEnumerable<T> source, int origin = 1)
			=> source.Skip(origin + 6).Take(6);

		/// <summary>
		/// 24項目中先頭6項目取得
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="origin">ゴミ-1が付いてる場合1オリジン</param>
		/// <returns></returns>
		public static IEnumerable<T> GetEachFriendData<T>(this IEnumerable<T> source, int origin = 1)
			=> source.Skip(origin).Take(6);

		/// <summary>
		/// 24項目中末尾6項目取得
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <param name="origin">ゴミ-1が付いてる場合1オリジン</param>
		/// <returns></returns>
		public static IEnumerable<T> GetEachEnemyData<T>(this IEnumerable<T> source, int origin = 1)
			=> source.Skip(origin + 12).Take(6);

		/// <summary>
		/// 雷撃・航空戦ダメージリスト算出
		/// </summary>
		/// <param name="damages">api_fdam/api_edam</param>
		/// <returns></returns>
		public static FleetDamages GetDamages(this decimal[] damages)
			=> damages
				.GetFriendData() //敵味方共通
				.Select(Convert.ToInt32)
				.ToArray()
				.ToFleetDamages();

		/// <summary>
		/// 雷撃・航空戦ダメージリスト算出
		/// </summary>
		/// <param name="damages">api_fdam/api_edam</param>
		/// <returns></returns>
		public static FleetDamages GetEachDamages(this decimal[] damages, bool IsSecond = false)
			=> damages
				.GetFriendData(IsSecond ? 7 : 1) //敵味方共通
				.Select(Convert.ToInt32)
				.ToArray()
				.ToFleetDamages();

		#region 砲撃戦ダメージリスト算出

		/// <summary>
		/// 砲撃戦友軍ダメージリスト算出
		/// </summary>
		/// <param name="damages">api_damage</param>
		/// <param name="df_list">api_df_list</param>
		/// <returns></returns>
		public static FleetDamages GetFriendDamages(this object[] damages, object[] df_list)
			=> damages
				.ToIntArray()
				.ToSortedDamages(df_list.ToIntArray())
				.GetFriendData(0)
				.ToFleetDamages();

		/// <summary>
		/// 砲撃戦敵軍ダメージリスト算出
		/// </summary>
		/// <param name="damages">api_damage</param>
		/// <param name="df_list">api_df_list</param>
		/// <returns></returns>
		public static FleetDamages GetEnemyDamages(this object[] damages, object[] df_list)
			=> damages
				.ToIntArray()
				.ToSortedDamages(df_list.ToIntArray())
				.GetEnemyData(0)
				.ToFleetDamages();

		/// <summary>
		/// 심해연합함대와의 포격/지원 데미지 리스트 산출
		/// </summary>
		/// <param name="damages">api_damage</param>
		/// <param name="df_list">api_df_list</param>
		/// <returns></returns>
		public static FleetDamages GetEachFriendDamages(this object[] damages, object[] df_list, int[] at_eflag, bool IsSecond = false)
			=> damages
				.ToSortedDamages(df_list, at_eflag)
				.GetEachFriendData(IsSecond ? 6 : 0)
				.ToFleetDamages();

		/// <summary>
		/// 砲撃戦敵軍ダメージリスト算出
		/// </summary>
		/// <param name="damages">api_damage</param>
		/// <param name="df_list">api_df_list</param>
		/// <returns></returns>
		public static FleetDamages GetEachEnemyDamages(this object[] damages, object[] df_list, int[] at_eflag, bool IsSecond = false)
			=> damages
				.ToSortedDamages(df_list, at_eflag)
				.GetEachEnemyData(IsSecond ? 6 : 0)
				.ToFleetDamages();

		/// <summary>
		/// 砲撃戦ダメージリストint配列化
		/// 弾着観測射撃データはフラット化する
		/// api_df_listも同様の型なので流用可能
		/// </summary>
		/// <param name="damages">api_damage</param>
		/// <returns></returns>
		private static int[] ToIntArray(this object[] damages)
			=> damages
				.Where(x => x is Array)
				.Select(x => ((Array) x).Cast<object>())
				.SelectMany(x => x.Select(Convert.ToInt32))
				.ToArray();

		/// <summary>
		/// フラット化したapi_damageとapi_df_listを元に
		/// 自軍6隻＋敵軍6隻の長さ12のダメージ合計配列を作成
		/// </summary>
		/// <param name="damages">api_damage</param>
		/// <param name="dfList">api_df_list</param>
		/// <returns></returns>
		private static int[] ToSortedDamages(this int[] damages, int[] dfList)
		{
			var zip = damages.Zip(dfList, (da, df) => new {df, da});
			var ret = new int[12];
			foreach (var d in zip.Where(d => 0 < d.df))
			{
				ret[d.df - 1] += d.da;
			}
			return ret;
		}

		/// <summary>
		/// フラット化したapi_damageとapi_df_listを元に
		/// 自軍12隻＋敵軍12隻の長さ24のダメージ合計配列を作成
		/// </summary>
		/// <param name="damages">api_damage</param>
		/// <param name="dfList">api_df_list</param>
		/// <returns></returns>
		private static int[] ToSortedDamages(this object[] damages, object[] dfList, int[] at_eflag)
		{
			var zip = damages.Zip(dfList, (da, df) => new { df, da })
				.Zip(at_eflag, (dl, ef) => new { ef, dl.df, dl.da });

			var ret = new int[24];
			foreach (var d in zip.Where(d => d.ef == 1)) // Friend -> Enemy (ME)
			{
				if (d.df is Array)
				{
					var o = (d.df as object[]).Select(Convert.ToInt32).ToArray();
					for (var i = 0; i < o.Length; i++)
						ret[o[i] - 1] += (d.da as object[]).Select(Convert.ToInt32).ToArray()[i];
				}
				else
					ret[(int)d.df - 1] += (int)d.da;
			}
			foreach (var d in zip.Where(d => d.ef == 0)) // Enemy -> Friend (ME)
			{
				if (d.df is Array)
				{
					var o = (d.df as object[]).Select(Convert.ToInt32).ToArray();
					for (var i = 0; i < o.Length; i++)
						ret[o[i] + 12 - 1] += (d.da as object[]).Select(Convert.ToInt32).ToArray()[i];
				}
				else
					ret[(int)d.df + 12 - 1] += (int)d.da;
			}
			return ret;
		}

		#endregion

		#endregion
	}
}
