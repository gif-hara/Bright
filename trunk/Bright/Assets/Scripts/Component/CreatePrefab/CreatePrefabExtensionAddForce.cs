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
	public class CreatePrefabExtensionAddForce : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private Vector2 direction;

		[SerializeField]
		private float force;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			var rigidBody2D = instance.GetComponent<Rigidbody2D>();
			Assert.IsNotNull(rigidBody2D, "Rigidbody2Dがアタッチされていません instance = " + instance.name);

			this.direction = new Vector2(
				this.direction.x * Mathf.Sign(this.transform.lossyScale.x),
				this.direction.y
				);
			rigidBody2D.AddForce(this.direction * this.force);
		}

		[ContextMenu("Normalize Direction")]
		void Normalize()
		{
			this.direction = this.direction.normalized;
		}
	}
}
