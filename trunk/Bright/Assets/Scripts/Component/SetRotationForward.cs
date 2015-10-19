using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 前方へ向くコンポーネント.
	/// </summary>
	public class SetRotationForward : MonoBehaviour
	{
		[SerializeField]
		private Vector3 offset;

		[SerializeField]
		private float tolerance;

		private Vector3 oldPosition;

		void Start()
		{
			oldPosition = this.transform.position;
		}

		void LateUpdate()
		{
			var forward = (this.transform.position - this.oldPosition);
			if(forward.sqrMagnitude < (this.tolerance * this.tolerance))
			{
				return;
			}

			this.transform.rotation = Quaternion.LookRotation(forward);
			this.transform.rotation *= Quaternion.Euler(this.offset);
			this.oldPosition = this.transform.position;
		}
	}
}
