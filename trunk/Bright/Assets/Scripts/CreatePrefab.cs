using UnityEngine;
using System.Collections;

namespace Bright
{
	public class CreatePrefab : MonoBehaviour
	{
		[SerializeField]
		private GameObject prefab;

		// Use this for initialization
		void Start ()
		{
			var instance = Instantiate(this.prefab);
			instance.transform.parent = this.transform;
			instance.transform.localPosition = Vector3.zero;
		}
	}
}