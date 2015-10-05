using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnCreatePrefabExtensionイベント時に衝突したオブジェクトの座標と同期を取るコンポーネント.
	/// </summary>
	public class CreatePrefabExtensionSyncPositionOtherCollider : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private OnTriggerEnter2DOtherHolder holder;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			instance.transform.position = this.holder.Other.transform.position;
		}
	}
}
