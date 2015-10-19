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
	public class OnCollisionEnter2DSetActive : MonoBehaviour
	{
		[SerializeField]
		private GameObject target;

		[SerializeField]
		private bool isActive;

		void OnCollisionEnter2D(Collision2D other)
		{
			this.target.SetActive(isActive);
		}
	}
}
