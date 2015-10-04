using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// AddEquipmentイベント時にEquipmentプレハブを生成するコンポーネント.
	/// </summary>
	public class AddEquipmentCreateEquipmentUI : MonoBehaviour, IReceiveAddEquipment
	{
		[SerializeField]
		private InventoryEquipmentUI prefab;

		[SerializeField]
		private int intervalY;

		public void OnAddEquipment(int id, EquipmentData data)
		{
			var ui = Instantiate(this.prefab);
			ui.Initialize(id);
			var rectTransform = ui.transform as RectTransform;
			rectTransform.SetParent(this.transform, false);
			ui.transform.localPosition = Vector3.down * (this.intervalY * id);
			ui.Broadcast(data);
		}
	}
}
