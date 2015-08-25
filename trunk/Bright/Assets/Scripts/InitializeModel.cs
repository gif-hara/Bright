using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	[RequireComponent(typeof(ModelManager))]
	public class InitializeModel : MonoBehaviour
	{
		[SerializeField]
		private Renderer refRenderer;

		// Use this for initialization	
		void Start ()
		{
			GetComponent<ModelManager>().Change(this.refRenderer);
		}
	}
}
