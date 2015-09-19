using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// チャンクコンポーネント.
	/// </summary>
	[RequireComponent(typeof(ChunkCreator))]
	public class Chunk : MonoBehaviour
	{
		public ChunkDoorway Doorway{ get{ return this.doorway; } }
		[SerializeField]
		private ChunkDoorway doorway;

		void OnDrawGizmos()
		{
			Gizmos.color = Color.yellow;
			var chunkSize = StageManager.ChunkSize;
			for(int i=0; i<chunkSize; i++)
			{
				Gizmos.DrawWireCube(this.transform.position + new Vector3(chunkSize / 2, chunkSize / 2), new Vector3(chunkSize, chunkSize, 0.0f));
			}
		}

		public void Initialize(StageManager stageManager, Point chunkIndex)
		{
			var creator = GetComponent<ChunkCreator>();
			var max = StageManager.ChunkSize - 1;
			
			this.CreateWall(creator, stageManager, GameDefine.DirectionType.Left, chunkIndex, Point.Zero);
			this.CreateWall(creator, stageManager, GameDefine.DirectionType.Right, chunkIndex, Point.Right * max);
			this.CreateGround(creator, stageManager, GameDefine.DirectionType.Top, chunkIndex, Point.Top * max);
			this.CreateGround(creator, stageManager, GameDefine.DirectionType.Bottom, chunkIndex, Point.Zero);
			this.CreateNextChunkCollider(creator, stageManager, GameDefine.DirectionType.Left, chunkIndex + Point.Left);
			this.CreateNextChunkCollider(creator, stageManager, GameDefine.DirectionType.Right, chunkIndex + Point.Right);
			this.CreateNextChunkCollider(creator, stageManager, GameDefine.DirectionType.Top, chunkIndex + Point.Top);
			this.CreateNextChunkCollider(creator, stageManager, GameDefine.DirectionType.Bottom, chunkIndex + Point.Bottom);
			
			var components = GetComponentsInChildren(typeof(IReceiveOnInitializeChunk));
			foreach(var component in components)
			{
				(component as IReceiveOnInitializeChunk).OnInitializeChunk(stageManager, chunkIndex);
			}
		}

		private void CreateGround(ChunkCreator creator, StageManager stageManager, GameDefine.DirectionType direction, Point chunkIndex, Point position)
		{
			if(!this.doorway.CanCreate(direction))
			{
				return;
			}

			creator.CreateGround(stageManager, chunkIndex, position);
		}

		private void CreateWall(ChunkCreator creator, StageManager stageManager, GameDefine.DirectionType direction, Point chunkIndex, Point position)
		{
			if(!this.doorway.CanCreate(direction))
			{
				return;
			}

			creator.CreateWall(stageManager, chunkIndex, position);
		}

		private void CreateNextChunkCollider(ChunkCreator creator, StageManager stageManager, GameDefine.DirectionType direction, Point chunkIndex)
		{
			if(this.doorway.CanCreate(direction))
			{
				return;
			}

			creator.CreateNextChunkCollider(stageManager, direction, chunkIndex);
		}
	}
}
