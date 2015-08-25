using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class ChangeStateDelay : MonoBehaviour, IReceiveActiveState, IReceiveDeactiveState
	{
		[SerializeField]
		private GameObject refNextState;

		[SerializeField]
		private float delay;

		public void OnActiveState()
		{
			StartCoroutine(this.ActionCoroutine());
		}

		public void OnDeactiveState()
		{
			StopAllCoroutines();
		}

		private IEnumerator ActionCoroutine()
		{
			yield return new WaitForSeconds(this.delay);

			ExecuteEvents.Execute<IReceiveDeactiveState>(
				this.gameObject,
				null,
				(handler, eventData) => handler.OnDeactiveState()
				);

			ExecuteEvents.Execute<IReceiveActiveState>(
				this.refNextState,
				null,
				(handler, eventData) => handler.OnActiveState()
				);
		}
	}
}
