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

		public InventoryEquipment()
		{
			this.Equipments = new List<EquipmentData>();
			this.selectId = 0;
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

		public void ChangeSelectId(int addValue)
		{
			this.selectId += addValue;
			this.selectId = this.selectId > this.Equipments.Count ? 0 : this.selectId;
		}

		public void ChangeEquipment(EquipmentData equipment)
		{
			this.Equipments[this.selectId] = new EquipmentData(equipment);
		}
	}
}
