using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// サーバーのやり取りテストコンポーネント.
	/// </summary>
	public class ServerTest : NetworkBehaviour
	{
		[ClientCallback]
		void Update ()
		{
			if(UnityEngine.Input.GetKeyDown(KeyCode.Q))
			{
				CmdTest();
			}
			if(UnityEngine.Input.GetKeyDown(KeyCode.W))
			{
				_ServerTest();
			}
		}

		public override void OnStartServer ()
		{
			base.OnStartServer ();
			Debug.Log("OnStartServer");
		}

		[Command]
		public void CmdTest()
		{
			Debug.Log("Command");
		}

		[Server]
		public void _ServerTest()
		{
			Debug.Log("Server");
		}
	}
}
