using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// クールタイムを設定するイベントをフックするインターフェイス.
	/// </summary>
	public interface IReceiveSetCoolTime : IEventSystemHandler
	{
		void SetCoolTime(float coolTime);
	}
}
