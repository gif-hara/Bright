using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 他コライダーと衝突したらダメージを与えるコンポーネント.
	/// </summary>
	public class OnTriggerEnter2DGiveDamage : MonoBehaviour, IReceiveSetAttacker
	{
		[SerializeField]
		private GameObject giveObject;

		public Collider2D Other{ private set; get; }

		public void OnSetAttacker(GameObject attacker)
		{
			this.giveObject = attacker;
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			this.Other = other;
			ExecuteEvents.Execute<IReceiveGiveDamage>(this.gameObject, null, (handler, eventData) => handler.OnGiveDamage(this.giveObject, other));
			ExecuteEvents.Execute<IReceiveTakeDamage>(other.gameObject, null, (handler, eventData) => handler.OnTakeDamage(this.giveObject));
		}
	}
}
