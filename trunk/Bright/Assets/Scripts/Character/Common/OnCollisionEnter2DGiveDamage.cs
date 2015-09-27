using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 他コライダーと衝突したらダメージを与えるコンポーネント.
	/// </summary>
	public class OnCollisionEnter2DGiveDamage : MonoBehaviour, IReceiveSetAttacker
	{
		[SerializeField]
		private GameObject giveObject;

		public void OnSetAttacker(GameObject attacker)
		{
			this.giveObject = attacker;
		}

		void OnCollisionEnter2D(Collision2D other)
		{
			if(other.collider.GetComponent<DisableOtherOnGiveDamage>() != null)
			{
				return;
			}

			Debug.Log("GiveDamage other = " + other.gameObject.name);
			ExecuteEvents.Execute<IReceiveGiveDamage>(this.gameObject, null, (handler, eventData) => handler.OnGiveDamage(this.giveObject, other));
		}
	}
}
