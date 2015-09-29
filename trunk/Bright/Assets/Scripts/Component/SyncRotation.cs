using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 回転の同期を取るコンポーネント.
	/// </summary>
	public class SyncRotation : MonoBehaviour
	{
		[SerializeField]
		private Transform target;

		[SerializeField]
		private float smooth;

		void Update()
		{
			this.transform.rotation = Quaternion.Lerp(this.transform.rotation, this.target.rotation, this.smooth * Time.deltaTime);
		}
	}
}
