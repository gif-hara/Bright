using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 装備品データを保持するイベントをフック出来るインターフェイス.
	/// </summary>
	public interface IReceiveSetEquipmentData : IEventSystemHandler
	{
		void OnSetEquipmentData(EquipmentData data);
	}
}
