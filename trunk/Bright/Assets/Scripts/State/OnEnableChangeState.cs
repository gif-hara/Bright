using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// OnEnableイベント時にステートを切り替えるコンポーネント.
	/// </summary>
	public class OnEnableChangeState : MonoBehaviour
	{
		[SerializeField]
		private StateManager stateManager;

		[SerializeField]
		private GameObject stateObject;

		void OnEnable()
		{
			this.stateManager.Change(this.stateObject);
		}
	}
}
