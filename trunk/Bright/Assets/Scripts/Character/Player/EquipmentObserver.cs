using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 装備している装備品を監視するコンポーネント.
	/// </summary>
	public class EquipmentObserver : MonoBehaviour, IReceiveSetEquipmentData
	{
		[SerializeField]
		private Transform receiver;

		private bool executing = false;

		public void OnSetEquipmentData(EquipmentData data)
		{
			if(this.executing)
			{
				return;
			}

			this.executing = true;
			ExecuteEventsExtensions.Broadcast<IReceiveSetEquipmentData>(this.receiver, null, (handler, eventData) => handler.OnSetEquipmentData(data));
			this.executing = false;
		}
	}
}
