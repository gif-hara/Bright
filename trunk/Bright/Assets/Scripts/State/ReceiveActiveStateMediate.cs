using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class ReceiveActiveStateMediate : MonoBehaviour, IReceiveActiveState
	{
		[SerializeField]
		private GameObject refReceiver;

		public void OnActiveState()
		{
			ExecuteEvents.Execute<IReceiveActiveState>(
				this.refReceiver,
				null,
				(handler, eventData) => handler.OnActiveState()
				);
		}
	}
}
