using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnDeathイベント時に指定したゲームオブジェクトを死亡するコンポーネント.
	/// </summary>
	public class OnDeathDestroy : MonoBehaviour, IReceiveDeath
	{
		[SerializeField]
		private GameObject destroyObject;

		public void OnDeath()
		{
			Destroy(this.destroyObject);
		}
	}
}
