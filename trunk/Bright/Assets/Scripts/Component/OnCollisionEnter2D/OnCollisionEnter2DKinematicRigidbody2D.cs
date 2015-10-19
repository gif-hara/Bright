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
	public class OnCollisionEnter2DKinematicRigidbody2D : MonoBehaviour
	{
		void OnCollisionEnter2D(Collision2D other)
		{
			var rigidbody = GetComponentInParent<Rigidbody2D>();
			rigidbody.isKinematic = true;
			rigidbody.transform.parent = other.transform;
		}
	}
}
