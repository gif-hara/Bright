using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// プレハブを生成するクラス.
	/// </summary>
	[System.Serializable]
	public class CreatePrefab
	{
		[SerializeField]
		private GameObject prefab = null;

		public CreatePrefab()
		{
		}

		public CreatePrefab(GameObject prefab)
		{
			this.prefab = prefab;
		}

		public void Create(GameObject canCreateReceiver, GameObject extensionReceiver)
		{
			if(!this.CanCreate(canCreateReceiver))
			{
				return;
			}

			var instance = Object.Instantiate(prefab);
			ExecuteEvents.Execute<IReceiveCreatePrefabExtension>(extensionReceiver, null, (handler, eventData) => handler.OnCreatePrefabExtension(instance));
		}

		public void Change(GameObject prefab)
		{
			this.prefab = prefab;
		}

		private bool CanCreate(GameObject canCreateReceiver)
		{
			if(canCreateReceiver == null)
			{
				return true;
			}

			var result = true;
			ExecuteEvents.Execute<IReceiveCanCreatePrefab>(canCreateReceiver, null, (handler, eventData) => result = handler.CanCreatePrefab());
			return result;
		}
	}
}
