using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 指定したゲームオブジェクトのアクティブフラグを設定するコンポーネント.
	/// </summary>
	public class OnTriggerExit2DSetActive : MonoBehaviour
	{
		[SerializeField]
		private GameObject target;

		[SerializeField]
		private bool isActive;

		[SerializeField]
		private LayerMask ignoreLayer;

		void OnTriggerExit2D(Collider2D other)
		{
			if(this.ignoreLayer.IsIncluded(other.gameObject))
			{
				return;
			}

			this.target.SetActive(this.isActive);
		}
	}
}
