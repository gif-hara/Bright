using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 遅延タイマークラス.
	/// </summary>
	[System.Serializable]
	public class DelayTimer
	{
		[SerializeField]
		private float delay;

		private float duration = 0.0f;

		public void Update(float t)
		{
			this.duration += t;
		}

		public void Reset()
		{
			this.duration = 0.0f;
		}

		public bool Complete
		{
			get
			{
				return this.delay < this.duration;
			}
		}
	}
}
