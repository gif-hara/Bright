using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnTriggerEnter2Dイベントでお金を加算するコンポーネント.
	/// </summary>
	public class OnTriggerEnter2DAddMoney : MonoBehaviour
	{
		[SerializeField]
		private LayerMask ignoreLayer;

		[SerializeField]
		private int value;

		void OnTriggerEnter2D(Collider2D other)
		{
			if(this.ignoreLayer.IsIncluded(other.gameObject))
			{
				return;
			}

			PlayerStatus.Instance.Wallet.Add(this.value);
		}
	}
}
