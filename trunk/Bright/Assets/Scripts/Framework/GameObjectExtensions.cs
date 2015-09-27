using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// GameObjectの拡張クラス.
	/// </summary>
	public static class GameObjectExtensions
	{
		public static bool IsPlayerTag(this GameObject self)
		{
			return self.CompareTag("Player");
		}
	}
}
