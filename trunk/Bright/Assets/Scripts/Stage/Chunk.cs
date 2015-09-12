using UnityEngine;
using System.Collections;

namespace Bright
{
    public class Chunk : MonoBehaviour
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

        public void Initialize(StageManager stageManager, int chunkXIndex, int chunkYIndex)
        {
			var max = StageManager.ChunkSize - 1;
            this.Create(stageManager, this.doorwayLeft, wallPrefab, chunkXIndex, chunkYIndex, 0, max);
            this.Create(stageManager, this.doorwayRight, wallPrefab, chunkXIndex, chunkYIndex, max, max);
            this.Create(stageManager, this.doorwayTop, groundPrefab, chunkXIndex, chunkYIndex, 0, max);
            this.Create(stageManager, this.doorwayBottom, groundPrefab, chunkXIndex, chunkYIndex, 0, 0);
        }

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
