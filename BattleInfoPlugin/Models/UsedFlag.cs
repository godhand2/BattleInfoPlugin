using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleInfoPlugin.Models
{
	public enum UsedFlag
	{
		Unset,
		Unused,
		Used,
		EnemyUsed,
		BothUsed
	}

	public static class UsedFlagExtensions
	{
		public static string ToReadableString(this UsedFlag flag)
		{
			switch (flag)
			{
				case UsedFlag.Unused:
					return "発動しない";
				case UsedFlag.Used:
					return "味方発動";
				case UsedFlag.EnemyUsed:
					return "敵発動";
				case UsedFlag.BothUsed:
					return "双方発動";
				default:
					return "";
			}
		}
	}
}
