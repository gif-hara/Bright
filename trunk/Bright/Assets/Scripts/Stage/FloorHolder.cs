using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 床プレハブを保持するコンポーネント.
	/// </summary>
	public class FloorHolder : MonoBehaviour
	{
		[SerializeField]
		private List<Floor> groundPrefabs;

		public Floor GetGround()
		{
			// いずれ色違いの地面とかも作るかも.
			return this.groundPrefabs[0];
		}
	}
}
