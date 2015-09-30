using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class DebugChangeScene : MonoBehaviour
	{
		[SerializeField]
		private DebugInputAction inputAction;

		[SerializeField]
		private string sceneName;

		void Update()
		{
			this.inputAction.Proccess(() => Application.LoadLevel(this.sceneName));
		}
	}
}
