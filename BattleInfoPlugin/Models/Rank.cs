using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleInfoPlugin.Models
{
	public enum Rank
	{
		エラー = -1,
		なし = 0,

		完全勝利S = 1,
		S勝利 = 2,
		A勝利 = 3,
		B勝利 = 4,
		C敗北 = 5,
		D敗北 = 6,
		E敗北 = 7,
		空襲戦 = 8
	}

	public static class RankExtension
	{
		public static Rank ConvertRank(int rank)
		{
			switch (rank)
			{
				case 0: return Rank.E敗北;
				case 1: return Rank.D敗北;
				case 2: return Rank.C敗北;
				case 3: return Rank.B勝利;
				case 4: return Rank.A勝利;
				case 5: return Rank.S勝利;
				case 6: return Rank.完全勝利S;
			}
			return Rank.なし;
		}
		public static Rank ConvertRank(string rank)
		{
			switch (rank)
			{
				case "S": return Rank.S勝利;
				case "A": return Rank.A勝利;
				case "B": return Rank.B勝利;
				case "C": return Rank.C敗北;
				case "D": return Rank.D敗北;
				case "E": return Rank.E敗北;
			}
			return Rank.エラー;
		}
	}
}