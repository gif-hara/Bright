using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 武器データを保持するイベントをフック出来るインターフェイス.
	/// </summary>
	public interface IReceiveSetWeaponData : IEventSystemHandler
	{
		void OnSetWeaponData(WeaponData data);
	}
}
