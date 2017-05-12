using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleInfoPlugin.Models.Raw
{
	public class kcsapi_port : Grabacr07.KanColleWrapper.Models.Raw.kcsapi_port
	{
		public Api_Event_Object api_event_object { get; set; }
	}

	public class Api_Event_Object
	{
		public int api_m_flag { get; set; }
		public int api_m_flag2 { get; set; }
	}
}
