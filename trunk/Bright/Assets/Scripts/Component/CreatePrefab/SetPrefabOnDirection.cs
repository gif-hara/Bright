using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 向きによって生成するプレハブを設定するコンポーネント.
	/// </summary>
	public class SetPrefabOnDirection : MonoBehaviour
	{
		[SerializeField]
		private CreatePrefab createPrefab;

		[SerializeField]
		private GameObject leftPrefab;

		[SerializeField]
		private GameObject rightPrefab;

		void Start()
		{
			var prefab = this.transform.lossyScale.x > 0.0f ? this.rightPrefab : this.leftPrefab;
			this.createPrefab.ChangePrefab(prefab);
		}
	}
}
