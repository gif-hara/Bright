using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnTriggerEnter2Dイベントで装備品を切り替えるコンポーネント.
	/// </summary>
	public class OnTriggerEnter2DChangeEquipmentData : MonoBehaviour
	{
		[SerializeField]
		private EquipmentData data;

		[SerializeField]
		private LayerMask ignoreLayer;

		void OnTriggerEnter2D(Collider2D other)
		{
			if(this.ignoreLayer.IsIncluded(other.gameObject))
			{
				return;
			}

			PlayerStatus.Instance.InventoryEquipment.ChangeEquipment(this.data.Copy);
		}
	}
}
