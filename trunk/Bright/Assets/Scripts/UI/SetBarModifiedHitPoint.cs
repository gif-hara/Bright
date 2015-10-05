using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// ヒットポイントからバーを設定するコンポーネント.
	/// </summary>
	public class SetBarModifiedHitPoint : MonoBehaviour, IReceiveModifiedHitPoint
	{
		[SerializeField]
		private Bar target;

		public void OnModifiedHitPoint(int max, int value, int damage)
		{
			this.target.Set((float)value / max);
		}
	}
}
