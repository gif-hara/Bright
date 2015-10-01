using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 指定した回数分イベントを実行するクラス.
	/// </summary>
	[System.Serializable]
	public class ForLoop
	{
		[SerializeField]
		private int min;

		[SerializeField]
		private int max;

		[SerializeField]
		private UnityEvent functor;

		public void Execute()
		{
			for(int i=min; i<max; i++)
			{
				functor.Invoke();
			}
		}
	}
}
