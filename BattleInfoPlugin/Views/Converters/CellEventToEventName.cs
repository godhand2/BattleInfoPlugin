using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BattleInfoPlugin.Views.Converters
{
	public class CellEventToEventName : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if(value is string)
			{
				int cellevent = int.Parse((string)value);
				switch (cellevent)
				{
					case 2:
						return "자원획득";
					case 3:
						return "소용돌이";
					case 4:
					case 31:
						return "적군조우";
					case 5:
						return "보스전";
					case 6:
						return "기분탓";
					case 10:
						return "공습전";
					default:
						return "";
				}
			}
			return "";
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
