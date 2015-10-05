using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// CreatePrefabExtensionイベント時に指定したオブジェクトの参照が無くなったら死亡させるコンポーネント.
	/// </summary>
	public class CreatePrefabExtensionDestroyOnNullReference : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private GameObject target;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			instance.AddComponent<DestroyOnNullReference>().SetTarget(this.target);
		}
	}
}
