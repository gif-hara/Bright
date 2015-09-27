using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnSetMovementイベントを通知するコンポーネント.
	/// </summary>
	public class SetMovementSender : MonoBehaviour
	{
		[SerializeField]
		private GameObject receiver;

		public void Send(bool canMove)
		{
			ExecuteEvents.Execute<IReceiveSetMovement>(receiver, null, (handler, eventData) => handler.OnSetMovement(canMove));
		}
	}
}
