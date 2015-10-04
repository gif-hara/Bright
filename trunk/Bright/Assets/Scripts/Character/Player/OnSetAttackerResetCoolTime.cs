using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnSetAttackerイベントでアタッカーにクールタイムをリセットするコンポーネント.
	/// </summary>
	public class OnSetAttackerResetCoolTime : MonoBehaviour, IReceiveSetAttacker
	{
		public void OnSetAttacker(GameObject attacker)
		{
			ExecuteEvents.Execute<IReceiveResetCoolTime>(attacker, null, (handler, eventData) => handler.ResetCoolTime());
		}
	}
}
