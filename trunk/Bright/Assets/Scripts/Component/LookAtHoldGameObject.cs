using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 近くにいるオブジェクトを注視するコンポーネント.
	/// </summary>
	public class LookAtHoldGameObject : MonoBehaviour
	{
		[SerializeField]
		private HoldGameObjectBase holder;

		void LateUpdate()
		{
			if(this.holder.HoldObject == null)
			{
				return;
			}

			this.transform.LookAt(this.holder.HoldObject.transform);
		}
	}
}
