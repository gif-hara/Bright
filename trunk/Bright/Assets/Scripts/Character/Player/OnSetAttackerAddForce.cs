using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class OnSetAttackerAddForce : MonoBehaviour, IReceiveSetAttacker
	{
		[SerializeField]
		private float leftAngle;

		[SerializeField]
		private float rightAngle;

		[SerializeField]
		private float force;

		public void OnSetAttacker(GameObject attacker)
		{
			var rigidBody2D = attacker.GetComponent<Rigidbody2D>();
			if(rigidBody2D == null)
			{
				return;
			}

			var angle = attacker.transform.SelectValueFromDirection(leftAngle, rightAngle) * Mathf.Deg2Rad;
			var vector = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
			rigidBody2D.velocity = Vector2.zero;
			rigidBody2D.AddForce(vector * force);
		}
	}
}
