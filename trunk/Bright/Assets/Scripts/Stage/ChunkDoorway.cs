using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// チャンクの入り口データ.
	/// </summary>
	[System.Serializable]
	public class ChunkDoorway
	{
		[SerializeField][EnumFlags]
		private GameDefine.DirectionType flag;

		public bool CanCreate(GameDefine.DirectionType type)
		{
			return (flag & type) > 0;
		}

		public bool Difference(ChunkDoorway other, GameDefine.DirectionType type)
		{
			return this.CanCreate(type) != other.CanCreate(type);
		}

		public void Copy(ChunkDoorway other)
		{
			this.flag = other.flag;
		}
	}
}
