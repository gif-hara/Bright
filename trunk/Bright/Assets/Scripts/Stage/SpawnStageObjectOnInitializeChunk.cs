using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// チャンク初期化時にステージオブジェクトを生成するコンポーネント.
	/// </summary>
	public class SpawnStageObjectOnInitializeChunk : MonoBehaviour, IReceiveOnInitializeChunk
	{
		[SerializeField]
		private GameObject prefab;

		public void OnInitializeChunk(StageManager stageManager, int chunkXIndex, int chunkYIndex)
		{
			var index = this.transform.localPosition;
			stageManager.CmdCreateFloor(this.prefab, chunkXIndex, chunkYIndex, (int)index.x, (int)index.y);
		}
	}
}
