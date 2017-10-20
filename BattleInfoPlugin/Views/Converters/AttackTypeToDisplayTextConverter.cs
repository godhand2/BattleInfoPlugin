using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using BattleInfoPlugin.Models;

namespace BattleInfoPlugin.Views.Converters
{
	public class AttackTypeToDisplayTextConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (!(value is AttackType)) return "";
			switch ((AttackType)value)
			{
				case AttackType.カットイン主主:
					return "カットイン (x1.5)";
				case AttackType.カットイン主徹:
					return "カットイン (x1.3)";
				case AttackType.カットイン主電:
					return "カットイン (x1.2)";
				case AttackType.カットイン主副:
					return "カットイン (x1.1)";
				case AttackType.カットイン主主主:
					return "カットイン (x2.0)";
				case AttackType.カットイン主主副:
					return "カットイン (x1.75)";
				case AttackType.カットイン主雷:
					return "カットイン (x1.3 x2)";
				case AttackType.連撃:
					return "連撃 (x1.2 x2)";
				case AttackType.カットイン雷:
					return "カットイン (x1.5 x2)";
				case AttackType.カットイン後期魚雷逆探:
					return "カットイン (x1.75 x2)";
				case AttackType.カットイン後期魚雷:
					return "カットイン (x1.6 x2)";
				case AttackType.カットイン艦戦艦爆艦攻:
					return "カットイン (1.25)";
				case AttackType.カットイン艦爆艦爆艦攻:
					return "カットイン (1.2)";
				case AttackType.カットイン艦爆艦攻:
					return "カットイン (1.15)";
				default:
					return "通常";
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
