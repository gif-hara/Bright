using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// デバッグで装備品データを切り替えるコンポーネント.
	/// </summary>
	public class DebugChangeEquipmentData : MonoBehaviour
	{
		[SerializeField]
		private DebugInputAction inputAction;

		[SerializeField]
		private EquipmentData data;

		void Update()
		{
			this.inputAction.Proccess(() =>
			{
				var instance = ScriptableObject.CreateInstance<EquipmentData>();
				instance.Copy(this.data);
				PlayerStatus.Instance.InventoryEquipment.ChangeEquipment(instance);
			});
		}
	}
}
