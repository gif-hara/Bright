using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnGiveDamageイベント時にOnSetMovementイベントを通知するコンポーネント.
	/// </summary>
	public class OnGiveDamageSetMovement : MonoBehaviour, IReceiveGiveDamage
	{
		public void OnGiveDamage(GameObject giveObject, Collision2D takeObject)
		{
			ExecuteEvents.Execute<IReceiveSetMovement>(takeObject.gameObject, null, (handler, eventData) => handler.OnSetMovement(false));
		}
	}
}
