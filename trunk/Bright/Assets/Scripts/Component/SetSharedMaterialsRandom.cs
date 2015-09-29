using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// RendererクラスのSharedMaterialをランダムに設定するコンポーネント.
	/// </summary>
	public class SetSharedMaterialsRandom : MonoBehaviour
	{
		[SerializeField]
		private List<Renderer> renderers;

		[SerializeField]
		private List<Material> materials;

		void Start()
		{
			var sharedMaterial = this.materials[Random.Range(0, this.materials.Count)];
			this.renderers.ForEach(r => r.sharedMaterial = sharedMaterial);
		}
	}
}
