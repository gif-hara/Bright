using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class DisableRemotePlayerBehaviours : NetworkBehaviour
	{
		[SerializeField]
		private List<Behaviour> refBehaviours;
		
		// Use this for initialization	
		void Start ()
		{
			if(this.isLocalPlayer)
			{
				return;
			}

			this.refBehaviours.ForEach(b => b.enabled = false);
		}
	}
}
