using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 財布クラス.
	/// </summary>
	public class Wallet
	{
		public int Money{ private set; get; }

		private List<GameObject> addEventReceivers = new List<GameObject>();

		public Wallet()
		{
			this.Money = 0;
		}

		public void Add(int value)
		{
			this.Money += value;
			this.addEventReceivers.ForEach(r => ExecuteEvents.Execute<IReceiveAddMoney>(r, null, (handler, eventData) => handler.OnAddMoney(this.Money, value)));
		}

		public bool IsEnough(int value)
		{
			return this.Money >= value;
		}

		public void RegistAddEvent(GameObject receiver)
		{
			this.addEventReceivers.Add(receiver);
		}

		public void RemoveAddEvent(GameObject receiver)
		{
			this.addEventReceivers.Remove(receiver);
		}
	}
}
