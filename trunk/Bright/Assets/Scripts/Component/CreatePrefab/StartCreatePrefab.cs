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

		void Start()
		{
			this.creator.Create(this.gameObject);
		}

		public void ChangePrefab(GameObject prefab)
		{
			this.creator.Change(prefab);
		}
	}
}
