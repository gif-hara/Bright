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
	public class EquipmentObserver : MonoBehaviour
	{
		[SerializeField]
		private Transform receiver;

		[SerializeField]
		private EquipmentData data;

		void Start()
		{
			Broadcast();
		}

		public void Change(EquipmentData data)
		{
			this.data = data;
			Broadcast();
		}

		private void Broadcast()
		{
			ExecuteEventsExtensions.Broadcast<IReceiveSetEquipmentData>(this.receiver, null, (handler, eventData) => handler.OnSetEquipmentData(this.data));
		}
	}
}
