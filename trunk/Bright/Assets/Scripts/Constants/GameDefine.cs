using UnityEngine;
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

		public enum ChunkDoorwayType : int
		{
			Left =   (1 << 0),
			Right =  (1 << 1),
			Top =    (1 << 2),
			Bottom = (1 << 3),
		}
	}
}
