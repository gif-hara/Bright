using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 現在装備中の装備品のクールタイムを設定するコンポーネント.
	/// </summary>
	public class SetCoolTimeCurrentEquipment : MonoBehaviour, IReceiveResetCoolTime
	{
		public void ResetCoolTime()
		{
			PlayerStatus.Instance.InventoryEquipment.ResetCoolTime();
		}
	}
}
