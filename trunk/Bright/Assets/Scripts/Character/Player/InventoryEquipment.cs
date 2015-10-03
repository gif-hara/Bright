using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 装備品保持クラス.
	/// </summary>
	public class InventoryEquipment
	{
		public List<EquipmentData> Equipments{ private set; get; }

		private int selectId;

		private List<GameObject> setEquipmentDataReceivers;

		public InventoryEquipment()
		{
			this.Equipments = new List<EquipmentData>();
			this.selectId = 0;
			this.setEquipmentDataReceivers = new List<GameObject>();
		}

		public void Add(EquipmentData equipment)
		{
			this.Equipments.Add(equipment);
		}

		public void Update()
		{
			var equipment = this.Equipments[this.selectId];
			if(equipment == null)
			{
				return;
			}

			equipment.Update();
		}

		public void ChangeSelectId()
		{
			this.selectId++;
			this.selectId = this.selectId >= this.Equipments.Count ? 0 : this.selectId;
			this.Send(this.Equipments[this.selectId]);
		}

		public void ChangeEquipment(EquipmentData equipment)
		{
			this.Equipments[this.selectId] = new EquipmentData(equipment);
			this.Send(this.Equipments[this.selectId]);
		}

		public void RegistSetEquipmentDataEvent(GameObject receiver)
		{
			this.setEquipmentDataReceivers.Add(receiver);
		}

		public void RemoveSetEquipmentDataEvent(GameObject receiver)
		{
			this.setEquipmentDataReceivers.Remove(receiver);
		}

		private void Send(EquipmentData data)
		{
			this.setEquipmentDataReceivers.ForEach((r) =>
			{
				ExecuteEvents.Execute<IReceiveSetEquipmentData>(r, null, (handler, eventData) => handler.OnSetEquipmentData(data));
			});
		}
	}
}
