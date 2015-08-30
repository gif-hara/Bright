using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// OnStartAttackイベントを実行するコンポーネント.
	/// </summary>
	public class ExecuteOnStartAttack : MonoBehaviour
	{
		[SerializeField]
		private GameObject receiver;

		public void Execute()
		{
			ExecuteEvents.Execute<IReceiveStartAttack>(
				this.receiver,
				null,
				(handler, eventData) => handler.OnStartAttack()
				);
		}
	}
}
