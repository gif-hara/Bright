using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 装備している武器を監視するコンポーネント.
	/// </summary>
	public class WeaponObserver : MonoBehaviour
	{
		[SerializeField]
		private Transform receiver;

		[SerializeField]
		private WeaponData data;

		void Start()
		{
			Broadcast();
		}

		public void Change(WeaponData data)
		{
			this.data = data;
			Broadcast();
		}

		private void Broadcast()
		{
			ExecuteEventsExtensions.Broadcast<IReceiveSetWeaponData>(this.receiver, null, (handler, eventData) => handler.OnSetWeaponData(this.data));
		}
	}
}
