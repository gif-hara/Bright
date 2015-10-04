using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// PlayerStatusのInventoryEquipmentの装備品切り替えイベントに登録するコンポーネント.
	/// </summary>
	public class RegistPlayerStatusInventoryEquipmentEvent : MonoBehaviour
	{
		void Awake()
		{
			PlayerStatus.Instance.InventoryEquipment.RegistSetEquipmentDataEvent(this.gameObject);
		}

		void OnDestroy()
		{
			PlayerStatus.Instance.InventoryEquipment.RemoveSetEquipmentDataEvent(this.gameObject);
		}
	}
}
