using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// Startイベント時にForLoopイベントを実行するコンポーネント.
	/// </summary>
	public class StartForLoop : MonoBehaviour
	{
		[SerializeField]
		private ForLoop forloop;

		void Start()
		{
			this.forloop.Execute();
		}
	}
}
