using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 空のチャンクコンポーネント.
	/// </summary>
	public class BlankChunk : ChunkBase
	{
		public void Initialize(StageManager stageManager, Point index)
		{
			this.index = index;
			this.stageManager = stageManager;
		}

		public void Hypostatization()
		{
			this.stageManager.CreateChunk(this, index);
		}
	}
}
