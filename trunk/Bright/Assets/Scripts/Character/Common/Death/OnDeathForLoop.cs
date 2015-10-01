using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnDeathイベント時にForLookイベントを実行するコンポーネント.
	/// </summary>
	public class OnDeathForLoop : MonoBehaviour, IReceiveDeath
	{
		[SerializeField]
		private ForLoop forloop;

		public void OnDeath()
		{
			this.forloop.Execute();
		}
	}
}
