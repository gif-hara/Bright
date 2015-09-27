using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 確率クラス.
	/// </summary>
	[System.Serializable]
	public class Probability
	{
		[SerializeField][Range(0.0f, 1.0f)]
		private float value = 1.0f;

		public bool IsWinning
		{
			get
			{
				return Random.value <= this.value;
			}
		}
	}
}
