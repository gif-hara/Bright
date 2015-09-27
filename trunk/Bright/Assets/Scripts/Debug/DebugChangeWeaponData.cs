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
		private WeaponData data;

		[SerializeField]
		private KeyCode keyCode;

		void Update()
		{
			if(UnityEngine.Input.GetKeyDown(this.keyCode))
			{
				ObjectFinder.Player.GetComponent<WeaponObserver>().Change(this.data);
			}
		}
	}
}
