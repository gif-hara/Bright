using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// ダメージを受けるコンポーネント.
	/// </summary>
	public class TakeDamage : MonoBehaviour
	{
		[SerializeField]
		private HitPointController hitPointController;

		public void Take(int damage)
		{
			this.hitPointController.TakeDamage(damage);
		}
	}
}
