using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// OnStartAttackイベント時にプレハブを生成するコンポーネント.
	/// </summary>
	public class CreatePrefabOnStartAttack : NetworkBehaviour, IReceiveStartAttack
	{
		[SerializeField]
		private Transform refParent;

		[SerializeField]
		private GameObject prefab;

		public void OnStartAttack()
		{
			CmdCreatePrefabOnStartAttack();
		}

		[Command]
		void CmdCreatePrefabOnStartAttack()
		{
//			var instance = Instantiate(prefab);
//			instance.transform.parent = this.refParent;
//			instance.transform.localPosition = Vector3.zero;
//			instance.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 500);
			NetworkServer.Spawn(prefab);
		}
	}
}
