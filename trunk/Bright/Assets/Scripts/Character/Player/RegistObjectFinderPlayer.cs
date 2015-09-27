using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// ObjectFinderにPlayerを登録するコンポーネント.
	/// </summary>
	public class RegistObjectFinderPlayer : MonoBehaviour
	{
		void Awake()
		{
			ObjectFinder.Player = this.gameObject;
		}
	}
}
