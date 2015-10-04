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

		public InventoryEquipment InventoryEquipment{ private set; get; }

		private PlayerStatus()
		{
			this.Wallet = new Wallet();
			this.InventoryEquipment = new InventoryEquipment();
		}

		public void Update()
		{
			this.InventoryEquipment.Update();
		}

		public void Initialized()
		{
			this.InventoryEquipment.Initialized();
		}
	}
}
