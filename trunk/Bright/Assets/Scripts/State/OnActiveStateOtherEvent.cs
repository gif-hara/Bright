using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class OnActiveStateOtherEvent : MonoBehaviour, IReceiveActiveState
	{
		[SerializeField]
		private UnityEvent otherEvent;

		public void OnActiveState()
		{
			this.otherEvent.Invoke();
		}
	}
}
