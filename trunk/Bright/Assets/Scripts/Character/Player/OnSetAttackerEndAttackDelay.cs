using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnSetAttackerイベントで攻撃終了処理を行うコンポーネント.
	/// </summary>
	public class OnSetAttackerEndAttackDelay : MonoBehaviour, IReceiveSetAttacker
	{
		[SerializeField]
		private float delay;

		public void OnSetAttacker(GameObject attacker)
		{
			StartCoroutine(this.EndAttackCoroutine(attacker));
		}

		IEnumerator EndAttackCoroutine(GameObject attacker)
		{
			yield return new WaitForSeconds(delay);

			ExecuteEvents.Execute<IReceiveEndAttack>(attacker, null, (handler, eventData) => handler.OnEndAttack());
		}
	}
}
