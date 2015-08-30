using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class EndAttackDelay : MonoBehaviour, IReceiveActiveState
	{
		[SerializeField]
		private GameObject refTarget;

		[SerializeField]
		private float delay;

		public void OnActiveState()
		{
			StartCoroutine(EndAttackCoroutine());
		}

		IEnumerator EndAttackCoroutine()
		{
			yield return new WaitForSeconds(delay);

			ExecuteEvents.ExecuteHierarchy<IReceiveEndAttack>(this.refTarget, null, (handler, eventData) => handler.OnEndAttack());
		}
	}
}
