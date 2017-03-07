using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace BattleInfoPlugin.Views.Converters
{
	public class CellEventToEventColor: IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if(value is string)
			{
				int cellevent = int.Parse((string)value);
				switch (cellevent)
				{
					case -1:
						return "#FF8DC660";
					case 2:
						return "#FF3FBD2B";
					case 3:
						return "#FFA33CEA";
					case 4:
					case 31:
						return "#FFF01717";
					case 5:
						return "#FFD40C0C";
					case 6:
						return "#FF0A8AB9";
					case 10:
						return "#FF51A6C5";
					default:
						return "#48FFFFFF";
						// return "Transparent";
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
