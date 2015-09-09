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

        public void Initialize(StageManager stageManager)
        {
            this.CreateGround(stageManager, this.doorwayLeft, groundPrefab, 0, 0);
        }

        private void CreateGround(StageManager stageManager, bool doorway, GameObject prefab, int xIndex, int yIndex)
        {
        }
    }
}
