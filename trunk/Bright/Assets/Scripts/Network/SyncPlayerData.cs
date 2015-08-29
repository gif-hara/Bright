using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// プレイヤーデータの同期を行うコンポーネント.
	/// </summary>
	[NetworkSettings(channel = 1, sendInterval=0.0f)]
	public class SyncPlayerData : NetworkBehaviour
	{
		public GameDefine.StateType StateType{ get{ return (GameDefine.StateType)this.stateType; } }
		[SyncVar]
		private int stateType;

		[Command]
		public void CmdProvideStateTypeToServer(int stateId)
		{
			this.stateType = stateId;
		}
	}
}