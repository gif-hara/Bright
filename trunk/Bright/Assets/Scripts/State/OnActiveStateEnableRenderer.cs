using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class OnActiveStateEnableRenderer : MonoBehaviour, IReceiveActiveState
	{
		[SerializeField]
		private Renderer refRenderer;

		[SerializeField]
		private ModelManager refModelManager;

		[SerializeField]
		private bool isActive;

		public void OnActiveState()
		{
			this.refModelManager.Change(this.refRenderer);
		}
	}
}
