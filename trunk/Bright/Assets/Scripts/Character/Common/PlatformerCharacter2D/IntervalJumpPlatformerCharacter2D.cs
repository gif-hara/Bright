using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 一定間隔でジャンプを行うコンポーネント.
	/// </summary>
	public class IntervalJumpPlatformerCharacter2D : MonoBehaviour, IPlatformerCharacter2DJump
	{
		[SerializeField]
		private float min = 0.0f;
		
		[SerializeField]
		private float max = 1.0f;

		private float duration;

		void Start()
		{
			InitializeDuration();
		}

		void Update()
		{
			this.duration -= Time.deltaTime;
		}

		public bool Jump()
		{
			if(this.duration <= 0.0f)
			{
				InitializeDuration();
				return true;
			}

			return false;
		}

		private void InitializeDuration()
		{
			this.duration = Random.Range(this.min, this.max);
		}
	}
}
