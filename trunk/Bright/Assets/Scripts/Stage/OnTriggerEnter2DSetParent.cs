using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class OnTriggerEnter2DSetParent : MonoBehaviour
	{
		[SerializeField]
		private Transform child;

		void OnTriggerEnter2D(Collider2D other)
		{
			this.child.parent = other.transform;
		}
	}
}
