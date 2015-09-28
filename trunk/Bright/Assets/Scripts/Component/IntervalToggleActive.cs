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
		private float interval;

		private float duration = 0.0f;

		void Update()
		{
			if(this.duration < this.interval)
			{
				this.duration += Time.deltaTime;
				return;
			}

			this.duration = 0.0f;
			this.target.SetActive(!this.target.activeSelf);
		}
	}
}
