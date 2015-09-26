using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class EndAttackDelay : MonoBehaviour, IReceiveStartAttack
	{
		[SerializeField]
		private GameObject refTarget;

		[SerializeField]
		private float delay;

		public void OnStartAttack()
		{
			StartCoroutine(this.EndAttackCoroutine());
		}

		IEnumerator EndAttackCoroutine()
		{
			yield return new WaitForSeconds(delay);

			ExecuteEvents.Execute<IReceiveEndAttack>(this.refTarget, null, (handler, eventData) => handler.OnEndAttack());
		}
	}
}
