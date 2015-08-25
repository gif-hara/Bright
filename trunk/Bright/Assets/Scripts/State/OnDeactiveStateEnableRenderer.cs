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
		private ModelManager refModelManager;

		[SerializeField]
		private bool isActive;

		public void OnDeactiveState()
		{
			this.refModelManager.Change(this.refRenderer);
		}
	}
}
