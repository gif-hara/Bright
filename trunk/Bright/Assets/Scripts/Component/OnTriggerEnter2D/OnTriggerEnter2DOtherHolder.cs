using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnTriggerEnter2Dイベント時に衝突したオブジェクトを保持するコンポーネント.
	/// </summary>
	public class OnTriggerEnter2DOtherHolder : MonoBehaviour
	{
		[SerializeField]
		private LayerMask ignoreLayer;

		public Collider2D Other{ private set; get; }

		void OnTriggerEnter2D(Collider2D other)
		{
			if(this.ignoreLayer.IsIncluded(other.gameObject))
			{
				return;
			}

			this.Other = other;
		}

	}
}
