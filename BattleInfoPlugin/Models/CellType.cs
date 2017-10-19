﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleInfoPlugin.Models
{
	[Flags]
	public enum CellType
	{
		None = 0,

        開始 = 1 << 0,
        イベント無し = 1 << 1,
        補給 = 1 << 2,
		渦潮 = 1 << 3,
        戦闘 = 1 << 4,
        ボス = 1 << 5,
        揚陸地点 = 1 << 6,
        航空戦 = 1 << 7,
        母港 = 1 << 8,
        航空偵察 = 1 << 9,
		空襲戦 = 1 << 10,

        夜戦 = 1 << 31,

		演習 = -1,
	}

	public static class CellTypeExtensions
	{
		public static CellType ToCellType(this int colorNo)
		{
			return (CellType)(1 << colorNo);
		}

		public static CellType ToCellType(this string battleType)
		{
            return battleType.Contains("sp_midnight") ? CellType.夜戦
                : battleType.Contains("ld_airbattle") ? CellType.空襲戦    //ColorNoからも分かるが、航空戦と誤認しないため
                : battleType.Contains("airbattle") ? CellType.航空戦
                : CellType.None;
        }

		public static CellType GetCellType(this MapCell cell, IReadOnlyDictionary<MapCell, CellType> knownTypes)
		{
			var result = CellType.None;
			if (knownTypes.ContainsKey(cell)) result = result | knownTypes[cell];
			var cellMaster = Repositories.Master.Current.MapCells[cell.Id];
			result = result | cellMaster.ColorNo.ToCellType();
			return result;
		}
	}
}
