using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class OnDeactiveStateSetActiveGameObject : MonoBehaviour, IReceiveDeactiveState
	{
		[SerializeField]
		private GameObject refTarget;

		[SerializeField]
		private bool isActive;

		public void OnDeactiveState()
		{
			this.refTarget.SetActive(this.isActive);
		}
	}
}
