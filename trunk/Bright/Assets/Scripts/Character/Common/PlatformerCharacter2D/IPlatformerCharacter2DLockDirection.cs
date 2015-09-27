using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// PlatformerCharacter2Dの向き固定フラグを返す事が出来るインターフェイス.
	/// </summary>
	public interface IPlatformerCharacter2DLockDirection
	{
		bool LockDirection();
	}
}
