using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// ゲームオブジェクトを保持する抽象コンポーネント.
	/// </summary>
	public class HoldGameObjectBase : MonoBehaviour
	{
		public GameObject HoldObject{ protected set; get; }
	}
}
