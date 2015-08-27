using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class OnDeactiveStateEnableRenderer : MonoBehaviour, IReceiveDeactiveState
	{
		[SerializeField]
		private Renderer refRenderer;

		[SerializeField]
		private RendererSwitcher refRendererSwitcher;

		[SerializeField]
		private bool isActive;

		public void OnDeactiveState()
		{
			this.refRendererSwitcher.Change(this.refRenderer);
		}
	}
}
