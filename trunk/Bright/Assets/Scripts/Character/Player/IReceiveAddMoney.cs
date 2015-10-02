using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// コイン追加イベントをフックするインターフェイス.
	/// </summary>
	public interface IReceiveAddMoney : IEventSystemHandler
	{
		void OnAddMoney(int total, int addValue);
	}
}
