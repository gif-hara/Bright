using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 指定したゲームオブジェクトのアクティブフラグを設定するコンポーネント.
	/// </summary>
	public class OnTriggerEnter2DSetActive : MonoBehaviour
	{
		[SerializeField]
		private GameObject target;

		[SerializeField]
		private bool isActive;

		void OnTriggerEnter2D(Collider2D other)
		{
			this.target.SetActive(this.isActive);
		}
	}
}
