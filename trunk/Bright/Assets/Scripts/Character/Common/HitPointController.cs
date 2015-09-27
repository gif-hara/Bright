using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// ヒットポイントを制御するコンポーネント.
	/// </summary>
	public class HitPointController : MonoBehaviour
	{
		[SerializeField]
		private int hitPoint;

		[SerializeField]
		private GameObject deathReceiver;

		//private int max;

		void Awake()
		{
			//this.max = this.hitPoint;
		}

		public void TakeDamage(int damage)
		{
			this.hitPoint -= damage;

			if(this.hitPoint <= 0)
			{
				ExecuteEventsExtensions.Broadcast<IReceiveDeath>(this.deathReceiver, null, (handler, eventData) => handler.OnDeath());
			}
		}
	}
}
