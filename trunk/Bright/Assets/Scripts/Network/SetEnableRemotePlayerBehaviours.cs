using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class SetEnableRemotePlayerBehaviours : MonoBehaviour
	{
		[SerializeField]
		private NetworkIdentity refNetworkIdentity;

		[SerializeField]
		private bool isActive;

		[SerializeField]
		private List<Behaviour> refBehaviours;
		
		// Use this for initialization	
		void Start ()
		{
			if(this.refNetworkIdentity.isLocalPlayer)
			{
				return;
			}

			this.refBehaviours.ForEach(b => b.enabled = isActive);
		}
	}
}
