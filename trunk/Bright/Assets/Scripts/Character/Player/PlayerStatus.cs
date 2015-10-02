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
		public static PlayerStatus Instance
		{
			get
			{
				instance = instance ?? new PlayerStatus();
				return instance;
			}
		}
		private static PlayerStatus instance;

		public Wallet Wallet{ private set; get; }

		private PlayerStatus()
		{
			this.Wallet = new Wallet();
		}
	}
}
