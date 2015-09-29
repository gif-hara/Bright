using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnCreatePrefaイベント時に生成したプレハブの回転を同期するコンポーネント.
	/// </summary>
	public class CreatePrefabExtensionSyncRotation : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private Transform target;

		[SerializeField]
		private Vector3 offset;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			instance.transform.rotation = this.target.rotation;
			instance.transform.rotation *= Quaternion.Euler(this.offset);
		}
	}
}
