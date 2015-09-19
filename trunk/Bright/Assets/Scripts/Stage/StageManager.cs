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
        private ChunkCreator chunkPrefab;

		public FloorHolder FloorHolder{ get{ return this.floorHolder; } }
		[SerializeField]
		private FloorHolder floorHolder;

		[SerializeField]
		private GameObject nextChunkColliderPrefab;

		private int currentChunkIndex = 0;

		private List<FloorCreator> floorCreators = new List <FloorCreator>();

		private Dictionary<int, Dictionary<int, bool>> chunkMap = new Dictionary<int, Dictionary<int, bool>>();

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
        public void CmdCreateStageObject(GameObject prefab, int chunkXIndex, int chunkYIndex, int xIndex, int yIndex)
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
		public void CmdNextChunkCollider(int chunkXIndex, int chunkYIndex)
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
			CreateChunk(this.chunkPrefab, 0, 0);
			//CmdNextChunkCollider(0, 0);
		}

		public void CreateNextChunk(int chunkXIndex, int chunkYIndex)
		{
			CmdNextChunkCollider(this.currentChunkIndex, 0);
		}

		private void CreateChunk(ChunkCreator chunkPrefab, int chunkXIndex, int chunkYIndex)
		{
			var chunk = Instantiate(this.chunkPrefab);
			chunk.Initialize(this, chunkXIndex, chunkYIndex);
			RegistChunkData(chunkXIndex, chunkYIndex);
		}

		private bool IsExistChunk(int chunkXIndex, int chunkYIndex)
		{
			if(!this.chunkMap.ContainsKey(chunkYIndex))
			{
				return false;
			}

			return this.chunkMap[chunkYIndex].ContainsKey(chunkXIndex);
		}

		private void RegistChunkData(int chunkXIndex, int chunkYIndex)
		{
			Assert.IsFalse(
				this.IsExistChunk(chunkXIndex, chunkYIndex),
				string.Format("既にチャンクが存在しています. chunkXIndex = {0} chunkYIndex = {1}", chunkXIndex, chunkXIndex)
				);

			if(!this.chunkMap.ContainsKey(chunkYIndex))
			{
				this.chunkMap.Add(chunkYIndex, new Dictionary<int, bool>());
			}

			chunkMap[chunkYIndex].Add(chunkXIndex, true);
		}

		public Vector2 GetPosition(int chunkXIndex, int chunkYIndex, int xIndex, int yIndex)
		{
			return new Vector2(xIndex + (chunkXIndex * ChunkSize), yIndex + (chunkYIndex * ChunkSize));
		}

		public static Vector2 GetChunkIndexFromPosition(Vector3 position)
		{
			return new Vector2(position.x / ChunkSize, position.y / ChunkSize);
		}
	}
}
