using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// チャンク同士を繋ぐノードクラス.
	/// </summary>
	[System.Serializable]
	public class ChunkNode
	{
		/// <summary>
		/// 左側に繋がっているチャンクオブジェクト.
		/// </summary>
		/// <value>The left.</value>
		public Chunk Left{ private set; get; }

		/// <summary>
		/// 右側に繋がっているチャンクオブジェクト.
		/// </summary>
		/// <value>The right.</value>
		public Chunk Right{ private set; get; }

		/// <summary>
		/// 上側に繋がっているチャンクオブジェクト.
		/// </summary>
		/// <value>The top.</value>
		public Chunk Top{ private set; get; }

		/// <summary>
		/// 下側に繋がっているチャンクオブジェクト.
		/// </summary>
		/// <value>The bottom.</value>
		public Chunk Bottom{ private set; get; }

		public void Connect(GameDefine.DirectionType direction, Chunk chunk)
		{
			switch(direction)
			{
			case GameDefine.DirectionType.Left:
				this.Left = chunk;
				break;
			case GameDefine.DirectionType.Right:
				this.Right = chunk;
				break;
			case GameDefine.DirectionType.Top:
				this.Top = chunk;
				break;
			case GameDefine.DirectionType.Bottom:
				this.Bottom = chunk;
				break;
			default:
				Assert.IsTrue(false, "不正な値です. direction = " + direction);
				break;
			}
		}

		public bool Contains(GameDefine.DirectionType direction)
		{
			switch(direction)
			{
			case GameDefine.DirectionType.Left:
				return this.Left != null;
			case GameDefine.DirectionType.Right:
				return this.Right != null;
			case GameDefine.DirectionType.Top:
				return this.Top != null;
			case GameDefine.DirectionType.Bottom:
				return this.Bottom != null;
			default:
				Assert.IsTrue(false, "不正な値です. direction = " + direction);
				return false;
			}
		}
	}
}
