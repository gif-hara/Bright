using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Bright
{
    public class ChunkHolder : MonoBehaviour
    {
        [SerializeField]
        private List<ChunkCreator> chunkPrefabs;

		public ChunkCreator GetChunkCreator(ChunkDoorway data)
		{
			return null;
		}
    }
}
