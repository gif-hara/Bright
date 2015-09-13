using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// チャンクを生成するコンポーネント.
	/// </summary>
	public class ChunkCreator : NetworkBehaviour
    {
		[SerializeField]
		private ChunkDoorway doorway;

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

		[Server]
        public void Initialize(StageManager stageManager, int chunkXIndex, int chunkYIndex)
        {
			var max = StageManager.ChunkSize - 1;
			this.Create(stageManager, this.doorway.CanCreate(GameDefine.ChunkDoorwayType.Left), wallPrefab, chunkXIndex, chunkYIndex, 0, 0);
			this.Create(stageManager, this.doorway.CanCreate(GameDefine.ChunkDoorwayType.Right), wallPrefab, chunkXIndex, chunkYIndex, max, 0);
			this.Create(stageManager, this.doorway.CanCreate(GameDefine.ChunkDoorwayType.Top), groundPrefab, chunkXIndex, chunkYIndex, 0, max);
			this.Create(stageManager, this.doorway.CanCreate(GameDefine.ChunkDoorwayType.Bottom), groundPrefab, chunkXIndex, chunkYIndex, 0, 0);

			var components = GetComponentsInChildren(typeof(IReceiveOnInitializeChunk));
			foreach(var component in components)
			{
				(component as IReceiveOnInitializeChunk).OnInitializeChunk(stageManager, chunkXIndex, chunkYIndex);
			}
        }

		[Server]
        private void Create(StageManager stageManager, bool doorway, GameObject prefab, int chunkXIndex, int chunkYIndex, int xIndex, int yIndex)
        {
            if(!doorway)
            {
                return;
            }

            stageManager.CmdCreateStageObject(prefab, chunkXIndex, chunkYIndex, xIndex, yIndex);
        }
    }
}
