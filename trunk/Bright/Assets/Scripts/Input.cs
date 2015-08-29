using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// Bright用の入力制御クラス.
	/// </summary>
	public static class Input
	{
		private const string LeftName = "Left";

		private const string RightName = "Right";

		public static bool LeftButton
		{
			get
			{
				return UnityEngine.Input.GetButton(LeftName);
			}
		}
		public static bool LeftButtonDown
		{
			get
			{
				return UnityEngine.Input.GetButtonDown(LeftName);
			}
		}

		public static bool RightButton
		{
			get
			{
				return UnityEngine.Input.GetButton(RightName);
			}
		}
		public static bool RightButtonDown
		{
			get
			{
				return UnityEngine.Input.GetButtonDown(RightName);
			}
		}
	}
}
