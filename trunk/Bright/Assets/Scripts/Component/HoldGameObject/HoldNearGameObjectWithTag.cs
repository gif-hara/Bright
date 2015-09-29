using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 近くに存在するゲームオブジェクトを保持するコンポーネント.
	/// </summary>
	public class HoldNearGameObjectWithTag : HoldGameObjectBase
	{
		[SerializeField]
		private string searchTag;

		[SerializeField]
		private float radius;

		[SerializeField]
		private bool alwaysSearch;

		void Update()
		{
			if(this.HoldObject == null || this.alwaysSearch)
			{
				this.HoldObject = this.gameObject.FindGameObjectWithTag(this.searchTag, this.radius);
			}
		}

		void OnDrawGizmosSelected()
		{
			Gizmos.DrawWireSphere(this.transform.position, this.radius);
		}
	}
}
