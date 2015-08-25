using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class OnActiveStateSetActiveGameObject : MonoBehaviour, IReceiveActiveState
	{
		[SerializeField]
		private GameObject refTarget;

		[SerializeField]
		private bool isActive;

		public void OnActiveState()
		{
			this.refTarget.SetActive(this.isActive);
		}
	}
}
