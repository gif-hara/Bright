using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Bright
{
    public class ChunkHolder : MonoBehaviour
    {
		[SerializeField]
		private List<Chunk> initialChunkPrefabs;

        [SerializeField]
        private List<Chunk> chunkPrefabs;

		public Chunk InitialChunk
		{
			get
			{
				var random = Random.Range(0, this.initialChunkPrefabs.Count);
				return this.initialChunkPrefabs[random];
			}
		}

		public Chunk GetChunkCreator(ChunkDoorway data)
		{
			return null;
		}
    }
}
