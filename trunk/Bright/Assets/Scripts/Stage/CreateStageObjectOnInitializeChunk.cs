using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// チャンク初期化時にステージオブジェクトを生成するコンポーネント.
	/// </summary>
	public class CreateStageObjectOnInitializeChunk : MonoBehaviour, IReceiveOnInitializeChunk
	{
		[SerializeField]
		private GameObject prefab;

		public void OnInitializeChunk(StageManager stageManager, Point chunkIndex)
		{
			stageManager.CreateStageObject(this.prefab, chunkIndex, new Point(this.transform.localPosition));
		}
	}
}
