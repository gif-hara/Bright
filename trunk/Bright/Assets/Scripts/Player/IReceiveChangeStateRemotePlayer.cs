using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// リモートプレイヤーのプレイヤーステートが切り替わった際のイベントをフック出来るインターフェイス.
	/// </summary>
	public interface IReceiveChangeStateRemotePlayer : IEventSystemHandler
	{
		void OnChangeStateRemotePlayer(GameDefine.StateType stateType);
	}
}
