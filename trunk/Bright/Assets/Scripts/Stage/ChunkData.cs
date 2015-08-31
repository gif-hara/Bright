using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// チャンクデータ.
	/// </summary>
	[System.Serializable]
	public class ChunkData
	{
		public int X{ private set; get; }

		public int Y{ private set; get; }

		public ChunkData(int x, int y)
		{
			this.X = x;
			this.Y = y;
		}
	}
}
