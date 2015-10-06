using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// ModifiedHitPointイベント時にプレハブを生成するコンポーネント.
	/// </summary>
	public class ModifiedHitPointCreatePrefab : MonoBehaviour, IReceiveModifiedHitPoint
	{
		[SerializeField]
		private TriggerCreatePrefab trigger;

		public void OnModifiedHitPoint(int max, int value, int damage)
		{
			this.trigger.Trigger();
		}
	}
}
