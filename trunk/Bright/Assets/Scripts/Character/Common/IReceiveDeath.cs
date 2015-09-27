using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 死亡イベントをフックするインターフェイス.
	/// </summary>
	public interface IReceiveDeath : IEventSystemHandler
	{
		void OnDeath();
	}
}
