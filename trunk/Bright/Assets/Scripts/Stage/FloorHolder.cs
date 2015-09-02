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
		private List<Floor> floorPrefabs;
		
		[SerializeField]
		private List<Floor> groundPrefabs;

		[SerializeField]
		private List<Floor> wallPrefabs;

		public Floor GetFloor()
		{
			return this.floorPrefabs[0];
		}

		public Floor GetGround()
		{
			// いずれ色違いの地面とかも作るかも.
			return this.groundPrefabs[0];
		}

		public Floor GetWall()
		{
			return this.wallPrefabs[0];
		}
	}
}
