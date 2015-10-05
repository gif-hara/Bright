using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// オブジェクト検索を行うクラス.
	/// </summary>
	public static class ObjectFinder
	{
		public static GameObject Player{ set; get; }

		public static Camera MainCamera{ set; get; }

		public static Camera UICamera{ set; get; }

		public static Canvas MainCanvas{ set; get; }
	}
}
