using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 攻撃者を設定するイベントにフックするインターフェイス.
	/// </summary>
	public interface IReceiveSetAttacker : IEventSystemHandler
	{
		void OnSetAttacker(GameObject attacker);
	}
}
