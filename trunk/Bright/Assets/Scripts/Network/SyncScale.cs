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
		[SerializeField]
		private bool autoProvideToServer;

		[SyncVar]
		private Vector3 syncScale;

		[ClientCallback]
		void Start()
		{
			syncScale = this.transform.localScale;
		}

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
		public void CmdProvideScaleToServer(Vector3 syncScale)
		{
			this.syncScale = syncScale;
		}

		[Client]
		private void TransmitScale()
		{
			if(!this.autoProvideToServer)
			{
				return;
			}

			CmdProvideScaleToServer(this.transform.localScale);
		}

	}
}
