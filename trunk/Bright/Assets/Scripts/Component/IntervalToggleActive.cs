using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 間隔でゲームオブジェクトのアクティブフラグをトグルするコンポーネント.
	/// </summary>
	public class IntervalToggleActive : MonoBehaviour
	{
		[SerializeField]
		private GameObject target;

		[SerializeField]
		private DelayTimer interval;

		void Update()
		{
			this.interval.Update();
			if(!this.interval.Complete)
			{
				return;
			}

			this.target.SetActive(!this.target.activeSelf);
			this.interval.Reset();
		}
	}
}
