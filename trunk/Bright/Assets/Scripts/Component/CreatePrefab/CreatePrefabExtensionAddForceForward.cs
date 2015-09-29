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
	public class CreatePrefabExtensionAddForceForward : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private Transform target;

		[SerializeField]
		private float force;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			var rigidBody2D = instance.GetComponent<Rigidbody2D>();
			Assert.IsNotNull(rigidBody2D, "Rigidbody2Dがアタッチされていません instance = " + instance.name);

			rigidBody2D.AddForce(this.target.forward * this.force);
		}
	}
}
