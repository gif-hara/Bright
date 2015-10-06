using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// ModifiedHitPointイベント時のプロパティを保持するコンポーネント.
	/// </summary>
	public class ModifiedHitPointPropertyHolder : MonoBehaviour, IReceiveModifiedHitPoint
	{
		public int Max{ private set; get; }

		public int Value{ private set; get; }

		public int Damage{ private set; get; }

		public void OnModifiedHitPoint(int max, int value, int damage)
		{
			this.Max = max;
			this.Value = value;
			this.Damage = damage;
		}
	}
}
