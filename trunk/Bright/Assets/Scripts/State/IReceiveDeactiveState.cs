using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// ステートが非アクティブになった事を通知するインターフェイス.
	/// </summary>
	public interface IReceiveDeactiveState : IEventSystemHandler
	{
		void OnDeactiveState();
	}
}
