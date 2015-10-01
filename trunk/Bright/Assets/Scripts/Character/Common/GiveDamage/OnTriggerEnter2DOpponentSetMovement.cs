using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnTriggerEnter2Dイベント時に相手側のSetMoveSenderを実行するコンポーネント.
	/// </summary>
	public class OnTriggerEnter2DOpponentSetMovement : MonoBehaviour
	{
		void OnTriggerEnter2D(Collider2D other)
		{
			var sender = other.gameObject.GetComponent<SetMovementSender>();
			if(sender == null)
			{
				return;
			}

			sender.Send(false);
		}
	}
}
