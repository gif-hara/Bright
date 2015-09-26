using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 着地イベントをフックするコンポーネント.
	/// </summary>
	public interface IReceiveLanding : IEventSystemHandler
	{
		void OnLanding();
	}
}
