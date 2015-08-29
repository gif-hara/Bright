using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

namespace Bright
{
	public class AttachPlayerComponent : MonoBehaviour
	{
		[SerializeField]
		private NetworkIdentity networkIdentity;

		void Start()
		{
			var go = gameObject;

			if(this.networkIdentity.isLocalPlayer)
			{
				go.AddComponent<Platformer2DUserControl>();
			}
			else
			{
			}
		}
	}
}