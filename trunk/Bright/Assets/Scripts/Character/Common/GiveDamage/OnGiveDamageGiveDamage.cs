using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnGiveDamageイベントでダメージを与えるコンポーネント.
	/// </summary>
	public class OnGiveDamageGiveDamage : MonoBehaviour, IReceiveGiveDamage
	{
		[SerializeField]
		private int damage;

		public void OnGiveDamage(GameObject giveObject, Collider2D takeObject)
		{
			var takeDamage = takeObject.gameObject.GetComponent<TakeDamage>();
			if(takeDamage == null)
			{
				return;
			}

			takeDamage.Take(this.damage);
		}
	}
}
