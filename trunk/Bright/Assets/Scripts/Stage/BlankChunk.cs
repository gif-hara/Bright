using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 空のチャンクコンポーネント.
	/// </summary>
	public class BlankChunk : ChunkBase
	{
		public void Hypostatization()
		{
			this.stageManager.CreateChunk(this, index);
		}
	}
}
