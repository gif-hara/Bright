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
		private string sceneName;

		[SerializeField]
		private KeyCode keyCode;

		void Update()
		{
			if(UnityEngine.Input.GetKeyDown(this.keyCode))
			{
				Application.LoadLevel(this.sceneName);
			}
		}
	}
}
