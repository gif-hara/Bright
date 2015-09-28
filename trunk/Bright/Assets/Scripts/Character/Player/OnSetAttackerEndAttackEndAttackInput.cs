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
	public class OnSetAttackerEndAttackEndAttackInput : MonoBehaviour, IReceiveSetAttacker
	{
		public void OnSetAttacker(GameObject attacker)
		{
			StartCoroutine(this.EndAttackCoroutine(attacker));
		}

		IEnumerator EndAttackCoroutine(GameObject attacker)
		{
			while(Bright.Input.AttackButton)
			{
				yield return new WaitForEndOfFrame();
			}

			ExecuteEvents.Execute<IReceiveEndAttack>(attacker, null, (handler, eventData) => handler.OnEndAttack());
		}
	}
}
