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

		public void CreateGround(StageManager stageManager, Point chunkIndex, Point position)
		{
			stageManager.CreateStageObject(this.transform, this.groundPrefab, chunkIndex, position);
		}
		
		public void CreateWall(StageManager stageManager, Point chunkIndex, Point position)
		{
			stageManager.CreateStageObject(this.transform, this.wallPrefab, chunkIndex, position);
		}
		
		public void CreateNextChunkCollider(StageManager stageManager, GameDefine.DirectionType direction, Point chunkIndex)
		{
			stageManager.CmdNextChunkCollider(chunkIndex);
		}
    }
}
