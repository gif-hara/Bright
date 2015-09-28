using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnTakeDamageイベント時にTriggerCreatePrefabコンポーネントを起動するコンポーネント.
	/// </summary>
	public class OnTakeDamageTriggerCreatePrefab : MonoBehaviour, IReceiveTakeDamage
	{
		[SerializeField]
		private TriggerCreatePrefab trigger;

		public void OnTakeDamage(GameObject giveObject)
		{
			this.trigger.Trigger();
		}
	}
}
