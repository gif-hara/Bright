using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 移動フラグを設定するイベントをフック出来るインターフェイス.
	/// </summary>
	public interface IReceiveSetMovement : IEventSystemHandler
	{
		void OnSetMovement(bool canMove);
	}
}
