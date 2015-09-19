using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// ステージ管理クラス.
	/// </summary>
	public class StageManager : MonoBehaviour
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

		private Dictionary<int, Dictionary<int, bool>> chunkMap = new Dictionary<int, Dictionary<int, bool>>();

		public const int ChunkSize = 30;

		private const int FloorCreatorIntervalY = 6;

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

        public void CreateStageObject(Transform parent, GameObject prefab, Point chunkIndex, Point position)
        {
			Assert.IsTrue(
				(position.X >= 0 && position.X < ChunkSize) && (position.Y >= 0 && position.Y < ChunkSize),
				string.Format("チャンクサイズを超えています. xIndex = {0} yIndex = {1}", position.X, position.Y)
				);
            var obj = Instantiate(prefab);
			obj.transform.parent = parent;
			obj.transform.position = GetPosition(chunkIndex.X, chunkIndex.Y, position.X, position.Y);
        }

		public void CmdNextChunkCollider(Point chunkIndex)
		{
			var nextChunkCollider = Instantiate(this.nextChunkColliderPrefab);
			nextChunkCollider.transform.position = GetPosition(chunkIndex.X, chunkIndex.Y, 0, 0);
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
		public void CreateInitialChunk()
		{
			CreateChunk(this.chunkPrefab, Point.Zero);
		}

		public void CreateNextChunk(int chunkXIndex, int chunkYIndex)
		{
		}

		private void CreateChunk(Chunk prefab, Point chunkIndex)
		{
			var chunk = Instantiate(prefab);
			chunk.Initialize(this, chunkIndex);
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
