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
				case AttackType.주주컷인:
					return "컷인 (x1.5)";
				case AttackType.주철컷인:
					return "컷인 (x1.3)";
				case AttackType.주전컷인:
					return "컷인 (x1.2)";
				case AttackType.주부컷인:
					return "컷인 (x1.1)";
				case AttackType.주주주컷인:
					return "컷인 (x2.0)";
				case AttackType.주주부컷인:
					return "컷인 (x1.75)";
				case AttackType.주뢰컷인:
					return "컷인 (x1.3 x2)";
				case AttackType.연격:
					return "연격 (x1.2 x2)";
				case AttackType.뇌격컷인:
					return "컷인 (x1.5 x2)";
				case AttackType.후기어뢰전탐컷인:
					return "컷인 (x1.75 x2)";
				case AttackType.후기어뢰컷인:
					return "컷인 (x1.6 x2)";
				default:
					return "통상";
			}
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
