using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// ObjectFinderのMainCanvasに登録するコンポーネント.
	/// </summary>
	public class RegistObjectFinderMainCanvas : MonoBehaviour
	{
		void Awake()
		{
			var canvas = this.GetComponent<Canvas>();
			Assert.IsTrue(canvas != null, "Canvasがアタッチされていません. gameObject = " + this.gameObject.name);

			ObjectFinder.MainCanvas = canvas;
		}
	}
}
