using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 床オブジェクトクラス.
	/// </summary>
	public class Floor : MonoBehaviour
	{
		public int Width{ get{ return this.width; } }
		[SerializeField]
		private int width;

		public int Height{ get{ return this.height; } }
		[SerializeField]
		private int height;
	}
}
