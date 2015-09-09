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
		public FloorHolder FloorHolder{ get{ return this.floorHolder; } }
		[SerializeField]
		private FloorHolder floorHolder;

		[SerializeField]
		private GameObject nextChunkColliderPrefab;

		private int currentChunkIndex = 0;

		private List<FloorCreator> floorCreators = new List <FloorCreator>();

		private Dictionary<int, Dictionary<int, ChunkData>> chunkMap = new Dictionary<int, Dictionary<int, ChunkData>>();

		public static StageManager Instance{ get{ return instance; } }
		private static StageManager instance;

		private const int ChunkSize = 30;

		private const int FloorCreatorIntervalY = 6;

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
			this.CreateInitialChunk();
		}

//		void OnDrawGizmosSelected()
//		{
//			var halfChunkSize = ChunkSize / 2;
//			for(int y=0; y<ChunkSize; y++)
//			{
//				for(int x=0; x<ChunkSize; x++)
//				{
//					Gizmos.DrawWireCube(GetPosition(x, y, halfChunkSize, halfChunkSize), new Vector3(ChunkSize, ChunkSize, 0.0f));
//				}
//			}
//		}

		[Command]
		public void CmdCreateFloor(GameObject prefab, int xIndex, int yIndex)
		{
			var floor = Instantiate(prefab);
			floor.transform.position = GetPosition(this.currentChunkIndex, xIndex, yIndex);

			NetworkServer.Spawn(floor);
		}

		[Command]
		private void CmdNextChunkCollider(int chunkIndex)
		{
			var nextChunkCollider = Instantiate(this.nextChunkColliderPrefab);
			nextChunkCollider.transform.position = GetPosition(chunkIndex, 0, 0);

			NetworkServer.Spawn(nextChunkCollider);
		}

		[Command]
		private void CmdCreateFloorCreator()
		{
			var floorCreator = new FloorCreator(this, (this.floorCreators.Count * FloorCreatorIntervalY) + 1);
			this.floorCreators.Add(floorCreator);
		}

		/// <summary>
		/// 初期チャンクを生成する.
		/// </summary>
		[Server]
		public void CreateInitialChunk()
		{
			this.CreateGround();
			this.CreateWall(0);
			this.CmdCreateFloorCreator();

			this.currentChunkIndex++;
			CmdNextChunkCollider(this.currentChunkIndex);
		}

		public void CreateNextChunk()
		{
			this.CreateGround();
			this.CreateFloorCreator();
			this.UpdateFloorCreators();
			this.currentChunkIndex++;
			CmdNextChunkCollider(this.currentChunkIndex);
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

		private void CreateGround()
		{
			this.CmdCreateFloor(this.floorHolder.GetGround().gameObject, 0, 0);
		}

		private void CreateWall(int x)
		{
			this.CmdCreateFloor(this.floorHolder.GetWall().gameObject, x, ChunkSize - 1);
		}

		private void CreateFloorCreator()
		{
			if((this.currentChunkIndex / 3) < this.floorCreators.Count)
			{
				return;
			}

			this.CmdCreateFloorCreator();
		}
		private void UpdateFloorCreators()
		{
			this.floorCreators.ForEach(creator =>
			{
				creator.Calculate(ChunkSize);
			});
		}

		private Vector2 GetPosition(int chunkIndex, int xIndex, int yIndex)
		{
			return new Vector2(xIndex + (chunkIndex * ChunkSize), yIndex);
		}

		public static Vector2 GetIndexFromPosition(Vector3 position)
		{
			return new Vector2(position.x / ChunkSize, position.y / ChunkSize);
		}
	}
}
