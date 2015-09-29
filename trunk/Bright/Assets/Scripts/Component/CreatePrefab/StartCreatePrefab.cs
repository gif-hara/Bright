using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// Start時にプレハブを生成するコンポーネント.
	/// </summary>
	public class StartCreatePrefab : MonoBehaviour
	{
		[SerializeField]
		private CreatePrefab creator = new CreatePrefab();

		[SerializeField]
		private float delay = 0.0f;

		IEnumerator Start()
		{
			if(this.delay > 0.0f)
			{
				yield return new WaitForSeconds(this.delay);
			}

			this.creator.Create(this.gameObject, this.gameObject);
		}

		public void ChangePrefab(GameObject prefab)
		{
			this.creator.Change(prefab);
		}
	}
}
