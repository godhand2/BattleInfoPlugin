﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleInfoPlugin.Models
{
	public class MapAreaData
	{
		public static Dictionary<string, string> MapAreaTable = new Dictionary<string, string>
		{
			//해역 1-1
            {"1-1-1", "A"},
			{"1-1-2", "B"},
			{"1-1-3", "C"},
            //해역 1-2
            {"1-2-1", "A"},
			{"1-2-2", "C"},
			{"1-2-3", "B"},
			{"1-2-4", "D"},
            //해역 1-3
            {"1-3-1", "A"},
			{"1-3-2", "B"},
			{"1-3-3", "D"},
			{"1-3-4", "C"},
			{"1-3-5", "E"},
			{"1-3-6", "F"},
			{"1-3-7", "G"},
			{"1-3-8", "C"},
			{"1-3-9", "F"},
            //해역 1-4
            {"1-4-1", "A"},
			{"1-4-2", "B"},
			{"1-4-3", "G"},
			{"1-4-4", "C"},
			{"1-4-5", "H"},
			{"1-4-6", "D"},
			{"1-4-7", "E"},
			{"1-4-8", "I"},
			{"1-4-9", "J"},
			{"1-4-10", "F"},
			{"1-4-11", "C"},
			{"1-4-12", "F"},
			{"1-4-13", "F"},
            //해역 1-5
            {"1-5-1", "A"},
			{"1-5-2", "B"},
			{"1-5-3", "D"},
			{"1-5-4", "C"},
			{"1-5-5", "E"},
			{"1-5-6", "F"},
			{"1-5-7", "H"},
			{"1-5-8", "G"},
			{"1-5-9", "I"},
			{"1-5-10", "I"},
            //해역 1-6
            {"1-6-1", "A"},
			{"1-6-2", "C"},
			{"1-6-3", "E"},
			{"1-6-4", "G"},
			{"1-6-5", "H"},
			{"1-6-6", "K"},
			{"1-6-7", "M"},
			{"1-6-8", "L"},
			{"1-6-9", "J"},
			{"1-6-10", "I"},
			{"1-6-11", "D"},
			{"1-6-12", "F"},
			{"1-6-13", "B"},
			{"1-6-14", "N"},
			{"1-6-15", "K"},
			{"1-6-16", "D"},
			{"1-6-17", "N"},
            //해역 2-1
            {"2-1-1", "A"},
			{"2-1-2", "B"},
			{"2-1-3", "D"},
			{"2-1-4", "C"},
			{"2-1-5", "F"},
			{"2-1-6", "E"},
            //해역 2-2
            {"2-2-1", "A"},
			{"2-2-2", "E"},
			{"2-2-3", "B"},
			{"2-2-4", "G"},
			{"2-2-5", "C"},
			{"2-2-6", "D"},
			{"2-2-7", "F"},
			{"2-2-8", "E"},
            //해역 2-3
            {"2-3-1", "C"},
			{"2-3-2", "A"},
			{"2-3-3", "H"},
			{"2-3-4", "D"},
			{"2-3-5", "B"},
			{"2-3-6", "E"},
			{"2-3-7", "I"},
			{"2-3-8", "J"},
			{"2-3-9", "K"},
			{"2-3-10", "F"},
			{"2-3-11", "G"},
			{"2-3-12", "E"},
            //해역 2-4
            {"2-4-1", "A"},
			{"2-4-2", "K"},
			{"2-4-3", "F"},
			{"2-4-4", "B"},
			{"2-4-5", "C"},
			{"2-4-6", "D"},
			{"2-4-7", "E"},
			{"2-4-8", "L"},
			{"2-4-9", "M"},
			{"2-4-10", "N"},
			{"2-4-11", "G"},
			{"2-4-12", "I"},
			{"2-4-13", "H"},
			{"2-4-14", "O"},
			{"2-4-15", "P"},
			{"2-4-16", "J"},
			{"2-4-17", "J"},
			{"2-4-18", "J"},
			{"2-4-19", "G"},
            //해역 2-5
            {"2-5-1", "A"},
			{"2-5-2", "B"},
			{"2-5-3", "C"},
			{"2-5-4", "F"},
			{"2-5-5", "D"},
			{"2-5-6", "E"},
			{"2-5-7", "G"},
			{"2-5-8", "H"},
			{"2-5-9", "I"},
			{"2-5-10", "J"},
			{"2-5-11", "K"},
			{"2-5-12", "L"},
			{"2-5-13", "H"},
			{"2-5-14", "H"},
			{"2-5-15", "L"},
            //해역 3-1
            {"3-1-1", "D"},
			{"3-1-2", "A"},
			{"3-1-3", "F"},
			{"3-1-4", "B"},
			{"3-1-5", "C"},
			{"3-1-6", "E"},
            //해역 3-2
            {"3-2-1", "E"},
			{"3-2-2", "A"},
			{"3-2-3", "D"},
			{"3-2-4", "F"},
			{"3-2-5", "B"},
			{"3-2-6", "C"},
			{"3-2-7", "G"},
			{"3-2-8", "H"},
			{"3-2-9", "B"},
			{"3-2-10", "F"},
            //해역 3-3
            {"3-3-1", "A"},
			{"3-3-2", "B"},
			{"3-3-3", "E"},
			{"3-3-4", "H"},
			{"3-3-5", "C"},
			{"3-3-6", "F"},
			{"3-3-7", "I"},
			{"3-3-8", "D"},
			{"3-3-9", "K"},
			{"3-3-10", "J"},
			{"3-3-11", "G"},
			{"3-3-12", "I"},
			{"3-3-13", "G"},
            //해역 3-4
            {"3-4-1", "A"},
			{"3-4-2", "J"},
			{"3-4-3", "K"},
			{"3-4-4", "B"},
			{"3-4-5", "F"},
			{"3-4-6", "L"},
			{"3-4-7", "G"},
			{"3-4-8", "M"},
			{"3-4-9", "C"},
			{"3-4-10", "H"},
			{"3-4-11", "N"},
			{"3-4-12", "D"},
			{"3-4-13", "I"},
			{"3-4-14", "O"},
			{"3-4-15", "E"},
			{"3-4-16", "F"},
			{"3-4-17", "L"},
			{"3-4-18", "H"},
			{"3-4-19", "H"},
			{"3-4-20", "E"},
            //해역 3-5
            {"3-5-1", "A"},
			{"3-5-2", "H"},
			{"3-5-3", "D"},
			{"3-5-4", "C"},
			{"3-5-5", "E"},
			{"3-5-6", "B"},
			{"3-5-7", "G"},
			{"3-5-8", "F"},
			{"3-5-9", "I"},
			{"3-5-10", "J"},
			{"3-5-11", "K"},
			{"3-5-12", "E"},
			{"3-5-13", "B"},
			{"3-5-14", "F"},
			{"3-5-15", "K"},
            //해역 4-1
            {"4-1-1", "E"},
			{"4-1-2", "A"},
			{"4-1-3", "H"},
			{"4-1-4", "F"},
			{"4-1-5", "I"},
			{"4-1-6", "B"},
			{"4-1-7", "G"},
			{"4-1-8", "C"},
			{"4-1-9", "D"},
			{"4-1-10", "I"},
			{"4-1-11", "I"},
			{"4-1-12", "D"},
            //해역 4-2
            {"4-2-1", "F"},
			{"4-2-2", "A"},
			{"4-2-3", "B"},
			{"4-2-4", "G"},
			{"4-2-5", "E"},
			{"4-2-6", "C"},
			{"4-2-7", "H"},
			{"4-2-8", "I"},
			{"4-2-9", "D"},
			{"4-2-10", "E"},
			{"4-2-11", "H"},
			{"4-2-12", "H"},
			{"4-2-13", "D"},
            //해역 4-3
            {"4-3-1", "J"},
			{"4-3-2", "A"},
			{"4-3-3", "B"},
			{"4-3-4", "F"},
			{"4-3-5", "K"},
			{"4-3-6", "C"},
			{"4-3-7", "D"},
			{"4-3-8", "G"},
			{"4-3-9", "H"},
			{"4-3-10", "L"},
			{"4-3-11", "E"},
			{"4-3-12", "M"},
			{"4-3-13", "I"},
			{"4-3-14", "F"},
			{"4-3-15", "F"},
			{"4-3-16", "K"},
			{"4-3-17", "D"},
			{"4-3-18", "D"},
			{"4-3-19", "G"},
			{"4-3-20", "G"},
			{"4-3-21", "L"},
            //해역 4-4
            {"4-4-1", "A"},
			{"4-4-2", "B"},
			{"4-4-3", "I"},
			{"4-4-4", "F"},
			{"4-4-5", "C"},
			{"4-4-6", "D"},
			{"4-4-7", "G"},
			{"4-4-8", "J"},
			{"4-4-9", "E"},
			{"4-4-10", "H"},
			{"4-4-11", "C"},
			{"4-4-12", "G"},
			{"4-4-13", "G"},
			{"4-4-14", "J"},
            //해역 4-5
            {"4-5-1", "A"},
			{"4-5-2", "B"},
			{"4-5-3", "D"},
			{"4-5-4", "C"},
			{"4-5-5", "E"},
			{"4-5-6", "F"},
			{"4-5-7", "G"},
			{"4-5-8", "H"},
			{"4-5-9", "I"},
			{"4-5-10", "J"},
			{"4-5-11", "L"},
			{"4-5-12", "K"},
			{"4-5-13", "M"},
			{"4-5-14", "C"},
			{"4-5-15", "F"},
			{"4-5-16", "F"},
			{"4-5-17", "H"},
			{"4-5-18", "J"},
			{"4-5-19", "M"},
            //해역 5-1
            {"5-1-1", "B"},
			{"5-1-2", "A"},
			{"5-1-3", "D"},
			{"5-1-4", "C"},
			{"5-1-5", "F"},
			{"5-1-6", "E"},
			{"5-1-7", "H"},
			{"5-1-8", "G"},
			{"5-1-9", "I"},
			{"5-1-10", "F"},
			{"5-1-11", "E"},
			{"5-1-12", "H"},
            //해역 5-2
            {"5-2-1", "A"},
			{"5-2-2", "B"},
			{"5-2-3", "F"},
			{"5-2-4", "G"},
			{"5-2-5", "E"},
			{"5-2-6", "C"},
			{"5-2-7", "I"},
			{"5-2-10", "D"},
			{"5-2-11", "G"},
			{"5-2-12", "H"},
			{"5-2-13", "J"},
			{"5-2-14", "D"},
            //해역 5-3
            {"5-3-1", "A"},
			{"5-3-2", "B"},
			{"5-3-3", "C"},
			{"5-3-4", "D"},
			{"5-3-5", "E"},
			{"5-3-6", "F"},
			{"5-3-7", "G"},
			{"5-3-8", "H"},
			{"5-3-9", "I"},
			{"5-3-10", "J"},
			{"5-3-11", "K"},
			{"5-3-12", "D"},
			{"5-3-13", "I"},
			{"5-3-14", "I"},
            //해역 5-4
            {"5-4-1", "A"},
			{"5-4-2", "B"},
			{"5-4-3", "C"},
			{"5-4-4", "F"},
			{"5-4-6", "I"},
			{"5-4-7", "E"},
			{"5-4-8", "D"},
			{"5-4-9", "L"},
			{"5-4-10", "N"},
			{"5-4-12", "H"},
			{"5-4-13", "K"},
			{"5-4-14", "J"},
			{"5-4-15", "O"},
			{"5-4-17", "H"},
			{"5-4-18", "M"},
			{"5-4-19", "O"},
			{"5-4-20", "O"},
            //해역 5-5
            {"5-5-1", "B"},
			{"5-5-2", "A"},
			{"5-5-3", "F"},
			{"5-5-4", "C"},
			{"5-5-5", "D"},
			{"5-5-10", "G"},
			{"5-5-12", "E"},
			{"5-5-13", "L"},
			{"5-5-14", "N"},
			{"5-5-17", "E"},
			{"5-5-18", "N"},
            //해역 6-1
            {"6-1-1", "G"},
			{"6-1-2", "A"},
			{"6-1-3", "B"},
			{"6-1-4", "C"},
			{"6-1-5", "D"},
			{"6-1-6", "E"},
			{"6-1-7", "H"},
			{"6-1-8", "F"},
			{"6-1-9", "I"},
			{"6-1-10", "J"},
			{"6-1-11", "K"},
			{"6-1-12", "D"},
			{"6-1-13", "D"},
            //해역 6-2
            {"6-2-1", "A"},
			{"6-2-2", "B"},
			{"6-2-3", "C"},
			{"6-2-4", "D"},
			{"6-2-5", "E"},
			{"6-2-6", "F"},
			{"6-2-7", "G"},
			{"6-2-8", "E"},
			{"6-2-9", "H"},
			{"6-2-10", "I"},
			{"6-2-11", "K"},
			{"6-2-12", "B"},
			{"6-2-13", "D"},
			{"6-2-14", "E"},
			{"6-2-15", "J"},
			{"6-2-16", "H"},
			{"6-2-17", "K"},
			{"6-2-18", "K"},
            //해역 6-3
            {"6-3-1", "A"},
			{"6-3-2", "B"},
			{"6-3-3", "C"},
			{"6-3-4", "D"},
			{"6-3-5", "E"},
			{"6-3-6", "F"},
			{"6-3-7", "G"},
			{"6-3-8", "H"},
			{"6-3-9", "I"},
			{"6-3-10", "J"},
			{"6-3-11", "E"},
			{"6-3-12", "H"},
            //해역 6-4
            {"6-4-1", "A"},
			{"6-4-2", "B"},
			{"6-4-3", "C"},
			{"6-4-4", "D"},
			{"6-4-5", "E"},
			{"6-4-6", "F"},
			{"6-4-7", "G"},
			{"6-4-8", "K"},
			{"6-4-9", "I"},
			{"6-4-10", "J"},
			{"6-4-11", "K"},
			{"6-4-12", "L"},
			{"6-4-13", "M"},
			{"6-4-14", "N"},
			{"6-4-15", "D"},
			{"6-4-16", "D"},
			{"6-4-17", "D"},
			{"6-4-18", "J"},
			{"6-4-19", "I"},
			{"6-4-20", "N"},
			{"6-4-21", "N"},
            //해역 31-1
            {"31-1-1", "A"},
			{"31-1-2", "B"},
			{"31-1-3", "C"},
			{"31-1-4", "D"},
			{"31-1-5", "E"},
			{"31-1-6", "F"},
			{"31-1-7", "G"},
			{"31-1-8", "Z"},
			{"31-1-9", "D"},
			{"31-1-10", "Z"},
            //해역 31-2
            {"31-2-1", "A"},
			{"31-2-2", "B"},
			{"31-2-3", "C"},
			{"31-2-4", "D"},
			{"31-2-5", "E"},
			{"31-2-6", "F"},
			{"31-2-7", "G"},
			{"31-2-8", "H"},
			{"31-2-9", "I"},
			{"31-2-10", "J"},
			{"31-2-13", "Z"},
			{"31-2-14", "G"},
			{"31-2-15", "H"},
			{"31-2-17", "Z"},
            //해역 31-3
            {"31-3-1", "A"},
			{"31-3-2", "B"},
			{"31-3-3", "C"},
			{"31-3-4", "D"},
			{"31-3-5", "E"},
			{"31-3-6", "F"},
			{"31-3-7", "G"},
			{"31-3-8", "H"},
			{"31-3-9", "I"},
			{"31-3-11", "X"},
			{"31-3-12", "Z"},
			{"31-3-13", "D"},
			{"31-3-14", "E"},
			{"31-3-16", "Z"},
            //해역 31-4
            {"31-4-1", "A"},
			{"31-4-2", "B"},
			{"31-4-3", "C"},
			{"31-4-4", "D"},
			{"31-4-5", "E"},
			{"31-4-6", "F"},
			{"31-4-7", "G"},
			{"31-4-8", "H"},
			{"31-4-9", "I"},
			{"31-4-10", "J"},
			{"31-4-13", "Z"},
			{"31-4-14", "E"},
			{"31-4-15", "H"},
			{"31-4-16", "H"},
			{"31-4-18", "Z"},
            //해역 31-5
            {"31-5-1", "A"},
			{"31-5-2", "B"},
			{"31-5-3", "C"},
			{"31-5-4", "D"},
			{"31-5-5", "E"},
			{"31-5-6", "F"},
			{"31-5-8", "H"},
			{"31-5-9", "I"},
			{"31-5-10", "J"},
			{"31-5-11", "K"},
			{"31-5-14", "Z"},
			{"31-5-15", "C"},
			{"31-5-16", "F"},
            //해역 31-6
            {"31-6-1", "A"},
			{"31-6-3", "C"},
			{"31-6-4", "D"},
			{"31-6-5", "E"},
			{"31-6-7", "G"},
			{"31-6-8", "H"},
			{"31-6-10", "J"},
			{"31-6-11", "K"},
			{"31-6-12", "L"},
			{"31-6-13", "M"},
			{"31-6-15", "O"},
			{"31-6-17", "Z"},
			{"31-6-19", "J"},
			{"31-6-20", "F"},
			{"31-6-22", "Z"},
            //해역 31-7
            {"31-7-1", "A"},
			{"31-7-2", "B"},
			{"31-7-3", "C"},
			{"31-7-4", "D"},
			{"31-7-5", "E"},
			{"31-7-6", "F"},
			{"31-7-7", "G"},
			{"31-7-8", "H"},
			{"31-7-9", "I"},
			{"31-7-10", "J"},
			{"31-7-11", "K"},
			{"31-7-12", "L"},
			{"31-7-13", "M"},
			{"31-7-17", "X"},
			{"31-7-18", "Y"},
			{"31-7-19", "Z"},
			{"31-7-20", "G"},
			{"31-7-21", "J"},
			{"31-7-22", "L"},
			{"31-7-23", "M"},
			{"31-7-25", "Y"},
			{"31-7-26", "Z"},
            //해역 32-1
            {"32-1-1", "A"},
			{"32-1-2", "B"},
			{"32-1-3", "C"},
			{"32-1-4", "D"},
			{"32-1-5", "E"},
			{"32-1-6", "F"},
			{"32-1-7", "I"},
			{"32-1-8", "H"},
			{"32-1-9", "G"},
			{"32-1-10", "J"},
			{"32-1-11", "C"},
			{"32-1-12", "F"},
			{"32-1-13", "H"},
			{"32-1-14", "J"},
            //해역 32-2
            {"32-2-1", "A"},
			{"32-2-2", "B"},
			{"32-2-3", "C"},
			{"32-2-4", "D"},
			{"32-2-5", "E"},
			{"32-2-6", "F"},
			{"32-2-7", "H"},
			{"32-2-8", "G"},
			{"32-2-9", "I"},
			{"32-2-10", "J"},
			{"32-2-11", "K"},
			{"32-2-12", "E"},
			{"32-2-13", "F"},
			{"32-2-14", "G"},
			{"32-2-15", "I"},
			{"32-2-16", "I"},
			{"32-2-17", "K"},
            //해역 32-3
            {"32-3-1", "A"},
			{"32-3-2", "B"},
			{"32-3-3", "C"},
			{"32-3-4", "D"},
			{"32-3-5", "E"},
			{"32-3-6", "F"},
			{"32-3-7", "G"},
			{"32-3-8", "H"},
			{"32-3-9", "I"},
			{"32-3-10", "J"},
			{"32-3-11", "K"},
			{"32-3-12", "E"},
			{"32-3-13", "G"},
            //해역 32-4
            {"32-4-1", "A"},
			{"32-4-2", "B"},
			{"32-4-3", "C"},
			{"32-4-4", "D"},
			{"32-4-5", "E"},
			{"32-4-6", "F"},
			{"32-4-7", "G"},
			{"32-4-8", "H"},
			{"32-4-9", "I"},
			{"32-4-10", "J"},
			{"32-4-11", "K"},
			{"32-4-12", "L"},
			{"32-4-13", "M"},
			{"32-4-14", "N"},
			{"32-4-15", "O"},
			{"32-4-16", "E"},
			{"32-4-17", "F"},
			{"32-4-18", "I"},
			{"32-4-19", "K"},
            //해역 32-5
            {"32-5-1", "A"},
			{"32-5-2", "B"},
			{"32-5-3", "C"},
			{"32-5-5", "E"},
			{"32-5-6", "F"},
			{"32-5-7", "G"},
			{"32-5-8", "H"},
			{"32-5-9", "I"},
			{"32-5-10", "J"},
			{"32-5-11", "K"},
			{"32-5-12", "L"},
			{"32-5-13", "M"},
			{"32-5-14", "N"},
			{"32-5-19", "J"},
            //해역 33-1
            {"33-1-1", "A"},
			{"33-1-2", "B"},
			{"33-1-3", "C"},
			{"33-1-4", "D"},
			{"33-1-5", "E"},
			{"33-1-6", "F"},
			{"33-1-7", "G"},
			{"33-1-8", "H"},
			{"33-1-9", "I"},
			{"33-1-10", "J"},
			{"33-1-11", "D"},
			{"33-1-12", "F"},
            //해역 33-2
            {"33-2-1", "A"},
			{"33-2-2", "B"},
			{"33-2-3", "C"},
			{"33-2-4", "D"},
			{"33-2-5", "E"},
			{"33-2-6", "F"},
			{"33-2-7", "G"},
			{"33-2-8", "H"},
			{"33-2-9", "I"},
			{"33-2-10", "J"},
			{"33-2-11", "K"},
			{"33-2-12", "L"},
			{"33-2-13", "M"},
			{"33-2-14", "N"},
			{"33-2-15", "O"},
			{"33-2-16", "F"},
			{"33-2-17", "G"},
			{"33-2-18", "J"},
			{"33-2-19", "L"},
			{"33-2-20", "M"},
			{"33-2-21", "O"},
            //해역 33-3
            {"33-3-1", "A"},
			{"33-3-2", "B"},
			{"33-3-3", "C"},
			{"33-3-4", "D"},
			{"33-3-5", "E"},
			{"33-3-6", "F"},
			{"33-3-7", "G"},
			{"33-3-8", "H"},
			{"33-3-9", "I"},
			{"33-3-10", "J"},
			{"33-3-11", "K"},
			{"33-3-12", "L"},
			{"33-3-13", "M"},
			{"33-3-14", "N"},
			{"33-3-16", "P"},
			{"33-3-17", "Q"},
			{"33-3-19", "S"},
			{"33-3-20", "T"},
			{"33-3-21", "D"},
			{"33-3-22", "I"},
			{"33-3-24", "T"}
		};
	}
}


