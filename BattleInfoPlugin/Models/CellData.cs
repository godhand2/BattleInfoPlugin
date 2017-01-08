using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleInfoPlugin.Models
{
	public class CellData
	{
		public string CellName { get; set; } = "";
		public string CellEvent { get; set; } = "";

		public bool IsOld { get; set; } = false;
	}
}
