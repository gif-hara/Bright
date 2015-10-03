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

		void Awake()
		{
			this.initializeEquipments.ForEach(e => PlayerStatus.Instance.InventoryEquipment.Add(e));
		}
	}
}
