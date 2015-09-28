using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public static class TransformExtensions
	{
		public static GameDefine.DirectionType GetDirection(this Transform self)
		{
			return self.lossyScale.x > 0.0f ? GameDefine.DirectionType.Right : GameDefine.DirectionType.Left;
		}

		public static bool IsLookRight(this Transform self)
		{
			return self.GetDirection() == GameDefine.DirectionType.Right;
		}

		public static T SelectValueFromDirection<T>(this Transform self, T left, T right)
		{
			return self.IsLookRight() ? right : left;
		}
	}
}
