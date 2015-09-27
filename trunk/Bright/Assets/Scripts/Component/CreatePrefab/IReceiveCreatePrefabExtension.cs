using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// プレハブ生成処理の拡張イベントをフックするインターフェイス.
	/// </summary>
	public interface IReceiveCreatePrefabExtension : IEventSystemHandler
	{
		void OnCreatePrefabExtension(GameObject instance);
	}
}
