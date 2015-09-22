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

		public ChunkNode Node{ get{ return this.node; } }
		protected ChunkNode node = new ChunkNode();

		protected StageManager stageManager;
		
//		void OnDrawGizmos()
//		{
//			Gizmos.color = Color.yellow;
//			var chunkSize = StageManager.ChunkSize;
//			for(int i=0; i<chunkSize; i++)
//			{
//				Gizmos.DrawWireCube((this.index * chunkSize) + new Vector3(chunkSize / 2, chunkSize / 2), new Vector3(chunkSize, chunkSize, 0.0f));
//			}
//		}

		public virtual void Connect(GameDefine.DirectionType direction, Chunk chunk)
		{
			this.node.Connect(direction, chunk);
		}
	}
}
