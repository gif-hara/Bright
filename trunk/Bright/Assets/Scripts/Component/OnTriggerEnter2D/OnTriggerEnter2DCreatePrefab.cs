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
	public class OnTriggerEnter2DCreatePrefab : MonoBehaviour
	{
		[SerializeField]
		private CreatePrefab creator;

		public Collider2D Other{ private set; get; }

		void OnTriggerEnter2D(Collider2D other)
		{
			this.Other = other;
			this.creator.Create(this.gameObject, this.gameObject);
		}
	}
}
