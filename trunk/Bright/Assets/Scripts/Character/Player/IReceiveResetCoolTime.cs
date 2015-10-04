using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// クールタイムをリセットするイベントをフックするインターフェイス.
	/// </summary>
	public interface IReceiveResetCoolTime : IEventSystemHandler
	{
		void ResetCoolTime();
	}
}
