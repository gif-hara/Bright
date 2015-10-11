using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class OnTriggerEnter2DOtherEvent : MonoBehaviour
	{
		[SerializeField]
		private LayerMask ignoreLayer;
		
		[SerializeField]
		private UnityEvent otherEvent;

		void OnTriggerEnter2D(Collider2D other)
		{
			if(this.ignoreLayer.IsIncluded(other.gameObject))
			{
				return;
			}

			otherEvent.Invoke();
		}
	}
}
