using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// プレハブを生成可能か返すインターフェイス.
	/// </summary>
	public interface IReceiveCanCreatePrefab : IEventSystemHandler
	{
		bool CanCreatePrefab();
	}
}
