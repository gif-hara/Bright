using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// CreatePrefabExtensionイベント時にSyncScreenPositionのTargetを設定するコンポーネント.
	/// </summary>
	public class CreatePrefabExtensionSetTargetSyncScreenPosition : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private Transform target;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			var syncScreenPositin = instance.GetComponent<SyncScreenPosition>();
			Assert.IsTrue(syncScreenPositin != null, "SyncScreenPositionがアタッチされていません. gameObject = " + instance.name);

			syncScreenPositin.SetTarget(this.target);
		}
	}
}
