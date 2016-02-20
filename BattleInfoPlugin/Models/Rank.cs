using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleInfoPlugin.Models
{
	public enum Rank
	{
		에러 = -1,
		완전승리S = 1,
		S승리 = 2,
		A승리 = 3,
		B승리 = 4,
		패배 = 5,
		없음 = 0,
		공습전 = 6,
	}
}