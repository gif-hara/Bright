using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// プレイヤーデータの同期を行うコンポーネント.
	/// </summary>
	[NetworkSettings(channel = 2, sendInterval=0.0f)]
	public class SyncPlayerData : NetworkBehaviour
	{
		[SyncVar(hook = "SyncStateType")]
		private int syncStateType;

		[Command]
		public void CmdProvideStateTypeToServer(int stateId)
		{
			this.syncStateType = stateId;
		}

		[Client]
		void SyncStateType(int stateType)
		{
			this.syncStateType = stateType;
			ExecuteEvents.Execute<IReceiveChangeStateRemotePlayer>(
				this.gameObject,
				null,
				(handler, eventData) => handler.OnChangeStateRemotePlayer((GameDefine.StateType)this.syncStateType)
				);
		}
	}
}