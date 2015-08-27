using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
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
