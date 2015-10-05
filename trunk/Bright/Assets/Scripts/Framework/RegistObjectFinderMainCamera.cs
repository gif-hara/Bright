using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// ObjectFinderのMainCameraに登録するコンポーネント.
	/// </summary>
	public class RegistObjectFinderMainCamera : MonoBehaviour
	{
		void Awake()
		{
			var camera = this.GetComponent<Camera>();
			Assert.IsTrue(camera != null, "Cameraがアタッチされていません. gameObject = " + this.gameObject.name);

			ObjectFinder.MainCamera = camera;
		}
	}
}
