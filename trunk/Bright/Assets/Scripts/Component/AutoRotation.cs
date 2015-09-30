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
	public class AutoRotation : MonoBehaviour
	{
		[SerializeField]
		private Vector3 axis;

		[SerializeField]
		private float speed;

		[ContextMenu("Normalize Axis")]
		void NormalizeAxis()
		{
			this.axis = this.axis.normalized;
		}

		void Update()
		{
			this.transform.rotation *= Quaternion.Euler(axis * (speed * Time.deltaTime));
		}

	}
}
