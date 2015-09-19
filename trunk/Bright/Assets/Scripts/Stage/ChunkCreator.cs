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

        public void Initialize(StageManager stageManager, int chunkXIndex, int chunkYIndex)
        {
			var max = StageManager.ChunkSize - 1;

			this.Create(stageManager, GameDefine.ChunkDoorwayType.Left, wallPrefab, chunkXIndex, chunkYIndex, 0, 0);
			this.Create(stageManager, GameDefine.ChunkDoorwayType.Right, wallPrefab, chunkXIndex, chunkYIndex, max, 0);
			this.Create(stageManager, GameDefine.ChunkDoorwayType.Top, groundPrefab, chunkXIndex, chunkYIndex, 0, max);
			this.Create(stageManager, GameDefine.ChunkDoorwayType.Bottom, groundPrefab, chunkXIndex, chunkYIndex, 0, 0);

			this.CreateNextChunkCollider(stageManager, GameDefine.NextChunkType.Left, chunkXIndex - 1, chunkYIndex);
			this.CreateNextChunkCollider(stageManager, GameDefine.NextChunkType.Right, chunkXIndex + 1, chunkYIndex);
			this.CreateNextChunkCollider(stageManager, GameDefine.NextChunkType.Top, chunkXIndex, chunkYIndex + 1);
			this.CreateNextChunkCollider(stageManager, GameDefine.NextChunkType.Bottom, chunkXIndex, chunkYIndex - 1);

			var components = GetComponentsInChildren(typeof(IReceiveOnInitializeChunk));
			foreach(var component in components)
			{
				(component as IReceiveOnInitializeChunk).OnInitializeChunk(stageManager, chunkXIndex, chunkYIndex);
			}
        }

        private void Create(StageManager stageManager, GameDefine.ChunkDoorwayType doorway, GameObject prefab, int chunkXIndex, int chunkYIndex, int xIndex, int yIndex)
        {
			if(!this.chunk.Doorway.CanCreate(doorway))
            {
                return;
            }

            stageManager.CmdCreateStageObject(prefab, chunkXIndex, chunkYIndex, xIndex, yIndex);
        }

		private void CreateNextChunkCollider(StageManager stageManager, GameDefine.NextChunkType nextChunkType, int chunkXIndex, int chunkYIndex)
		{
			if(!this.chunk.NextCreateChunk.CanCreate(nextChunkType))
			{
				return;
			}

			stageManager.CmdNextChunkCollider(chunkXIndex, chunkYIndex);
		}
    }
}
