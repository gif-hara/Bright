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

		[SerializeField]
		private GameObject canCreateReceiver;

		[SerializeField]
		private GameObject extensionReceiver;

		public CreatePrefab()
		{
		}

		public CreatePrefab(GameObject prefab)
		{
			this.prefab = prefab;
		}

		public void Create(GameObject canCreateReceiver, GameObject extensionReceiver)
		{
			if(this.canCreateReceiver == null)
			{
				this.canCreateReceiver = canCreateReceiver;
			}

			if(!this.CanCreate)
			{
				return;
			}

			if(this.extensionReceiver == null)
			{
				this.extensionReceiver = extensionReceiver;
			}

			var instance = Object.Instantiate(prefab);
			ExecuteEvents.Execute<IReceiveCreatePrefabExtension>(this.extensionReceiver, null, (handler, eventData) => handler.OnCreatePrefabExtension(instance));
		}

		public void Change(GameObject prefab)
		{
			this.prefab = prefab;
		}

		private bool CanCreate
		{
			get
			{
				if(canCreateReceiver == null)
				{
					return true;
				}

				var result = true;
				ExecuteEvents.Execute<IReceiveCanCreatePrefab>(this.canCreateReceiver, null, (handler, eventData) => result = handler.CanCreatePrefab());
				return result;
			}
		}
	}
}
