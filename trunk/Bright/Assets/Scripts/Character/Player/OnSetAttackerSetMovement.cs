using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class OnSetAttackerSetMovement : MonoBehaviour, IReceiveSetAttacker
	{
		[SerializeField]
		private bool canMove;

		public void OnSetAttacker(GameObject attacker)
		{
			ExecuteEvents.Execute<IReceiveSetMovement>(attacker, null, (handler, eventData) => handler.OnSetMovement(this.canMove));
		}
	}
}
