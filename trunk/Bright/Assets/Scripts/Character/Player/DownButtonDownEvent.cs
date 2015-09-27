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
	public class DownButtonDownEvent : MonoBehaviour
	{
		public delegate void EventFunction();

		private event EventFunction functor = delegate(){};

		void Update()
		{
			if(Bright.Input.DownButtonDown)
			{
				this.functor();
			}
		}

		public void Accept(EventFunction functor)
		{
			this.functor += functor;
		}

		public void Remove(EventFunction functor)
		{
			this.functor -= functor;
		}
	}
}
