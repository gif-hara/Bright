using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class RendererSwitcher : MonoBehaviour
	{
		private Dictionary<string, Renderer> modelDictionary;

		private Renderer currentRenderer = null;

		void Awake()
		{
			this.modelDictionary = new Dictionary<string, Renderer>();
			var models = GetComponentsInChildren<Renderer>();
			foreach(var model in models)
			{
				this.modelDictionary.Add(model.name, model);
				model.enabled = false;
			}
		}

		public void Change(Renderer renderer)
		{
			if(this.currentRenderer != null)
			{
				this.currentRenderer.enabled = false;
			}

			this.currentRenderer = renderer;
			this.currentRenderer.enabled = true;
		}
	}
}
