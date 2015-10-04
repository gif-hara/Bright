using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// バーUIコンポーネント.
	/// </summary>
	public class Bar : MonoBehaviour
	{
		[SerializeField]
		private RectTransform target;

		private Vector2 initialSize;

		void Start()
		{
			this.initialSize = this.target.sizeDelta;
		}

		public void Set(float value)
		{
			this.target.sizeDelta = new Vector2(
				this.initialSize.x * value,
				this.initialSize.y
				);
		}
	}
}
