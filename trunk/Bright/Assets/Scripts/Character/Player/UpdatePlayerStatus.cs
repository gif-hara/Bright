using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// PlayerStatusクラスの更新処理を行うコンポーネント.
	/// </summary>
	public class UpdatePlayerStatus : MonoBehaviour
	{
		void Update()
		{
			PlayerStatus.Instance.Update();
		}
	}
}
