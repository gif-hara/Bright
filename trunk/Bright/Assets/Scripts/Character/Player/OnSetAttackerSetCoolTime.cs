using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnSetAttackerイベントでアタッカーにクールタイムを設定するコンポーネント.
	/// </summary>
	public class OnSetAttackerSetCoolTime : MonoBehaviour, IReceiveSetAttacker
	{
		[SerializeField]
		private float coolTime;

		public void OnSetAttacker(GameObject attacker)
		{
			ExecuteEvents.Execute<IReceiveSetCoolTime>(attacker, null, (handler, eventData) => handler.SetCoolTime(this.coolTime));
		}
	}
}
