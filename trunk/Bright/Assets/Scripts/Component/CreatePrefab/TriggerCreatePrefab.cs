using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 他のスクリプトからプレハブ生成を行うコンポーネント.
	/// </summary>
	public class TriggerCreatePrefab : MonoBehaviour
	{
		[SerializeField]
		private CreatePrefab creator;

		public void Trigger()
		{
			this.creator.Create(this.gameObject, this.gameObject);
		}

		public void ChangePrefab(GameObject prefab)
		{
			this.creator.Change(prefab);
		}
	}
}
