using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleInfoPlugin.Models
{
	public enum AttackType
	{
		통상,             // 1.0
		연격,             // 1.2  * 2
		주주컷인,         // 1.5
		주철컷인,         // 1.3
		주전컷인,         // 1.2
		주부컷인,         // 1.1
		주주주컷인,       // 2.0
		주주부컷인,       // 1.75
		주뢰컷인,         // 1.3  * 2
		뇌격컷인,         // 1.5  * 2
		후기어뢰전탐컷인, // 1.75 * 2
		후기어뢰컷인,     // 1.6  * 2
	}
}
