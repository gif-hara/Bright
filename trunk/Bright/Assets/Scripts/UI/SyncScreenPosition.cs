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
			this.myTransform.localPosition = RectTransformUtilityExtensions.ScreenPoint(
				ObjectFinder.MainCamera,
				this.target.position,
				this.parentRectTransform,
				ObjectFinder.MainCanvas
				);
		}

		public void SetTarget(Transform target)
		{
			this.target = target;
		}
	}
}
