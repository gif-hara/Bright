using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	[NetworkSettings(channel = 1, sendInterval = 0.0f)]
	public class SyncScale : NetworkBehaviour
	{
		[SyncVar]
		private Vector3 syncScale;

		[ClientCallback]
		void Update()
		{
			if(this.isLocalPlayer)
			{
				TransmitScale();
			}
			else
			{
				this.transform.localScale = this.syncScale;
			}
		}

		[Command]
		private void CmdProvideScaleToServer(Vector3 syncScale)
		{
			this.syncScale = syncScale;
		}

		[Client]
		private void TransmitScale()
		{
			if(this.isLocalPlayer)
			{
				CmdProvideScaleToServer(this.transform.localScale);
			}
		}

	}
}
