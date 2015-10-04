using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 自動でSetActiveを呼び出すコンポーネント.
	/// </summary>
	public class AutoSetActive : MonoBehaviour
	{
		[SerializeField]
		private GameObject target;

		[SerializeField]
		private bool isActive;

		[SerializeField]
		private DelayTimer delay;

		void Update()
		{
			this.delay.Update();

			if(!this.delay.Complete)
			{
				return;
			}

			this.target.SetActive(this.isActive);
			this.enabled = false;
		}
	}
}
