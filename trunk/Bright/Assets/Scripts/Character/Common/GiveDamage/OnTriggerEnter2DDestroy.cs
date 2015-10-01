using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 指定したゲームオブジェクトを死亡させるコンポーネント.
	/// </summary>
	public class OnTriggerEnter2DDestroy : MonoBehaviour
	{
		[SerializeField]
		private GameObject target;

		[SerializeField]
		private float delay;

		void OnTriggerEnter2D(Collider2D other)
		{
			Destroy(this.target, this.delay);
		}
	}
}
