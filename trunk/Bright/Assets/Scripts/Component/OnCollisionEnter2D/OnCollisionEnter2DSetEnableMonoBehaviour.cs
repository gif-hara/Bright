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
	public class OnCollisionEnter2DSetEnableMonoBehaviour : MonoBehaviour
	{
		[SerializeField]
		private MonoBehaviour target;

		[SerializeField]
		private bool isActive;

		void OnCollisionEnter2D(Collision2D other)
		{
			this.target.enabled = isActive;
		}
	}
}
