using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class TweenPosition2D : MonoBehaviour
	{
		[SerializeField]
		private Transform target;

		[SerializeField]
		private Vector2 from;

		[SerializeField]
		private Vector2 to;
		
		[SerializeField]
		private AnimationCurve curve;

		[SerializeField]
		private float duration;

		[SerializeField]
		private bool loop;

		private float currentDuration = 0.0f;

		// Use this for initialization
		void Start ()
		{
			if(this.target == null)
			{
				this.target = this.transform;
			}
		}
		
		// Update is called once per frame
		void Update ()
		{
			this.target.localPosition = Vector2.Lerp(this.from, this.to, this.curve.Evaluate(this.currentDuration / this.duration));
			this.currentDuration += Time.deltaTime;
			if(this.currentDuration > this.duration)
			{
				if(this.loop)
				{
					this.currentDuration = 0.0f;
				}
				else
				{
					this.enabled = false;
					this.target.localPosition = Vector2.Lerp(this.from, this.to, 1.0f);
				}
			}
		}
	}
}
