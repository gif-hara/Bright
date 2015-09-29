using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnGiveDamageイベント時にプレハブを生成するコンポーネント.
	/// </summary>
	public class OnGiveDamageCreatePrefab : MonoBehaviour, IReceiveGiveDamage
	{
		[SerializeField]
		private CreatePrefab creator;

		public void OnGiveDamage(GameObject giveObject, Collider2D takeObject)
		{
			this.creator.Create(this.gameObject, this.gameObject);
		}
	}
}
