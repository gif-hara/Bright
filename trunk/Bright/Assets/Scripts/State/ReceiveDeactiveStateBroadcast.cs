using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class ReceiveDeactiveStateBroadcast : MonoBehaviour, IReceiveDeactiveState
	{
		public void OnDeactiveState()
		{
			for(int i=0, imax=this.transform.childCount; i<imax; i++)
			{
				ExecuteEvents.Execute<IReceiveDeactiveState>(
					this.transform.GetChild(i).gameObject,
					null,
					(handler, eventData) => handler.OnDeactiveState()
					);
			}
		}
	}
}
