using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Assertions;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// ステージ管理クラス.
	/// </summary>
	public class StageManager : NetworkBehaviour
	{
		[SerializeField]
		private GameObject blockPrefab;

		[SerializeField]
		private GameObject nextChunkColliderPrefab;

		private Dictionary<int, Dictionary<int, ChunkData>> chunkMap = new Dictionary<int, Dictionary<int, ChunkData>>();

		public static StageManager Instance{ get{ return instance; } }
		private static StageManager instance;

		private const int ChunkSize = 30;

		void Awake()
		{
			if(instance == null)
			{
				instance = this;
			}
		}

		[ServerCallback]
		void Start ()
		{
			this.CreateInitialChunk(0, 0);
		}

		void OnDrawGizmosSelected()
		{
			var halfChunkSize = ChunkSize / 2;
			for(int y=0; y<ChunkSize; y++)
			{
				for(int x=0; x<ChunkSize; x++)
				{
					Gizmos.DrawWireCube(GetPosition(x, y, halfChunkSize, halfChunkSize), new Vector3(ChunkSize, ChunkSize, 0.0f));
				}
			}
		}

		[Command]
		void CmdCreateBlock(GameObject prefab, int xChunk, int yChunk, int xIndex, int yIndex)
		{
			var block = Instantiate(prefab);
			block.transform.position = GetPosition(xChunk, yChunk, xIndex, yIndex);

			NetworkServer.Spawn(block);
		}

		[Command]
		void CmdNextChunkCollider(int xChunk, int yChunk)
		{
			var nextChunkCollider = Instantiate(this.nextChunkColliderPrefab);
			nextChunkCollider.transform.position = GetPosition(xChunk, yChunk, 0, 0);

			NetworkServer.Spawn(nextChunkCollider);
		}

		/// <summary>
		/// 初期チャンクを生成する.
		/// </summary>
		public void CreateInitialChunk(int xChunk, int yChunk)
		{
			for(int x=0; x<ChunkSize; x++)
			{
				this.CmdCreateBlock(this.blockPrefab, xChunk, yChunk, x, ChunkSize / 2);
			}

			for(int y=0; y<ChunkSize / 2; y++)
			{
				this.CmdCreateBlock(this.blockPrefab, xChunk, yChunk, 0, y);
			}
			for(int y=ChunkSize / 2; y<ChunkSize; y++)
			{
				this.CmdCreateBlock(this.blockPrefab, xChunk, yChunk, ChunkSize - 1, y);
			}

			RegistChunkData(xChunk, yChunk);
			CreateNextChunkCollider(xChunk + 1, 0);
		}

		public void CreateRandomChunk(int xChunk, int yChunk)
		{
			for(int x=0; x<ChunkSize; x++)
			{
				this.CmdCreateBlock(this.blockPrefab, xChunk, yChunk, x, ChunkSize - 1);
			}
			
			for(int y=0; y<ChunkSize - 1; y++)
			{
				for(int x=0; x<ChunkSize; x++)
				{
					if(Random.Range(0, 100) < 10)
					{
						this.CmdCreateBlock(this.blockPrefab, xChunk, yChunk, x, y);
					}
				}
			}
			
			RegistChunkData(xChunk, yChunk);
			CreateNextChunkCollider(xChunk + 1, 0);
		}

		public void CreateNextChunkCollider(int xChunk, int yChunk)
		{
			if(this.IsExistChunk(xChunk, yChunk))
			{
				return;
			}

			this.CmdNextChunkCollider(xChunk, yChunk);
		}

		private bool IsExistChunk(int xChunk, int yChunk)
		{
			if(!this.chunkMap.ContainsKey(yChunk))
			{
				return false;
			}

			return this.chunkMap[yChunk].ContainsKey(xChunk);
		}

		private void RegistChunkData(int xChunk, int yChunk)
		{
			Assert.IsFalse(this.IsExistChunk(xChunk, yChunk), "It is a chunk that already exist. xChunk = " + xChunk + " yChunk = " + yChunk);

			if(!this.chunkMap.ContainsKey(yChunk))
			{
				this.chunkMap.Add(yChunk, new Dictionary<int, ChunkData>());
			}

			chunkMap[yChunk].Add(xChunk, new ChunkData(xChunk, yChunk));
		}

		Vector2 GetPosition(int xChunk, int yChunk, int xIndex, int yIndex)
		{
			return new Vector2(xIndex + (xChunk * ChunkSize), -yIndex + (-yChunk * ChunkSize));
		}

		public static Vector2 GetIndexFromPosition(Vector3 position)
		{
			return new Vector2(position.x / ChunkSize, position.y / ChunkSize);
		}
	}
}
