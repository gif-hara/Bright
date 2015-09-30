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
	[System.Serializable]
	public class DebugInputAction
	{
		[SerializeField]
		private KeyCode keyCode;

		[SerializeField]
		private bool shiftKey;

		[SerializeField]
		private bool controlKey;

		public void Proccess(System.Action functor)
		{
			if(InputShiftKey != shiftKey)
			{
				return;
			}

			if(InputControl != controlKey)
			{
				return;
			}

			if(!InputKeyCode)
			{
				return;
			}

			functor();
		}

		private bool InputShiftKey
		{
			get
			{
				return UnityEngine.Input.GetKey(KeyCode.LeftShift) || UnityEngine.Input.GetKey(KeyCode.RightShift);
			}
		}

		private bool InputControl
		{
			get
			{
				return
					UnityEngine.Input.GetKey(KeyCode.LeftControl) ||
					UnityEngine.Input.GetKey(KeyCode.RightControl) ||
					UnityEngine.Input.GetKey(KeyCode.LeftCommand) ||
					UnityEngine.Input.GetKey(KeyCode.RightCommand);
			}
		}

		private bool InputKeyCode
		{
			get
			{
				return UnityEngine.Input.GetKeyDown(this.keyCode);
			}
		}
	}
}
