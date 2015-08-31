using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// プレイヤーIDを設定するコンポーネント.
	/// </summary>
	public class SetPlayerId : NetworkBehaviour
	{
		[SyncVar]
		private string uniqueIdentity;

		private NetworkInstanceId networkInstanceId;

		private Transform myTransform;

		// Use this for initialization
		void Awake ()
		{
			this.myTransform = this.transform;
		}
		
		public override void OnStartLocalPlayer ()
		{
			GetNetIdentity();
			SetIdentity();
		}

		public override void OnStartClient ()
		{
			GetNetIdentity();
			SetIdentity();
		}

		[Client]
		void GetNetIdentity()
		{
			networkInstanceId = GetComponent<NetworkIdentity>().netId;
			CmdTellServerMyIdentity(MakeUniqueIdentity());
		}

		void SetIdentity()
		{
			if(!this.isLocalPlayer)
			{
				this.myTransform.name = uniqueIdentity;
			}
			else
			{
				this.myTransform.name = MakeUniqueIdentity();
			}
		}

		string MakeUniqueIdentity()
		{
			return "Player " + networkInstanceId.ToString();
		}

		[Command]
		void CmdTellServerMyIdentity(string name)
		{
			uniqueIdentity = name;
		}
	}
}
