using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// チャンク初期化時にステージオブジェクトを生成するコンポーネント.
	/// </summary>
	[ExecuteInEditMode]
	public class CreateStageObjectOnInitializeChunk : MonoBehaviour, IReceiveOnInitializeChunk
	{
		[SerializeField]
		private GameObject prefab;

#if UNITY_EDITOR
		private GameObject _prefab;

		private GameObject _instance;

		void Update()
		{
			if(this.prefab == null)
			{
				return;
			}

			if(this._prefab != this.prefab)
			{
				this._prefab = this.prefab;
				DestroyImmediate(this._instance);
				this._instance = Instantiate(this._prefab);
				this._instance.hideFlags = HideFlags.HideInHierarchy;
			}

			this._instance.transform.position = transform.position;
		}

		void OnDestroy()
		{
			if(this._instance == null)
			{
				return;
			}

			DestroyImmediate(this._instance);
		}
#endif

		public void OnInitializeChunk(StageManager stageManager, Point chunkIndex)
		{
			stageManager.CreateStageObject(this.transform, this.prefab, chunkIndex, new Point(this.transform.localPosition));
		}
	}
}
