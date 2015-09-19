using UnityEngine;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// チャンクを生成するコンポーネント.
	/// </summary>
	public class ChunkCreator : MonoBehaviour
    {
		[SerializeField]
		private Chunk chunk;

        [SerializeField]
        private GameObject groundPrefab;

        [SerializeField]
        private GameObject wallPrefab;

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
			var max = StageManager.ChunkSize - 1;

			this.Create(stageManager, GameDefine.ChunkDoorwayType.Left, wallPrefab, chunkIndex, Point.Zero);
			this.Create(stageManager, GameDefine.ChunkDoorwayType.Right, wallPrefab, chunkIndex, Point.Right * max);
			this.Create(stageManager, GameDefine.ChunkDoorwayType.Top, groundPrefab, chunkIndex, Point.Top * max);
			this.Create(stageManager, GameDefine.ChunkDoorwayType.Bottom, groundPrefab, chunkIndex, Point.Zero);

			this.CreateNextChunkCollider(stageManager, GameDefine.NextChunkType.Left, chunkIndex + Point.Left);
			this.CreateNextChunkCollider(stageManager, GameDefine.NextChunkType.Right, chunkIndex + Point.Right);
			this.CreateNextChunkCollider(stageManager, GameDefine.NextChunkType.Top, chunkIndex + Point.Top);
			this.CreateNextChunkCollider(stageManager, GameDefine.NextChunkType.Bottom, chunkIndex + Point.Bottom);

			var components = GetComponentsInChildren(typeof(IReceiveOnInitializeChunk));
			foreach(var component in components)
			{
				(component as IReceiveOnInitializeChunk).OnInitializeChunk(stageManager, chunkIndex);
			}
        }

        private void Create(StageManager stageManager, GameDefine.ChunkDoorwayType doorway, GameObject prefab, Point chunkIndex, Point position)
        {
			if(!this.chunk.Doorway.CanCreate(doorway))
            {
                return;
            }

            stageManager.CreateStageObject(prefab, chunkIndex, position);
        }

		private void CreateNextChunkCollider(StageManager stageManager, GameDefine.NextChunkType nextChunkType, Point chunkIndex)
		{
			if(!this.chunk.NextCreateChunk.CanCreate(nextChunkType))
			{
				return;
			}

			stageManager.CmdNextChunkCollider(chunkIndex);
		}
    }
}
