using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// ダメージを受けるイベントをフック出来るインターフェイス.
	/// </summary>
	public interface IReceiveTakeDamage : IEventSystemHandler
	{
		void OnTakeDamage(GameObject giveObject);
	}
}
