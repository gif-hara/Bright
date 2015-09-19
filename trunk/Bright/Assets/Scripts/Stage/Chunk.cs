using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// チャンクコンポーネント.
	/// </summary>
	public class Chunk : MonoBehaviour
	{
		public ChunkDoorway Doorway{ get{ return this.doorway; } }
		[SerializeField]
		private ChunkDoorway doorway;

		public NextCreateChunk NextCreateChunk{ get{ return this.nextCreateChunk; } }
		[SerializeField]
		private NextCreateChunk nextCreateChunk;
	}
}
