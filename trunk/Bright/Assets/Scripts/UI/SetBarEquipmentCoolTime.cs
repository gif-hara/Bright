using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 装備品のクールタイムをバーに反映するコンポーネント.
	/// </summary>
	public class SetBarEquipmentCoolTime : MonoBehaviour, IReceiveSetEquipmentData
	{
		[SerializeField]
		private Bar target;

		private EquipmentData data;

		public void OnSetEquipmentData(EquipmentData data)
		{
			this.data = data;
		}

		void Update()
		{
			this.target.Set(this.data.NormalizeCoolTime);
		}
	}
}
