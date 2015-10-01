using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// OnTriggerEnter2Dイベント時に相手側の剛体にAddForceするコンポーネント.
	/// </summary>
	public class OnTriggerEnter2DOpponentAddForceReverce : MonoBehaviour
	{
		[SerializeField]
		private float force = 750.0f;

		[SerializeField]
		private AttackerHolder attackerHolder;

		void OnTriggerEnter2D(Collider2D other)
		{
			var addForceRigidBody2D = other.GetComponent<AddForceRigidBody2D>();
			if(addForceRigidBody2D == null)
			{
				return;
			}
			addForceRigidBody2D.AddForce(ReverceVelocity(this.GiveObject.transform.position, other.transform.position) * force);
		}

		private Vector2 ReverceVelocity(Vector3 my, Vector3 target)
		{
			return new Vector2(Mathf.Sign(target.x - my.x), 1.0f).normalized;
		}

		private GameObject GiveObject
		{
			get
			{
				return this.attackerHolder != null ? this.attackerHolder.Attacker : this.gameObject;
			}
		}
	}
}
