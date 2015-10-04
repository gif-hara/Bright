using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 装備品セレクトIDが変更されたイベントをフックするインターフェイス.
	/// </summary>
	public interface IReceiveModifiedEquipmentSelectId : IEventSystemHandler
	{
		void OnModifiedEquipmentSelectId(int id);
	}
}
