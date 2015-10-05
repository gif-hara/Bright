using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnTriggerEnter2Dイベントで現在装備している装備品のアイテムを生成するコンポーネント.
	/// </summary>
	public class OnTriggerEnter2DCreateCurrentEquipmentItem : MonoBehaviour
	{
		[SerializeField]
		private TriggerCreatePrefab trigger;

		[SerializeField]
		private LayerMask ignoreLayer;
		
		void OnTriggerEnter2D(Collider2D other)
		{
			if(this.ignoreLayer.IsIncluded(other.gameObject))
			{
				return;
			}
			var currentEquipment = PlayerStatus.Instance.InventoryEquipment.CurrentEquipmentData;
			if(currentEquipment == null)
			{
				return;
			}

			this.trigger.ChangePrefab(currentEquipment.ItemPrefab);
			this.trigger.Trigger();
		}
	}
}
