using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// プレイヤーステータスクラス.
	/// </summary>
	public class PlayerStatus
	{
		public Wallet Wallet{ private set; get; }

		public PlayerStatus()
		{
			this.Wallet = new Wallet();
		}
	}
}
