using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 攻撃終了イベントをキャッチ出来ることを証明するインターフェイス.
	/// </summary>
	public interface IReceiveEndAttack : IEventSystemHandler
	{
		void OnEndAttack();
	}
}
