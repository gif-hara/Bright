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
	public class OnCollisionEnter2DDestroyAllCollider : MonoBehaviour
	{
		void OnCollisionEnter2D(Collision2D other)
		{
			var colliders = GetComponentInParent<Rigidbody2D>().GetComponentsInChildren<Collider2D>();
			foreach(var c in colliders)
			{
				Destroy(c);
			}
		}
	}
}
