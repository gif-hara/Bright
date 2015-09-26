using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 攻撃開始イベントをキャッチ出来ることを証明するインターフェイス.
	/// </summary>
	public interface IReceiveStartAttack : IEventSystemHandler
	{
		void OnStartAttack();
	}
}
