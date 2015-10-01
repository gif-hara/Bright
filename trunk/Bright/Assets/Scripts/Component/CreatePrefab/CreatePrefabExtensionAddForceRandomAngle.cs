using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnCreatePrefabExtensionイベント時にRigidBody2DのAddForce関数を呼び出すコンポーネント.
	/// </summary>
	public class CreatePrefabExtensionAddForceRandomAngle : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private float minAngle;

		[SerializeField]
		private float maxAngle;

		[SerializeField]
		private float force;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			var rigidBody2D = instance.GetComponent<Rigidbody2D>();
			Assert.IsNotNull(rigidBody2D, "Rigidbody2Dがアタッチされていません instance = " + instance.name);

			var angle = Random.Range(this.minAngle, this.maxAngle) * Mathf.Deg2Rad;
			var direction = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle));
			rigidBody2D.AddForce(direction * this.force);
		}

	}
}
