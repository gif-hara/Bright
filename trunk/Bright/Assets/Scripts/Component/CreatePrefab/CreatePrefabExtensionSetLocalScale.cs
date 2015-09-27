using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnCreatePrefabExtensionイベント時にローカルスケール値を設定するコンポーネント.
	/// </summary>
	public class CreatePrefabExtensionSetLocalScale : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private Vector3 localScale = Vector3.one;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			instance.transform.localScale = this.localScale;
		}
	}
}
