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
		private List<GameObject> modifiedReceiver;

		[SerializeField]
		private GameObject deathReceiver;

		private int max;

		void Awake()
		{
			this.max = this.hitPoint;
		}

		public void TakeDamage(int damage)
		{
			this.hitPoint -= damage;

			this.modifiedReceiver.ForEach(r =>
			{
				ExecuteEventsExtensions.Broadcast<IReceiveModifiedHitPoint>(r, null, (handler, eventData) => handler.OnModifiedHitPoint(this.max, this.hitPoint, damage));
			});

			if(this.hitPoint <= 0)
			{
				ExecuteEventsExtensions.Broadcast<IReceiveDeath>(this.deathReceiver, null, (handler, eventData) => handler.OnDeath());
			}
		}

		public void AddModifiedReceiver(GameObject receiver)
		{
			this.modifiedReceiver.Add(receiver);
		}
	}
}
