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
		public void OnGiveDamage(GameObject giveObject, Collider2D takeObject)
		{
			var sender = takeObject.gameObject.GetComponent<SetMovementSender>();
			if(sender == null)
			{
				return;
			}

			sender.Send(false);
		}
	}
}
