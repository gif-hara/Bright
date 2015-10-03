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
			this.initializeEquipments.ForEach(e => PlayerStatus.Instance.InventoryEquipment.Add(e));
			ExecuteEvents.Execute<IReceiveSetEquipmentData>(ObjectFinder.Player, null, (handler, eventData) => handler.OnSetEquipmentData(this.initializeEquipments[0]));
		}
	}
}
