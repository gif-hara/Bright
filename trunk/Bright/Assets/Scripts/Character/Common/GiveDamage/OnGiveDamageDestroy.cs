using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 指定したゲームオブジェクトを死亡させるコンポーネント.
	/// </summary>
	public class OnGiveDamageDestroy : MonoBehaviour, IReceiveGiveDamage
	{
		[SerializeField]
		private GameObject target;

		[SerializeField]
		private float delay;

		public void OnGiveDamage(GameObject giveObject, Collider2D takeObject)
		{
			Destroy(this.target, this.delay);
		}
	}
}
