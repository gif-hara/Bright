using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright  
{
	/// <summary>
	/// HitPointControllerのModifiedReceiverに登録するコンポーネント.
	/// </summary>
	public class AddHitPointControllerModifiedReceiver : MonoBehaviour
	{
		[SerializeField]
		private HitPointController controller;

		void Start()
		{
			controller.AddModifiedReceiver(this.gameObject);
		}
	}
}
