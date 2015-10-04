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
	public class ChangeEquipmentDataObserver : MonoBehaviour, IReceiveChangeEquipmentData
	{
		private bool executing = false;

		public void OnChangeEquipmentData(int id, EquipmentData data)
		{
			if(this.executing)
			{
				return;
			}

			this.executing = true;
			ExecuteEventsExtensions.Broadcast<IReceiveChangeEquipmentData>(this.transform, null, (handler, eventData) => handler.OnChangeEquipmentData(id, data));
			this.executing = false;
		}
	}
}
