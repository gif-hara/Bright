using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// RenderSwitcherで最初に描画するRendererを決定するコンポーネント.
	/// </summary>
	[RequireComponent(typeof(RendererSwitcher))]
	public class EnterRendererSwitcher : MonoBehaviour
	{
		[SerializeField]
		private Renderer refRenderer;

		// Use this for initialization	
		void Start ()
		{
			GetComponent<RendererSwitcher>().Change(this.refRenderer);
		}
	}
}
