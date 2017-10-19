using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleInfoPlugin.Models
{
	public enum AirFireFlag
	{
		Unset,
		Unused,
		Used,

		Used1,
		Used2,
		UsedAll
	}

	public static class AirFireFlagExtensions
	{
		public static string ToReadableString(this AirFireFlag flag)
		{
			switch (flag)
			{
				case AirFireFlag.Unused:
					return "発動しない";
				case AirFireFlag.Used:
					return "発動";

				case AirFireFlag.Used1:
					return "1次発動";
				case AirFireFlag.Used2:
					return "2次発動";
				case AirFireFlag.UsedAll:
					return "すべて発動";
				default:
					return "";
			}
		}
	}
}
