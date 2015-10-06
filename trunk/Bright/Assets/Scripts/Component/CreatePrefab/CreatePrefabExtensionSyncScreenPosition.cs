using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// CreatePrefabExtensionイベント時にスクリーン座標と同期を取るコンポーネント.
	/// </summary>
	public class CreatePrefabExtensionSyncScreenPosition : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private Transform target;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			var rectTransform = instance.transform as RectTransform;
			Assert.IsTrue(rectTransform != null);

			rectTransform.localPosition = RectTransformUtilityExtensions.ScreenPoint(
				ObjectFinder.MainCamera,
				this.target.position,
				rectTransform.parent as RectTransform,
				ObjectFinder.MainCanvas
				);
		}
	}
}
