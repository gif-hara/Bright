using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// OnGiveDamageイベントでダメージを与えるオブジェクトの剛体に反対方向へ力を加えるコンポーネント.
	/// </summary>
	public class OnGiveDamageAddForceReverce : MonoBehaviour, IReceiveGiveDamage
	{
		[SerializeField]
		private float force = 750.0f;

		public void OnGiveDamage(GameObject giveObject, Collider2D takeObject)
		{
			var addForceRigidBody2D = takeObject.GetComponent<AddForceRigidBody2D>();
			if(addForceRigidBody2D == null)
			{
				return;
			}
			addForceRigidBody2D.AddForce(ReverceVelocity(giveObject.transform.position, takeObject.transform.position) * force);
		}

		private Vector2 ReverceVelocity(Vector3 my, Vector3 target)
		{
			return new Vector2(Mathf.Sign(target.x - my.x), 1.0f).normalized;
		}
	}
}
