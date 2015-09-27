using UnityEngine;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

namespace Bright
{
	/// <summary>
	/// Bright用の入力制御クラス.
	/// </summary>
	public static class Input
	{
		private const string LeftName = "Left";

		private const string RightName = "Right";

		private const string DownName = "Down";

		private const string AttackName = "Attack";

		public static bool LeftButton
		{
			get
			{
				return CrossPlatformInputManager.GetButton(LeftName);
			}
		}
		public static bool LeftButtonDown
		{
			get
			{
				return CrossPlatformInputManager.GetButtonDown(LeftName);
			}
		}

		public static bool RightButton
		{
			get
			{
				return CrossPlatformInputManager.GetButton(RightName);
			}
		}
		public static bool RightButtonDown
		{
			get
			{
				return CrossPlatformInputManager.GetButtonDown(RightName);
			}
		}
		
		public static bool DownButton
		{
			get
			{
				return CrossPlatformInputManager.GetButton(DownName);
			}
		}
		public static bool DownButtonDown
		{
			get
			{
				return CrossPlatformInputManager.GetButtonDown(DownName);
			}
		}
		
		public static bool JumpButtonDown
		{
			get
			{
				return CrossPlatformInputManager.GetButtonDown("Jump");
			}
		}

		public static bool AttackButton
		{
			get
			{
				return CrossPlatformInputManager.GetButton(AttackName);
			}
		}
		public static bool AttackButtonDown
		{
			get
			{
				return CrossPlatformInputManager.GetButtonDown(AttackName);
			}
		}
	}
}
