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
        private Chunk chunkPrefab;

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

		public const int ChunkSize = 30;

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
        public void CmdCreateFloor(GameObject prefab, int chunkXIndex, int chunkYIndex, int xIndex, int yIndex)
        {
			Assert.IsTrue(
				(xIndex >= 0 && xIndex < ChunkSize) && (yIndex >= 0 && yIndex < ChunkSize),
				string.Format("チャンクサイズを超えています. xIndex = {0} yIndex = {1}", xIndex, yIndex)
				);
            var floor = Instantiate(prefab);
            floor.transform.position = GetPosition(chunkXIndex, chunkYIndex, xIndex, yIndex);

            NetworkServer.Spawn(floor);
        }

        [Command]
		private void CmdNextChunkCollider(int chunkXIndex, int chunkYIndex)
		{
			var nextChunkCollider = Instantiate(this.nextChunkColliderPrefab);
			nextChunkCollider.transform.position = GetPosition(chunkXIndex, chunkYIndex, 0, 0);

			NetworkServer.Spawn(nextChunkCollider);
		}

		//[Command]
		//private void CmdCreateFloorCreator()
		//{
		//	var floorCreator = new FloorCreator(this, (this.floorCreators.Count * FloorCreatorIntervalY) + 1);
		//	this.floorCreators.Add(floorCreator);
		//}

		/// <summary>
		/// 初期チャンクを生成する.
		/// </summary>
		[Server]
		public void CreateInitialChunk()
		{
            //this.CmdCreateFloorCreator();
			var chunk = Instantiate(this.chunkPrefab);
			chunk.Initialize(this, 0, 0);
			this.currentChunkIndex++;
			CmdNextChunkCollider(this.currentChunkIndex, 0);
		}

		public void CreateNextChunk()
		{
			this.currentChunkIndex++;
			CmdNextChunkCollider(this.currentChunkIndex, 0);
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

		public Vector2 GetPosition(int chunkXIndex, int chunkYIndex, int xIndex, int yIndex)
		{
			return new Vector2(xIndex + (chunkXIndex * ChunkSize), yIndex + (chunkYIndex * ChunkSize));
		}

		public static Vector2 GetIndexFromPosition(Vector3 position)
		{
			return new Vector2(position.x / ChunkSize, position.y / ChunkSize);
		}
	}
}
