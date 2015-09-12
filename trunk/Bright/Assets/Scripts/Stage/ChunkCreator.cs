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
        private bool doorwayLeft;

        [SerializeField]
        private bool doorwayRight;

        [SerializeField]
        private bool doorwayTop;

        [SerializeField]
        private bool doorwayBottom;

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
            this.Create(stageManager, this.doorwayLeft, wallPrefab, chunkXIndex, chunkYIndex, 0, max);
            this.Create(stageManager, this.doorwayRight, wallPrefab, chunkXIndex, chunkYIndex, max, max);
            this.Create(stageManager, this.doorwayTop, groundPrefab, chunkXIndex, chunkYIndex, 0, max);
            this.Create(stageManager, this.doorwayBottom, groundPrefab, chunkXIndex, chunkYIndex, 0, 0);

			var components = GetComponentsInChildren(typeof(IReceiveOnInitializeChunk));
			for(int i=0, imax=components.Length; i<imax; i++)
			{
				(components[i] as IReceiveOnInitializeChunk).OnInitializeChunk(stageManager, chunkXIndex, chunkYIndex);
			}
        }

		[Server]
        private void Create(StageManager stageManager, bool doorway, GameObject prefab, int chunkXIndex, int chunkYIndex, int xIndex, int yIndex)
        {
            if(!doorway)
            {
                return;
            }

            stageManager.CmdCreateFloor(prefab, chunkXIndex, chunkYIndex, xIndex, yIndex);
        }
    }
}
