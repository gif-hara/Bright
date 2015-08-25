using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// ステートがアクティブになった事を通知するインターフェイス.
	/// </summary>
	public interface IReceiveActiveState : IEventSystemHandler
	{
		void OnActiveState();
	}
}
