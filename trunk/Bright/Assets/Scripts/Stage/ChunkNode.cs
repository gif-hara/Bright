using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// チャンク同士を繋ぐノードクラス.
	/// </summary>
	public class ChunkNode
	{
		/// <summary>
		/// 左側に繋がっているチャンクオブジェクト.
		/// </summary>
		/// <value>The left.</value>
		public GameObject Left{ private set; get; }

		/// <summary>
		/// 右側に繋がっているチャンクオブジェクト.
		/// </summary>
		/// <value>The right.</value>
		public GameObject Right{ private set; get; }

		/// <summary>
		/// 上側に繋がっているチャンクオブジェクト.
		/// </summary>
		/// <value>The top.</value>
		public GameObject Top{ private set; get; }

		/// <summary>
		/// 下側に繋がっているチャンクオブジェクト.
		/// </summary>
		/// <value>The bottom.</value>
		public GameObject Bottom{ private set; get; }

		/// <summary>
		/// 左側にチャンクを繋げる.
		/// </summary>
		/// <param name="left">Left.</param>
		public void ConnectLeft(GameObject left)
		{
			this.Left = left;
		}
		/// <summary>
		/// 右側にチャンクを繋げる.
		/// </summary>
		/// <param name="right">Right.</param>
		public void ConnectRight(GameObject right)
		{
			this.Right = right;
		}
		/// <summary>
		/// 上側にチャンクを繋げる.
		/// </summary>
		/// <param name="top">Top.</param>
		public void ConnectTop(GameObject top)
		{
			this.Top = top;
		}
		/// <summary>
		/// 下側にチャンクを繋げる.
		/// </summary>
		/// <param name="bottom">Bottom.</param>
		public void ConnectBottom(GameObject bottom)
		{
			this.Bottom = bottom;
		}
	}
}
