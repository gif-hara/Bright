using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// ObjectFinderのUICameraに登録するコンポーネント.
	/// </summary>
	public class RegistObjectFinderUICamera : MonoBehaviour
	{
		void Awake()
		{
			var camera = this.GetComponent<Camera>();
			Assert.IsTrue(camera != null, "Cameraがアタッチされていません. gameObject = " + this.gameObject.name);

			ObjectFinder.UICamera = camera;
		}
	}
}
