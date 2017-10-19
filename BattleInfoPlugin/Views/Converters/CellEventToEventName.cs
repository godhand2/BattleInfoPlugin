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
					case -1:
						return "演習";
					case 2:
						return "資源獲得";
					case 3:
						return "渦潮";
					case 4:
					case 31:
						return "敵遭遇";
					case 5:
						return "ボス戦";
					case 6:
						return "気のせい";
					case 10:
						return "空襲戦";
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