/*//해역 1-1
			{"1-1-1", "Start -> A"},
			{"1-1-2", "A -> B"},
			{"1-1-3", "A -> C"},
			//해역 1-2
			{"1-2-1", "Start -> A"},
			{"1-2-2", "Start -> C"},
			{"1-2-3", "A -> B"},
			{"1-2-4", "C -> D"},
			//해역 1-3
			{"1-3-1", "Start -> A"},
			{"1-3-2", "Start -> B"},
			{"1-3-3", "A -> D"},
			{"1-3-4", "B -> C"},
			{"1-3-5", "B -> E"},
			{"1-3-6", "C -> F"},
			{"1-3-7", "D -> G"},
			{"1-3-8", "D -> C"},
			{"1-3-9", "E -> F"},
			//해역 1-4
			{"1-4-1", "Start -> A"},
			{"1-4-2", "Start -> B"},
			{"1-4-3", "Start -> G"},
			{"1-4-4", "A -> C"},
			{"1-4-5", "G -> H"},
			{"1-4-6", "C -> D"},
			{"1-4-7", "C -> E"},
			{"1-4-8", "H -> I"},
			{"1-4-9", "I -> J"},
			{"1-4-10", "D -> F"},
			{"1-4-11", "B -> C"},
			{"1-4-12", "E -> F"},
			{"1-4-13", "I -> F"},
			//해역 1-5
			{"1-5-1", "Start -> A"},
			{"1-5-2", "A -> B"},
			{"1-5-3", "B -> D"},
			{"1-5-4", "B -> C"},
			{"1-5-5", "C -> E"},
			{"1-5-6", "C -> F"},
			{"1-5-7", "D -> H"},
			{"1-5-8", "E -> G"},
			{"1-5-9", "D -> I"},
			{"1-5-10", "E -> I"},
			//해역 1-6
			{"1-6-1", "Start -> A"},
			{"1-6-2", "Start -> C"},
			{"1-6-3", "A -> E"},
			{"1-6-4", "E -> G"},
			{"1-6-5", "C -> H"},
			{"1-6-6", "G -> K"},
			{"1-6-7", "K -> M"},
			{"1-6-8", "M -> L"},
			{"1-6-9", "M -> J"},
			{"1-6-10", "L -> I"},
			{"1-6-11", "J -> D"},
			{"1-6-12", "G -> F"},
			{"1-6-13", "F -> B"},
			{"1-6-14", "D -> N"},
			{"1-6-15", "H -> K"},
			{"1-6-16", "I -> D"},
			{"1-6-17", "B -> N"},
			//해역 2-1
			{"2-1-1", "Start -> A"},
			{"2-1-2", "A -> B"},
			{"2-1-3", "A -> D"},
			{"2-1-4", "B -> C"},
			{"2-1-5", "D -> F"},
			{"2-1-6", "D -> E"},
			//해역 2-2
			{"2-2-1", "Start -> A"},
			{"2-2-2", "Start -> E"},
			{"2-2-3", "A -> B"},
			{"2-2-4", "E -> G"},
			{"2-2-5", "B -> C"},
			{"2-2-6", "B -> D"},
			{"2-2-7", "E -> F"},
			{"2-2-8", "A -> E"},
			//해역 2-3
			{"2-3-1", "Start -> C"},
			{"2-3-2", "Start -> A"},
			{"2-3-3", "C -> H"},
			{"2-3-4", "C -> D"},
			{"2-3-5", "A -> B"},
			{"2-3-6", "D -> E"},
			{"2-3-7", "H -> I"},
			{"2-3-8", "I -> J"},
			{"2-3-9", "I -> K"},
			{"2-3-10", "E -> F"},
			{"2-3-11", "E -> G"},
			{"2-3-12", "B -> E"},
			//해역 2-4
			{"2-4-1", "Start -> A"},
			{"2-4-2", "A -> K"},
			{"2-4-3", "A -> F"},
			{"2-4-4", "A -> B"},
			{"2-4-5", "B -> C"},
			{"2-4-6", "C -> D"},
			{"2-4-7", "D -> E"},
			{"2-4-8", "K -> L"},
			{"2-4-9", "L -> M"},
			{"2-4-10", "M -> N"},
			{"2-4-11", "F -> G"},
			{"2-4-12", "G -> I"},
			{"2-4-13", "G -> H"},
			{"2-4-14", "L -> O"},
			{"2-4-15", "O -> P"},
			{"2-4-16", "I -> J"},
			{"2-4-17", "H -> J"},
			{"2-4-18", "O -> J"},
			{"2-4-19", "D -> G"},
			//해역 2-5
			{"2-5-1", "Start -> A"},
			{"2-5-2", "Start -> B"},
			{"2-5-3", "A -> C"},
			{"2-5-4", "B -> F"},
			{"2-5-5", "A -> D"},
			{"2-5-6", "B -> E"},
			{"2-5-7", "D -> G"},
			{"2-5-8", "D -> H"},
			{"2-5-9", "E -> I"},
			{"2-5-10", "H -> J"},
			{"2-5-11", "I -> K"},
			{"2-5-12", "H -> L"},
			{"2-5-13", "E -> H"},
			{"2-5-14", "I -> H"},
			{"2-5-15", "I -> L"},
			//해역 3-1
			{"3-1-1", "Start -> D"},
			{"3-1-2", "Start -> A"},
			{"3-1-3", "D -> F"},
			{"3-1-4", "A -> B"},
			{"3-1-5", "A -> C"},
			{"3-1-6", "D -> E"},
			//해역 3-2
			{"3-2-1", "Start -> E"},
			{"3-2-2", "Start -> A"},
			{"3-2-3", "Start -> D"},
			{"3-2-4", "E -> F"},
			{"3-2-5", "A -> B"},
			{"3-2-6", "B -> C"},
			{"3-2-7", "F -> G"},
			{"3-2-8", "F -> H"},
			{"3-2-9", "D -> B"},
			{"3-2-10", "D -> F"},
			//해역 3-3
			{"3-3-1", "Start -> A"},
			{"3-3-2", "A -> B"},
			{"3-3-3", "A -> E"},
			{"3-3-4", "A -> H"},
			{"3-3-5", "B -> C"},
			{"3-3-6", "E -> F"},
			{"3-3-7", "E -> I"},
			{"3-3-8", "C -> D"},
			{"3-3-9", "I -> K"},
			{"3-3-10", "I -> J"},
			{"3-3-11", "F -> G"},
			{"3-3-12", "H -> I"},
			{"3-3-13", "I -> G"},
			//해역 3-4
			{"3-4-1", "Start -> A"},
			{"3-4-2", "Start -> J"},
			{"3-4-3", "Start -> K"},
			{"3-4-4", "A -> B"},
			{"3-4-5", "A -> F"},
			{"3-4-6", "J -> L"},
			{"3-4-7", "F -> G"},
			{"3-4-8", "L -> M"},
			{"3-4-9", "B -> C"},
			{"3-4-10", "G -> H"},
			{"3-4-11", "M -> N"},
			{"3-4-12", "C -> D"},
			{"3-4-13", "H -> I"},
			{"3-4-14", "N -> O"},
			{"3-4-15", "H -> E"},
			{"3-4-16", "J -> F"},
			{"3-4-17", "K -> L"},
			{"3-4-18", "M -> H"},
			{"3-4-19", "C -> H"},
			{"3-4-20", "D -> E"},
			//해역 3-5
			{"3-5-1", "Start -> A"},
			{"3-5-2", "A -> H"},
			{"3-5-3", "A -> D"},
			{"3-5-4", "A -> C"},
			{"3-5-5", "A -> E"},
			{"3-5-6", "Start -> B"},
			{"3-5-7", "B -> G"},
			{"3-5-8", "C -> F"},
			{"3-5-9", "F -> I"},
			{"3-5-10", "G -> J"},
			{"3-5-11", "G -> K"},
			{"3-5-12", "B -> E"},
			{"3-5-13", "D -> B"},
			{"3-5-14", "E -> F"},
			{"3-5-15", "F -> K"},
			//해역 4-1
			{"4-1-1", "Start -> E"},
			{"4-1-2", "Start -> A"},
			{"4-1-3", "E -> H"},
			{"4-1-4", "E -> F"},
			{"4-1-5", "H -> I"},
			{"4-1-6", "A -> B"},
			{"4-1-7", "F -> G"},
			{"4-1-8", "B -> C"},
			{"4-1-9", "G -> D"},
			{"4-1-10", "F -> I"},
			{"4-1-11", "G -> I"},
			{"4-1-12", "B -> D"},
			//해역 4-2
			{"4-2-1", "Start -> F"},
			{"4-2-2", "Start -> A"},
			{"4-2-3", "A -> B"},
			{"4-2-4", "F -> G"},
			{"4-2-5", "F -> E"},
			{"4-2-6", "B -> C"},
			{"4-2-7", "G -> H"},
			{"4-2-8", "H -> I"},
			{"4-2-9", "C -> D"},
			{"4-2-10", "A -> E"},
			{"4-2-11", "E -> H"},
			{"4-2-12", "C -> H"},
			{"4-2-13", "H -> D"},
			//해역 4-3
			{"4-3-1", "Start -> J"},
			{"4-3-2", "Start -> A"},
			{"4-3-3", "A -> B"},
			{"4-3-4", "J -> F"},
			{"4-3-5", "J -> K"},
			{"4-3-6", "B -> C"},
			{"4-3-7", "F -> D"},
			{"4-3-8", "F -> G"},
			{"4-3-9", "G -> H"},
			{"4-3-10", "K -> L"},
			{"4-3-11", "D -> E"},
			{"4-3-12", "L -> M"},
			{"4-3-13", "G -> I"},
			{"4-3-14", "Start -> F"},
			{"4-3-15", "B -> F"},
			{"4-3-16", "F -> K"},
			{"4-3-17", "C -> D"},
			{"4-3-18", "B -> D"},
			{"4-3-19", "D -> G"},
			{"4-3-20", "K -> G"},
			{"4-3-21", "G -> L"},
			//해역 4-4
			{"4-4-1", "Start -> A"},
			{"4-4-2", "A -> B"},
			{"4-4-3", "A -> I"},
			{"4-4-4", "A -> F"},
			{"4-4-5", "B -> C"},
			{"4-4-6", "C -> D"},
			{"4-4-7", "C -> G"},
			{"4-4-8", "I -> J"},
			{"4-4-9", "C -> E"},
			{"4-4-10", "G -> H"},
			{"4-4-11", "F -> C"},
			{"4-4-12", "F -> G"},
			{"4-4-13", "I -> G"},
			{"4-4-14", "G -> J"},
			//해역 4-5
			{"4-5-1", "Start -> A"},
			{"4-5-2", "Start -> B"},
			{"4-5-3", "A -> D"},
			{"4-5-4", "A -> C"},
			{"4-5-5", "B -> E"},
			{"4-5-6", "C -> F"},
			{"4-5-7", "D -> G"},
			{"4-5-8", "E -> H"},
			{"4-5-9", "G -> I"},
			{"4-5-10", "F -> J"},
			{"4-5-11", "J -> L"},
			{"4-5-12", "H -> K"},
			{"4-5-13", "H -> M"},
			{"4-5-14", "B -> C"},
			{"4-5-15", "G -> F"},
			{"4-5-16", "I -> F"},
			{"4-5-17", "F -> H"},
			{"4-5-18", "I -> J"},
			{"4-5-19", "J -> M"},
			//해역 5-1
			{"5-1-1", "Start -> B"},
			{"5-1-2", "Start -> A"},
			{"5-1-3", "B -> D"},
			{"5-1-4", "A -> C"},
			{"5-1-5", "A -> F"},
			{"5-1-6", "C -> E"},
			{"5-1-7", "C -> H"},
			{"5-1-8", "E -> G"},
			{"5-1-9", "H -> I"},
			{"5-1-10", "D -> F"},
			{"5-1-11", "H -> E"},
			{"5-1-12", "F -> H"},
			//해역 5-2
			{"5-2-1", "Start -> A"},
			{"5-2-2", "A -> B"},
			{"5-2-3", "A -> F"},
			{"5-2-4", "B -> G"},
			{"5-2-5", "G -> E"},
			{"5-2-6", "B -> C"},
			{"5-2-7", "F -> I"},
			{"5-2-10", "E -> D"},
			{"5-2-11", "F -> G"},
			{"5-2-12", "I -> H"},
			{"5-2-13", "H -> J"},
			{"5-2-14", "C -> D"},
			//해역 5-3
			{"5-3-1", "Start -> A"},
			{"5-3-2", "A -> B"},
			{"5-3-3", "A -> C"},
			{"5-3-4", "B -> D"},
			{"5-3-5", "D -> E"},
			{"5-3-6", "D -> F"},
			{"5-3-7", "F -> G"},
			{"5-3-8", "G -> H"},
			{"5-3-9", "D -> I"},
			{"5-3-10", "I -> J"},
			{"5-3-11", "I -> K"},
			{"5-3-12", "C -> D"},
			{"5-3-13", "G -> I"},
			{"5-3-14", "H -> I"},
			//해역 5-4
			{"5-4-1", "Start -> A"},
			{"5-4-2", "Start -> B"},
			{"5-4-3", "Start -> C"},
			{"5-4-4", "B -> F"},
			{"5-4-6", "F -> I"},
			{"5-4-7", "A -> E"},
			{"5-4-8", "A -> D"},
			{"5-4-9", "I -> L"},
			{"5-4-10", "L -> N"},
			{"5-4-12", "E -> H"},
			{"5-4-13", "H -> K"},
			{"5-4-14", "H -> J"},
			{"5-4-15", "N -> O"},
			{"5-4-17", "D -> H"},
			{"5-4-18", "H -> M"},
			{"5-4-19", "M -> O"},
			{"5-4-20", "K -> O"},
			//해역 5-5
			{"5-5-1", "Start -> B"},
			{"5-5-2", "Start -> A"},
			{"5-5-3", "A -> F"},
			{"5-5-4", "A -> C"},
			{"5-5-5", "A -> D"},
			{"5-5-10", "F -> G"},
			{"5-5-12", "C -> E"},
			{"5-5-13", "E -> L"},
			{"5-5-14", "G -> N"},
			{"5-5-17", "D -> E"},
			{"5-5-18", "E -> N"},
			//해역 6-1
			{"6-1-1", "Start -> G"},
			{"6-1-2", "Start -> A"},
			{"6-1-3", "Start -> B"},
			{"6-1-4", "A -> C"},
			{"6-1-5", "A -> D"},
			{"6-1-6", "D -> E"},
			{"6-1-7", "E -> H"},
			{"6-1-8", "E -> F"},
			{"6-1-9", "F -> I"},
			{"6-1-10", "F -> J"},
			{"6-1-11", "F -> K"},
			{"6-1-12", "B -> D"},
			{"6-1-13", "C -> D"},
			//해역 6-2
			{"6-2-1", "Start -> A"},
			{"6-2-2", "Start -> B"},
			{"6-2-3", "B -> C"},
			{"6-2-4", "A -> D"},
			{"6-2-5", "D -> E"},
			{"6-2-6", "B -> F"},
			{"6-2-7", "D -> G"},
			{"6-2-8", "D -> E"},
			{"6-2-9", "E -> H"},
			{"6-2-10", "F -> I"},
			{"6-2-11", "G -> K"},
			{"6-2-12", "A -> B"},
			{"6-2-13", "B -> D"},
			{"6-2-14", "F -> E"},
			{"6-2-15", "H -> J"},
			{"6-2-16", "F -> H"},
			{"6-2-17", "H -> K"},
			{"6-2-18", "I -> K"},
			//해역 6-3
			{"6-3-1", "Start -> A"},
			{"6-3-2", "A -> B"},
			{"6-3-3", "A -> C"},
			{"6-3-4", "B -> D"},
			{"6-3-5", "C -> E"},
			{"6-3-6", "E -> F"},
			{"6-3-7", "E -> G"},
			{"6-3-8", "F -> H"},
			{"6-3-9", "H -> I"},
			{"6-3-10", "H -> J"},
			{"6-3-11", "D -> E"},
			{"6-3-12", "G -> H"},
			//해역 6-4
			{"6-4-1", "Start -> A"},
			{"6-4-2", "Start -> B"},
			{"6-4-3", "D -> C"},
			{"6-4-4", "A -> D"},
			{"6-4-5", "A -> E"},
			{"6-4-6", "C -> F"},
			{"6-4-7", "E -> G"},
			{"6-4-8", "H -> K"},
			{"6-4-9", "J -> I"},
			{"6-4-10", "H -> J"},
			{"6-4-11", "M -> K"},
			{"6-4-12", "J -> L"},
			{"6-4-13", "Start -> M"},
			{"6-4-14", "F -> N"},
			{"6-4-15", "B -> D"},
			{"6-4-16", "E -> D"},
			{"6-4-17", "G -> D"},
			{"6-4-18", "K -> J"},
			{"6-4-19", "L -> I"},
			{"6-4-20", "I -> N"},
			{"6-4-21", "J -> N"},
			//해역 31-1
			{"31-1-1", "Start -> A"},
			{"31-1-2", "A -> B"},
			{"31-1-3", "A -> C"},
			{"31-1-4", "A -> D"},
			{"31-1-5", "C -> E"},
			{"31-1-6", "A -> F"},
			{"31-1-7", "F -> G"},
			{"31-1-8", "D -> Z"},
			{"31-1-9", "B -> D"},
			{"31-1-10", "E -> Z"},
			//해역 31-2
			{"31-2-1", "Start -> A"},
			{"31-2-2", "A -> B"},
			{"31-2-3", "A -> C"},
			{"31-2-4", "B -> D"},
			{"31-2-5", "B -> E"},
			{"31-2-6", "C -> F"},
			{"31-2-7", "D -> G"},
			{"31-2-8", "F -> H"},
			{"31-2-9", "C -> I"},
			{"31-2-10", "I -> J"},
			{"31-2-13", "G -> Z"},
			{"31-2-14", "E -> G"},
			{"31-2-15", "J -> H"},
			{"31-2-17", "H -> Z"},
			//해역 31-3
			{"31-3-1", "Start -> A"},
			{"31-3-2", "A -> B"},
			{"31-3-3", "A -> C"},
			{"31-3-4", "B -> D"},
			{"31-3-5", "C -> E"},
			{"31-3-6", "D -> F"},
			{"31-3-7", "F -> G"},
			{"31-3-8", "E -> H"},
			{"31-3-9", "F -> I"},
			{"31-3-11", "D -> X"},
			{"31-3-12", "G -> Z"},
			{"31-3-13", "C -> D"},
			{"31-3-14", "D -> E"},
			{"31-3-16", "H -> Z"},
			//해역 31-4
			{"31-4-1", "Start -> A"},
			{"31-4-2", "Start -> B"},
			{"31-4-3", "A -> C"},
			{"31-4-4", "B -> D"},
			{"31-4-5", "C -> E"},
			{"31-4-6", "D -> F"},
			{"31-4-7", "E -> G"},
			{"31-4-8", "F -> H"},
			{"31-4-9", "F -> I"},
			{"31-4-10", "I -> J"},
			{"31-4-13", "G -> Z"},
			{"31-4-14", "D -> E"},
			{"31-4-15", "I -> H"},
			{"31-4-16", "J -> H"},
			{"31-4-18", "H -> Z"},
			//해역 31-5
			{"31-5-1", "Start -> A"},
			{"31-5-2", "Start -> B"},
			{"31-5-3", "A -> C"},
			{"31-5-4", "E -> D"},
			{"31-5-5", "B -> E"},
			{"31-5-6", "C -> F"},
			{"31-5-8", "D -> H"},
			{"31-5-9", "F -> I"},
			{"31-5-10", "H -> J"},
			{"31-5-11", "I -> K"},
			{"31-5-14", "K -> Z"},
			{"31-5-15", "B -> C"},
			{"31-5-16", "D -> F"},
			//해역 31-6
			{"31-6-1", "Start -> A"},
			{"31-6-3", "Start -> C"},
			{"31-6-4", "A -> D"},
			{"31-6-5", "C -> E"},
			{"31-6-7", "E -> G"},
			{"31-6-8", "G -> H"},
			{"31-6-10", "F -> J"},
			{"31-6-11", "J -> K"},
			{"31-6-12", "H -> L"},
			{"31-6-13", "J -> M"},
			{"31-6-15", "C -> O"},
			{"31-6-17", "K -> Z"},
			{"31-6-19", "F -> J"},
			{"31-6-20", "G -> F"},
			{"31-6-22", "L -> Z"},
			//해역 31-7
			{"31-7-1", "B -> A"},
			{"31-7-2", "Start -> B"},
			{"31-7-3", "A -> C"},
			{"31-7-4", "X -> D"},
			{"31-7-5", "Start -> E"},
			{"31-7-6", "D -> F"},
			{"31-7-7", "E -> G"},
			{"31-7-8", "D -> H"},
			{"31-7-9", "G -> I"},
			{"31-7-10", "G -> J"},
			{"31-7-11", "I -> K"},
			{"31-7-12", "J -> L"},
			{"31-7-13", "J -> M"},
			{"31-7-17", "B -> X"},
			{"31-7-18", "H -> Y"},
			{"31-7-19", "L -> Z"},
			{"31-7-20", "F -> G"},
			{"31-7-21", "H -> J"},
			{"31-7-22", "Y -> L"},
			{"31-7-23", "K -> M"},
			{"31-7-25", "J -> Y"},
			{"31-7-26", "M -> Z"},
			//해역 32-1
			{"32-1-1", "Start -> A"},
			{"32-1-2", "Start -> B"},
			{"32-1-3", "A -> C"},
			{"32-1-4", "C -> D"},
			{"32-1-5", "B -> E"},
			{"32-1-6", "D -> F"},
			{"32-1-7", "F -> I"},
			{"32-1-8", "E -> H"},
			{"32-1-9", "E -> G"},
			{"32-1-10", "F -> J"},
			{"32-1-11", "B -> C"},
			{"32-1-12", "E -> F"},
			{"32-1-13", "F -> H"},
			{"32-1-14", "H -> J"},
			//해역 32-2
			{"32-2-1", "Start -> A"},
			{"32-2-2", "Start -> B"},
			{"32-2-3", "A -> C"},
			{"32-2-4", "A -> D"},
			{"32-2-5", "B -> E"},
			{"32-2-6", "D -> F"},
			{"32-2-7", "E -> H"},
			{"32-2-8", "C -> G"},
			{"32-2-9", "F -> I"},
			{"32-2-10", "I -> J"},
			{"32-2-11", "H -> K"},
			{"32-2-12", "D -> E"},
			{"32-2-13", "H -> F"},
			{"32-2-14", "F -> G"},
			{"32-2-15", "H -> I"},
			{"32-2-16", "G -> I"},
			{"32-2-17", "J -> K"},
			//해역 32-3
			{"32-3-1", "Start -> A"},
			{"32-3-2", "A -> B"},
			{"32-3-3", "A -> C"},
			{"32-3-4", "C -> D"},
			{"32-3-5", "C -> E"},
			{"32-3-6", "B -> F"},
			{"32-3-7", "D -> G"},
			{"32-3-8", "I -> H"},
			{"32-3-9", "G -> I"},
			{"32-3-10", "H -> J"},
			{"32-3-11", "H -> K"},
			{"32-3-12", "F -> E"},
			{"32-3-13", "E -> G"},
			//해역 32-4
			{"32-4-1", "Start -> A"},
			{"32-4-2", "A -> B"},
			{"32-4-3", "B -> C"},
			{"32-4-4", "Start -> D"},
			{"32-4-5", "C -> E"},
			{"32-4-6", "B -> F"},
			{"32-4-7", "E -> G"},
			{"32-4-8", "G -> H"},
			{"32-4-9", "F -> I"},
			{"32-4-10", "H -> J"},
			{"32-4-11", "I -> K"},
			{"32-4-12", "N -> L"},
			{"32-4-13", "K -> M"},
			{"32-4-14", "K -> N"},
			{"32-4-15", "N -> O"},
			{"32-4-16", "D -> E"},
			{"32-4-17", "E -> F"},
			{"32-4-18", "H -> I"},
			{"32-4-19", "J -> K"},
			//해역 32-5
			{"32-5-1", "Start -> A"},
			{"32-5-2", "A -> B"},
			{"32-5-3", "A -> C"},
			{"32-5-5", "B -> E"},
			{"32-5-6", "C -> F"},
			{"32-5-7", "C -> G"},
			{"32-5-8", "E -> H"},
			{"32-5-9", "F -> I"},
			{"32-5-10", "G -> J"},
			{"32-5-11", "J -> K"},
			{"32-5-12", "K -> L"},
			{"32-5-13", "L -> M"},
			{"32-5-14", "L -> N"},
			{"32-5-19", "I -> J"},
			//해역 33-1
			{"33-1-1", "Start -> A"},
			{"33-1-2", "Start -> B"},
			{"33-1-3", "D -> C"},
			{"33-1-4", "F -> D"},
			{"33-1-5", "A -> E"},
			{"33-1-6", "B -> F"},
			{"33-1-7", "E -> G"},
			{"33-1-8", "I -> H"},
			{"33-1-9", "G -> I"},
			{"33-1-10", "D -> J"},
			{"33-1-11", "H -> D"},
			{"33-1-12", "E -> F"},
			//해역 33-2
			{"33-2-1", "Start -> A"},
			{"33-2-2", "A -> B"},
			{"33-2-3", "Start -> C"},
			{"33-2-4", "C -> D"},
			{"33-2-5", "A -> E"},
			{"33-2-6", "B -> F"},
			{"33-2-7", "C -> G"},
			{"33-2-8", "F -> H"},
			{"33-2-9", "E -> I"},
			{"33-2-10", "H -> J"},
			{"33-2-11", "G -> K"},
			{"33-2-12", "H -> L"},
			{"33-2-13", "J -> M"},
			{"33-2-14", "K -> N"},
			{"33-2-15", "M -> O"},
			{"33-2-16", "E -> F"},
			{"33-2-17", "D -> G"},
			{"33-2-18", "I -> J"},
			{"33-2-19", "K -> L"},
			{"33-2-20", "L -> M"},
			{"33-2-21", "N -> O"},
			//해역 33-3
			{"33-3-1", "Start -> A"},
			{"33-3-2", "A -> B"},
			{"33-3-3", "B -> C"},
			{"33-3-4", "B -> D"},
			{"33-3-5", "Start -> E"},
			{"33-3-6", "E -> F"},
			{"33-3-7", "D -> G"},
			{"33-3-8", "F -> H"},
			{"33-3-9", "H -> I"},
			{"33-3-10", "Start -> J"},
			{"33-3-11", "J -> K"},
			{"33-3-12", "I -> L"},
			{"33-3-13", "J -> M"},
			{"33-3-14", "P -> N"},
			{"33-3-16", "M -> P"},
			{"33-3-17", "N -> Q"},
			{"33-3-19", "G -> S"},
			{"33-3-20", "L -> T"},
			{"33-3-21", "C -> D"},
			{"33-3-22", "K -> I"},
			{"33-3-24", "Q -> T"}*/