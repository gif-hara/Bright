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
        private GameObject groundPrefab;

        [SerializeField]
        private GameObject wallPrefab;

		public GameObject CreateGround(StageManager stageManager, Point chunkIndex, Point position)
		{
			return stageManager.CreateStageObject(this.transform, this.groundPrefab, chunkIndex, position);
		}
		
		public GameObject CreateWall(StageManager stageManager, Point chunkIndex, Point position)
		{
			return stageManager.CreateStageObject(this.transform, this.wallPrefab, chunkIndex, position);
		}
    }
}
