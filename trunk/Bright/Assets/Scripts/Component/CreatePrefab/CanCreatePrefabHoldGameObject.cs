using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// HoldGameObjectクラスがゲームオブジェクトを保持しているか判断してプレハブ生成可能か返すコンポーネント.
	/// </summary>
	public class CanCreatePrefabHoldGameObject : MonoBehaviour, IReceiveCanCreatePrefab
	{
		[SerializeField]
		private HoldGameObjectBase holder;

		[SerializeField]
		private bool holdThenTrue;

		public bool CanCreatePrefab()
		{
			return (this.holder.HoldObject != null) == this.holdThenTrue;
		}
	}
}
