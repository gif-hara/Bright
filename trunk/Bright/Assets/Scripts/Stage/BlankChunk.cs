using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 空のチャンクコンポーネント.
	/// </summary>
	public class BlankChunk : ChunkBase
	{
		private Chunk linkedChunk;

		private GameDefine.DirectionType linkedDirection;

		public override void Connect (GameDefine.DirectionType direction, Chunk chunk)
		{
			base.Connect (direction, chunk);
			this.linkedChunk = chunk;
			this.linkedDirection = direction;
		}
		public void Initialize(StageManager stageManager, Point index)
		{
			this.index = index;
			this.stageManager = stageManager;
		}

		public void Hypostatization()
		{
			var chunk = this.stageManager.CreateChunk(this, index);
			this.linkedChunk.Connect(GameDefine.InverseDirection(this.linkedDirection), chunk);
		}

		/// <summary>
		/// 入り口のみ開いているChunkDoorwayを返す.
		/// </summary>
		/// <value>The opened doorway.</value>
		public ChunkDoorway OpenedDoorway
		{
			get
			{
				return new ChunkDoorway(this.node);
			}
		}
	}
}
