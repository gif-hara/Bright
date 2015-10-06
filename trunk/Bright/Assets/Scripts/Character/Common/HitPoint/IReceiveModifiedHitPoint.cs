using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// ヒットポイントが変更された際のイベントをフックするインターフェイス.
	/// </summary>
	public interface IReceiveModifiedHitPoint : IEventSystemHandler
	{
		void OnModifiedHitPoint(int max, int value, int damage);
	}
}
