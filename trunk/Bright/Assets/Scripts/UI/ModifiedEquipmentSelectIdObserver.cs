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
	public class ModifiedEquipmentSelectIdObserver : MonoBehaviour, IReceiveModifiedEquipmentSelectId
	{
		private bool executing = false;

		public void OnModifiedEquipmentSelectId(int id)
		{
			if(this.executing)
			{
				return;
			}

			this.executing = true;
			ExecuteEventsExtensions.Broadcast<IReceiveModifiedEquipmentSelectId>(this.transform, null, (handler, eventData) => handler.OnModifiedEquipmentSelectId(id));
			this.executing = false;
		}
	}
}
