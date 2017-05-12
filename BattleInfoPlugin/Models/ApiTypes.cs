using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleInfoPlugin.Models
{
	internal enum ApiTypes
	{
		sortie_battle,
		practice_battle,

		battle_midnight_battle,
		battle_midnight_sp_midnight,
		practice_midnight_battle,

		sortie_airbattle,
		sortie_ld_airbattle,

		combined_battle_battle,
		combined_battle_battle_water,

		combined_battle_ec_battle,
		combined_battle_each_battle,
		combined_battle_each_battle_water,

		combined_battle_airbattle,
		combined_battle_ld_airbattle,

		combined_battle_midnight_battle,
		combined_battle_sp_midnight,

		combined_battle_ec_midnight_battle,
	}
}
