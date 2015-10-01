using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnTriggerEnter2Dイベントで相手側にダメージを与えるコンポーネント.
	/// </summary>
	public class OnTriggerEnter2DOpponentGiveDamage : MonoBehaviour
	{
		[SerializeField]
		private int damage;

		void OnTriggerEnter2D(Collider2D other)
		{
			var takeDamage = other.gameObject.GetComponent<TakeDamage>();
			if(takeDamage == null)
			{
				return;
			}

			takeDamage.Take(this.damage);
		}
	}
}
