using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// PlayerStatusのAddMoneyイベントを登録するコンポーネント.
	/// </summary>
	public class RegistPlayerStatusAddMoneyEvent : MonoBehaviour
	{
		void Start()
		{
			PlayerStatus.Instance.Wallet.RegistAddEvent(this.gameObject);
		}

		void OnDestroy()
		{
			PlayerStatus.Instance.Wallet.RemoveAddEvent(this.gameObject);
		}
	}
}
