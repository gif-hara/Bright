using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class StateManager : MonoBehaviour
	{
		private GameObject currentState;

		public void Change(GameObject stateObject)
		{
			if(this.currentState == stateObject)
			{
				return;
			}

			if(this.currentState != null)
			{
				ExecuteEvents.Execute<IReceiveDeactiveState>(
					this.currentState,
					null,
					(handler, eventData) => handler.OnDeactiveState()
					);
			}
			this.currentState = stateObject;
			ExecuteEvents.Execute<IReceiveActiveState>(
				this.currentState,
				null,
				(receiveTarget, y) => receiveTarget.OnActiveState()
				);
		}
	}
}
