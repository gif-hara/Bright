using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
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

		public Wallet()
		{
			this.Money = 0;
		}

		public void Add(int value)
		{
			this.Money += value;
			Debug.Log("Money = " + this.Money);
		}

		public bool IsEnough(int value)
		{
			return this.Money >= value;
		}
	}
}
