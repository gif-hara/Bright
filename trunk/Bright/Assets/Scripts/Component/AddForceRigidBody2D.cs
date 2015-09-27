using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// Rigidbody2DのAddForce関数を呼び出すコンポーネント.
	/// </summary>
	public class AddForceRigidBody2D : MonoBehaviour
	{
		[SerializeField]
		private Rigidbody2D rigidBody2D;

		[SerializeField]
		private float velocityRate = 0.0f;

		[SerializeField]
		private float forceRate = 1.0f;

		public void AddForce(Vector2 force)
		{
			this.rigidBody2D.velocity *= this.velocityRate;
			this.rigidBody2D.AddForce(force * this.forceRate);
		}
	}
}
