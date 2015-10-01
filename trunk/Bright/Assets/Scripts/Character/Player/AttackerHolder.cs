using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnSetAttackerイベントでアタッカーを保持するコンポーネント.
	/// </summary>
	public class AttackerHolder : MonoBehaviour, IReceiveSetAttacker
	{
		public GameObject Attacker{ private set; get; }

		public void OnSetAttacker(GameObject attacker)
		{
			this.Attacker = attacker;
		}
	}
}
