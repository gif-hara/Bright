using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// SelectEquipmentUI系イベント時にImageクラスの色を設定するコンポーネント.
	/// </summary>
	public class SetImageColorSelectEquipmentUI : MonoBehaviour, IReceiveSelectEquipmentUI
	{
		[SerializeField]
		private Image target;

		[SerializeField]
		private Color selectColor;

		[SerializeField]
		private Color unselectColor;

		public void OnSelectEquipment()
		{
			this.target.color = this.selectColor;
		}
		
		public void OnUnselectEquipment()
		{
			this.target.color = this.unselectColor;
		}
	}
}
