using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 装備品の名前をテキストに設定するコンポーネント.
	/// </summary>
	public class SetTextEquipmentName : MonoBehaviour, IReceiveSetEquipmentData
	{
		[SerializeField]
		private Text target;

		public void OnSetEquipmentData(EquipmentData data)
		{
			this.target.text = data.EquipmentName;
		}
	}
}
