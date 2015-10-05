using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	///  CreatePrefabExtensionイベント時に座標を加算するコンポーネント.
	/// </summary>
	public class CreatePrefabExtensionAddPosition : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private Vector3 position;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			instance.transform.position += position;
		}
	}
}
