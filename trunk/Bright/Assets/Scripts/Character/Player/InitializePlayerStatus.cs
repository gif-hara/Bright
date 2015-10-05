using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// PlayerStatusクラスの初期化を行うコンポーネント.
	/// </summary>
	public class InitializePlayerStatus : MonoBehaviour
	{
		[SerializeField]
		private List<EquipmentData> initializeEquipments;

		void Start()
		{
			this.initializeEquipments.ForEach(e =>
			{
				PlayerStatus.Instance.InventoryEquipment.Add(this.GetCopy(e));
			});
			ObjectFinder.Player.GetComponent<EquipmentObserver>().OnSetEquipmentData(PlayerStatus.Instance.InventoryEquipment.Equipments[0]);

			PlayerStatus.Instance.Initialized();
//			ExecuteEvents.Execute<IReceiveSetEquipmentData>(ObjectFinder.Player, null, (handler, eventData) => handler.OnSetEquipmentData(this.initializeEquipments[0]));
		}

		private EquipmentData GetCopy(EquipmentData data)
		{
			if(data == null)
			{
				return null;
			}

			return data.Copy;
		}
	}
}
