using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 装備品を切り替えるイベントをフックするインターフェイス.
	/// </summary>
	public interface IReceiveChangeEquipmentData : IEventSystemHandler
	{
		void OnChangeEquipmentData(int id, EquipmentData data);
	}
}
