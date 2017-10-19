using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleInfoPlugin.Models
{
	public enum UsedSupport
	{
		Unset,
		Unused,
		Hourai,
		Kouku
	}

	public static class UsedSupportExtensions
	{
		public static string ToReadableString(this UsedSupport flag)
		{
			switch (flag)
			{
				case UsedSupport.Unused:
					return "支援なし";
				case UsedSupport.Hourai:
					return "砲撃/雷撃";
				case UsedSupport.Kouku:
					return "航空支援";
				default:
					return "";
			}
		}
	}
}
