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

		public DelayTimer()
		{
			this.delay = 0.0f;
			this.duration = 0.0f;
		}

		public DelayTimer(DelayTimer other)
		{
			this.delay = other.delay;
			this.duration = other.duration;
		}

		public void Update()
		{
			this.Update(Time.deltaTime);
		}
		public void Update(float t)
		{
			this.duration += t;
			this.duration = this.duration > this.delay ? this.delay : this.duration;
		}

		public void Reset()
		{
			this.duration = 0.0f;
		}

		public bool Complete
		{
			get
			{
				return this.delay <= this.duration;
			}
		}

		public float Normalize
		{
			get
			{
				return this.duration / this.delay;
			}
		}

	}
}
