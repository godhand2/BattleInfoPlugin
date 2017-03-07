using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleInfoPlugin.Models
{
	public class CellData
	{
		public string CellName { get; set; } = null;
		public string CellEvent { get; set; } = null;
		public string CellText { get; set; } = null;

		public bool IsOld { get; set; } = false;
	}
}
