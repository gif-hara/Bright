using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnCreatePrefabExtensionイベント時に親を設定するコンポーネント.
	/// </summary>
	public class CreatePrefabExtensionSetParent : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private Transform parent = null;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			this.parent = this.parent == null ? this.transform : this.parent;
			instance.transform.parent = this.parent;
		}
	}
}
