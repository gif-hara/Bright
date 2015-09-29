using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 一定間隔でプレハブを生成するコンポーネント.
	/// </summary>
	public class IntervalCreatePrefab : MonoBehaviour
	{
		[SerializeField]
		private CreatePrefab creator;

		[SerializeField]
		private DelayTimer interval;

		void Update()
		{
			this.interval.Update();
			if(!this.interval.Complete)
			{
				return;
			}

			this.creator.Create(this.gameObject, this.gameObject);
			this.interval.Reset();
		}
	}
}
