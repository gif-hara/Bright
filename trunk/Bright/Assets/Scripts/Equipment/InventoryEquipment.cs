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

		public void Initialized()
		{
			ChangeSelectId(0);
		}

		public void Add(EquipmentData equipment)
		{
			this.Equipments.Add(equipment);
			this.setEquipmentDataReceivers.ForEach((r) =>
			{
				ExecuteEvents.Execute<IReceiveAddEquipment>(r, null, (handler, eventData) => handler.OnAddEquipment(this.Equipments.Count - 1, equipment));
			});
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

		public void ResetCoolTime()
		{
			this.Equipments[this.selectId].ResetCoolTime();
		}

		public void ChangeSelectId(int value)
		{
			this.selectId += value;
			this.selectId = this.selectId >= this.Equipments.Count ? 0 : this.selectId;
			this.setEquipmentDataReceivers.ForEach((r) =>
			{
				ExecuteEvents.Execute<IReceiveModifiedEquipmentSelectId>(r, null, (handler, eventData) => handler.OnModifiedEquipmentSelectId(this.selectId));
				ExecuteEvents.Execute<IReceiveSetEquipmentData>(r, null, (handler, eventData) => handler.OnSetEquipmentData(this.Equipments[this.selectId]));
			});
		}

		public void ChangeEquipment(EquipmentData equipment)
		{
			this.Equipments[this.selectId] = equipment;
			this.setEquipmentDataReceivers.ForEach((r) =>
			{
				ExecuteEvents.Execute<IReceiveChangeEquipmentData>(r, null, (handler, eventData) => handler.OnChangeEquipmentData(this.selectId, equipment));
				ExecuteEvents.Execute<IReceiveSetEquipmentData>(r, null, (handler, eventData) => handler.OnSetEquipmentData(this.Equipments[this.selectId]));
			});
		}

		public void RegistSetEquipmentDataEvent(GameObject receiver)
		{
			this.setEquipmentDataReceivers.Add(receiver);
		}

		public void RemoveSetEquipmentDataEvent(GameObject receiver)
		{
			this.setEquipmentDataReceivers.Remove(receiver);
		}

		public bool CanAttack
		{
			get
			{
				return this.Equipments[this.selectId].CanAttack;
			}
		}
	}
}
