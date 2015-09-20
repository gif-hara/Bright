using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// チャンク抽象クラス.
	/// </summary>
	public class ChunkBase : MonoBehaviour
	{
		public Point Index{ get{ return this.index; } }
		protected Point index = Point.Zero;

		protected StageManager stageManager;

		public ChunkNode Node{ get{ return this.node; } }
		protected ChunkNode node = new ChunkNode();

		void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			var chunkSize = StageManager.ChunkSize;
			for(int i=0; i<chunkSize; i++)
			{
				Gizmos.DrawWireCube((this.index * chunkSize) + new Vector3(chunkSize / 2, chunkSize / 2), new Vector3(chunkSize, chunkSize, 0.0f));
			}
		}

		virtual public void Initialize(StageManager stageManager, Point index)
		{
			this.index = index;
			this.stageManager = stageManager;
		}
		
		public void Connect(GameDefine.DirectionType direction, Chunk chunk)
		{
			this.node.Connect(direction, chunk);
		}
	}
}
