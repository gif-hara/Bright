using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// ModifiedHitPointイベント時にダメージ量をテキストに設定するコンポーネント.
	/// </summary>
	public class SetTextModifiedHitPointDamage : MonoBehaviour, IReceiveModifiedHitPoint
	{
		[SerializeField]
		private Text target;

		public void OnModifiedHitPoint(int max, int value, int damage)
		{
			this.target.text = damage.ToString();
		}
	}
}
