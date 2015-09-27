using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnCreatePrefabExtensionイベント時にローカル座標を設定するコンポーネント.
	/// </summary>
	public class CreatePrefabExtensionSetLocalPosition : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private Vector3 localPosition;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			instance.transform.localPosition = this.localPosition;
		}
	}
}
