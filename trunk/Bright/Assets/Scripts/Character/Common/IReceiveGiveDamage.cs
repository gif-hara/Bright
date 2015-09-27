using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// ダメージを与えるイベントをフック出来るインターフェイス.
	/// </summary>
	public interface IReceiveGiveDamage : IEventSystemHandler
	{
		void OnGiveDamage(GameObject giveObject, Collider2D takeObject);
	}
}
