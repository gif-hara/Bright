using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// デバッグで武器データを切り替えるコンポーネント.
	/// </summary>
	public class DebugChangeWeaponData : MonoBehaviour
	{
		[SerializeField]
		private DebugInputAction inputAction;

		[SerializeField]
		private WeaponData data;

		void Update()
		{
			this.inputAction.Proccess(() => ObjectFinder.Player.GetComponent<WeaponObserver>().Change(this.data));
		}
	}
}
