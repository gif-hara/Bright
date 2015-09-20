using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// ゲームで扱うデータ類を定義するクラス.
	/// </summary>
	public static class GameDefine
	{
		public enum StateType : int
		{
			Idle,
			Run,
			Jump,
			Fall,
			Attack,
		}

		public enum DirectionType : int
		{
			Left   = (1 << 0),
			Right  = (1 << 1),
			Top    = (1 << 2),
			Bottom = (1 << 3),
		}

		public static GameDefine.DirectionType InverseDirection(GameDefine.DirectionType direction)
		{
			switch(direction)
			{
			case GameDefine.DirectionType.Left:
				return GameDefine.DirectionType.Right;
			case GameDefine.DirectionType.Right:
				return GameDefine.DirectionType.Left;
			case GameDefine.DirectionType.Top:
				return GameDefine.DirectionType.Bottom;
			case GameDefine.DirectionType.Bottom:
				return GameDefine.DirectionType.Top;
			default:
				Assert.IsTrue(false, "不正な値です. direction = " + direction);
				return GameDefine.DirectionType.Left;
			}
		}
	}
}
