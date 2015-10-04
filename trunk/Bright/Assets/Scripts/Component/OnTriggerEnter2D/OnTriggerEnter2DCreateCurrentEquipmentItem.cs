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
			
			this.trigger.ChangePrefab(PlayerStatus.Instance.InventoryEquipment.CurrentEquipmentData.ItemPrefab);
			this.trigger.Trigger();
		}
	}
}
