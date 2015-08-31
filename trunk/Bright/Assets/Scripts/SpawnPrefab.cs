using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class SpawnPrefab : NetworkBehaviour
	{
		[SerializeField]
		private GameObject prefab;

		[Server]
		void Start()
		{
			CmdSpawn();
		}

		[Command]
		void CmdSpawn()
		{
			//var instance = Instantiate(prefab);
		}
	}
}
