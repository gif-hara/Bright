using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 他コライダーと衝突したらダメージを与えるコンポーネント.
	/// </summary>
	public class OnCollisionEnter2DGiveDamage : MonoBehaviour
	{
		[SerializeField]
		private GameObject giveObject;

		void OnCollisionEnter2D(Collision2D other)
		{
			ExecuteEvents.Execute<IReceiveGiveDamage>(this.gameObject, null, (handler, eventData) => handler.OnGiveDamage(this.giveObject, other));
		}
	}
}
