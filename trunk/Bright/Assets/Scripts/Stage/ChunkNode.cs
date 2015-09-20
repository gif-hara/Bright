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

		public void Visible(Chunk ignoreChunk)
		{
			SetActive(this.Left, ignoreChunk, true);
			SetActive(this.Right, ignoreChunk, true);
			SetActive(this.Top, ignoreChunk, true);
			SetActive(this.Bottom, ignoreChunk, true);
		}

		public void Hidden(Chunk ignoreChunk)
		{
			SetActive(this.Left, ignoreChunk, false);
			SetActive(this.Right, ignoreChunk, false);
			SetActive(this.Top, ignoreChunk, false);
			SetActive(this.Bottom, ignoreChunk, false);
		}

		public void VisibleRelatedChunk(Chunk parent)
		{
			VisibleRelatedChunk(this.Left, parent);
			VisibleRelatedChunk(this.Right, parent);
			VisibleRelatedChunk(this.Top, parent);
			VisibleRelatedChunk(this.Bottom, parent);
		}
		
		public void HiddenRelatedChunk(Chunk parent)
		{
			HiddenRelatedChunk(this.Left, parent);
			HiddenRelatedChunk(this.Right, parent);
			HiddenRelatedChunk(this.Top, parent);
			HiddenRelatedChunk(this.Bottom, parent);
		}
		
		private void SetActive(Chunk target, Chunk ignoreChunk, bool isActive)
		{
			if(target == null || target == ignoreChunk)
			{
				return;
			}

			target.gameObject.SetActive(isActive);
		}

		private void VisibleRelatedChunk(Chunk target, Chunk parent)
		{
			if(target == null)
			{
				return;
			}
			
			target.Visible(parent);
		}

		private void HiddenRelatedChunk(Chunk target, Chunk parent)
		{
			if(target == null)
			{
				return;
			}
			
			target.Hidden(parent);
		}
	}
}
