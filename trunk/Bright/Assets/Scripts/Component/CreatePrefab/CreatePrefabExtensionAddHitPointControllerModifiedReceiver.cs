using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// CreatePrefabExtensionイベント時にHitPointControllerのModifiedReceiverに追加するコンポーネント.
	/// </summary>
	public class CreatePrefabExtensionAddHitPointControllerModifiedReceiver : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private HitPointController target;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			this.target.AddModifiedReceiver(instance);
		}
	}
}
