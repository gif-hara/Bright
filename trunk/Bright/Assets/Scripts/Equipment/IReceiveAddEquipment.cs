using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 装備品がインベントリの追加されたイベントをフックするインターフェイス.
	/// </summary>
	public interface IReceiveAddEquipment : IEventSystemHandler
	{
		void OnAddEquipment(int id, EquipmentData data);
	}
}