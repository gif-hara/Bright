using UnityEngine;
using UnityEngine.Assertions;
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

		public ChunkDoorway()
		{
		}

		public ChunkDoorway(ChunkNode node)
		{
			flag = GetOpenedDoorway(node);
		}

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

		public bool AnyMatch(ChunkDoorway other)
		{
			return (this.flag & other.flag) > 0;
		}

		public bool IsOpen(ChunkDoorway other)
		{
			return !this.CanCreate(other.flag);
		}

		public GameDefine.DirectionType GetOpenedDoorway(ChunkNode node)
		{
			if(node.Left != null)
			{
				return GameDefine.DirectionType.Left;
			}
			if(node.Right != null)
			{
				return GameDefine.DirectionType.Right;
			}
			if(node.Top != null)
			{
				return GameDefine.DirectionType.Top;
			}
			if(node.Bottom != null)
			{
				return GameDefine.DirectionType.Bottom;
			}

			Assert.IsTrue(false, "不正な値です.");
			return GameDefine.DirectionType.Left;
		}
	}
}
