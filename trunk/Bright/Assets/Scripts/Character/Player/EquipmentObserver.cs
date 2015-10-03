using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 装備している装備品を監視するコンポーネント.
	/// </summary>
	public class EquipmentObserver : MonoBehaviour, IReceiveSetEquipmentData
	{
		[SerializeField]
		private Transform receiver;

		public void OnSetEquipmentData(EquipmentData data)
		{
			ExecuteEventsExtensions.Broadcast<IReceiveSetEquipmentData>(this.receiver, null, (handler, eventData) => handler.OnSetEquipmentData(data));
		}
	}
}
