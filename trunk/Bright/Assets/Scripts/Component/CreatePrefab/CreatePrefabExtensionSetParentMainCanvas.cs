using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// CreatePrefabExtensionイベント時に親オブジェクトをMainCanvasに設定するコンポーネント.
	/// </summary>
	public class CreatePrefabExtensionSetParentMainCanvas : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		public void OnCreatePrefabExtension(GameObject instance)
		{
			instance.transform.SetParent(ObjectFinder.MainCanvas.transform, false);
		}
	}
}
