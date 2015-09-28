using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnCreatePrefaイベント時に生成したプレハブの座標を同期するコンポーネント.
	/// </summary>
	public class CreatePrefabExtensionSyncPosition : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private Transform target;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			instance.transform.position = target.position;
		}
	}
}
