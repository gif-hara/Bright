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
		[SyncVar]
		private int syncStateType;

		private GameDefine.StateType currentStateType;

		[ClientCallback]
		void Update()
		{
			if(this.currentStateType != (GameDefine.StateType)this.syncStateType)
			{
				this.currentStateType = (GameDefine.StateType)this.syncStateType;
				ExecuteEvents.Execute<IReceiveChangeStateRemotePlayer>(
					this.gameObject,
					null,
					(handler, eventData) => handler.OnChangeStateRemotePlayer(this.currentStateType)
					);
			}
		}

		[Command]
		public void CmdProvideStateTypeToServer(int stateId)
		{
			this.syncStateType = stateId;
		}
	}
}