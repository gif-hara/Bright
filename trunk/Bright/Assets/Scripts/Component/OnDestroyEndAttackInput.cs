using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 攻撃入力処理が終わったら死亡するコンポーネント.
	/// </summary>
	public class OnDestroyEndAttackInput : MonoBehaviour
	{
		[SerializeField]
		private GameObject target;

		[SerializeField]
		private float delay;

		void Update()
		{
			if(Bright.Input.DecideButton)
			{
				return;
			}

			Destroy(this.target, this.delay);
			this.enabled = false;
		}
	}
}
