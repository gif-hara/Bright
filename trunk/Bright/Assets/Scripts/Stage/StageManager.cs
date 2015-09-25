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

		[SerializeField]
		private BlankChunk blankChunkPrefab;

		[SerializeField]
		private ChunkHolder chunkHolder;

		public const int ChunkSize = 30;

		void Start ()
		{
			this.CreateInitialChunk();
		}

        public GameObject CreateStageObject(Transform parent, GameObject prefab, Point chunkIndex, Point position)
        {
			Assert.IsTrue(
				(position.X >= 0 && position.X < ChunkSize) && (position.Y >= 0 && position.Y < ChunkSize),
				string.Format("チャンクサイズを超えています. xIndex = {0} yIndex = {1}", position.X, position.Y)
				);
            var obj = Instantiate(prefab);
			obj.transform.parent = parent;
			obj.transform.position = GetPosition(chunkIndex, position);

			return obj;
        }

		public BlankChunk CreateBlankChunk(Chunk linkedChunk, GameDefine.DirectionType linkedDirection, Point chunkIndex)
		{
			var blankChunk = Instantiate(this.blankChunkPrefab);
			blankChunk.Initialize(this, chunkIndex);
			blankChunk.Connect(linkedDirection, linkedChunk);
			blankChunk.transform.position = GetPosition(chunkIndex, Point.Zero);

			return blankChunk;
		}

		/// <summary>
		/// 初期チャンクを生成する.
		/// </summary>
		public void CreateInitialChunk()
		{
			CreateChunk(this.chunkHolder.InitialChunk, Point.Zero);
		}

		public Chunk CreateChunk(BlankChunk blankChunk, Point chunkIndex)
		{
			var chunk = Instantiate(this.chunkPrefab);
			chunk.Initialize(this, chunkIndex, blankChunk);

			return chunk;
		}

		private void CreateChunk(Chunk prefab, Point chunkIndex)
		{
			var chunk = Instantiate(prefab);
			chunk.Initialize(this, chunkIndex, null);
		}

		public Vector2 GetPosition(Point chunkIndex, Point position)
		{
			return new Vector2(position.X + (chunkIndex.X * ChunkSize), position.Y + (chunkIndex.Y * ChunkSize));
		}

		public static Vector2 GetChunkIndexFromPosition(Vector3 position)
		{
			return new Vector2(position.x / ChunkSize, position.y / ChunkSize);
		}
	}
}
