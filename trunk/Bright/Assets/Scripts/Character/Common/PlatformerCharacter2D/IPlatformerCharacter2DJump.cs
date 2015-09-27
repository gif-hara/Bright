using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// PlatformerCharacter2Dのジャンプフラグを返す事が出来るインターフェイス.
	/// </summary>
	public interface IPlatformerCharacter2DJump
	{
		bool Jump();
	}
}
