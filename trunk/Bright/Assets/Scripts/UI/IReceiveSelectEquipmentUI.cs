using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 装備品が選択された時のUIイベントをフックするインターフェイス.
	/// </summary>
	public interface IReceiveSelectEquipmentUI : IEventSystemHandler
	{
		void OnSelectEquipment();

		void OnUnselectEquipment();
	}
}
