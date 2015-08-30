using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// OnStartAttackイベント時にプレハブを生成するコンポーネント.
	/// </summary>
	public class CreatePrefabOnStartAttack : MonoBehaviour, IReceiveStartAttack
	{
		[SerializeField]
		private Transform refParent;

		[SerializeField]
		private GameObject prefab;

		public void OnStartAttack()
		{
			var instance = Instantiate(prefab);
			instance.transform.parent = this.refParent;
			instance.transform.localPosition = Vector3.zero;
		}
	}
}
