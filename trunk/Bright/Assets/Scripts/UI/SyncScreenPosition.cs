using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 3Dオブジェクトの座標をスクリーン座標にして同期するコンポーネント.
	/// </summary>
	public class SyncScreenPosition : MonoBehaviour
	{
		[SerializeField]
		private Transform target;

		[SerializeField]
		private RectTransform myTransform;

		private RectTransform parentRectTransform;

		void Start()
		{
			this.parentRectTransform = this.myTransform.parent as RectTransform;
		}

		void Update()
		{
			var screenPosition = ObjectFinder.MainCamera.WorldToScreenPoint(this.target.position);
			var localPosition = Vector2.zero;
			RectTransformUtility.ScreenPointToLocalPointInRectangle(this.parentRectTransform, screenPosition, ObjectFinder.MainCanvas.worldCamera, out localPosition);
			this.myTransform.localPosition = localPosition;
		}

		public void SetTarget(Transform target)
		{
			this.target = target;
		}
	}
}
