using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class CreatePrefabExtensionSetParentTakeDamageObject : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private OnTriggerEnter2DCreatePrefab trigger;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			instance.transform.parent = trigger.Other.transform;
		}
	}
}
