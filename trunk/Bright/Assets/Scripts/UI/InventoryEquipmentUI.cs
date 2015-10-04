using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 装備品インベントリUIクラス.
	/// </summary>
	public class InventoryEquipmentUI : MonoBehaviour, IReceiveModifiedEquipmentSelectId, IReceiveChangeEquipmentData
	{
		[SerializeField]
		private EquipmentObserver observer;

		private int id;

		public void Initialize(int id)
		{
			this.id = id;
		}

		public void OnModifiedEquipmentSelectId(int id)
		{
			ExecuteEventsExtensions.Broadcast<IReceiveSelectEquipmentUI>(this.transform, null, (handler, eventData) =>
			{
				if(this.id == id)
				{
					handler.OnSelectEquipment();
				}
				else
				{
					handler.OnUnselectEquipment();
				}
			});
		}

		public void OnChangeEquipmentData(int id, EquipmentData data)
		{
			if(this.id != id)
			{
				return;
			}

			this.Broadcast(data);
		}

		public void Broadcast(EquipmentData data)
		{
			this.observer.OnSetEquipmentData(data);
		}
		
	}
}
