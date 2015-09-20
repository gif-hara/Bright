using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// チャンクコンポーネント.
	/// </summary>
	[RequireComponent(typeof(ChunkCreator), typeof(OnTriggerEnter2DHiddenRelatedChunk))]
	public class Chunk : ChunkBase
	{
		public ChunkDoorway Doorway{ get{ return this.doorway; } }
		[SerializeField]
		private ChunkDoorway doorway;

#if UNITY_EDITOR
		[ContextMenu("Setup")]
		void Setup()
		{
			this.gameObject.layer = LayerMask.NameToLayer("Chunk");

			var rigidBody2D = Attach<Rigidbody2D>();
			rigidBody2D.isKinematic = true;

			var collider = Attach<BoxCollider2D>();
			collider.size = Vector2.one * StageManager.ChunkSize;
			collider.offset = Vector2.one * (StageManager.ChunkSize / 2);
			collider.isTrigger = true;

			Attach<ChunkCreator>();
			Attach<OnTriggerEnter2DVisibleRelatedChunk>();
			Attach<OnTriggerEnter2DHiddenRelatedChunk>();
		}

		T Attach<T>() where T : Component
		{
			var t = GetComponent<T>();
			if(t == null)
			{
				t = gameObject.AddComponent<T>();
			}

			return t;
		}

#endif

		public void Initialize(StageManager stageManager, Point index, BlankChunk blankChunk)
		{
			if(blankChunk != null)
			{
				this.node = blankChunk.Node;
			}

			this.stageManager = stageManager;
			this.index = index;

			var creator = GetComponent<ChunkCreator>();
			var max = StageManager.ChunkSize - 1;

			this.transform.position = stageManager.GetPosition(index, Point.Zero);

			this.CreateWall(creator, stageManager, GameDefine.DirectionType.Left, index, Point.Zero);
			this.CreateWall(creator, stageManager, GameDefine.DirectionType.Right, index, Point.Right * max);
			this.CreateGround(creator, stageManager, GameDefine.DirectionType.Top, index, Point.Top * max);
			this.CreateGround(creator, stageManager, GameDefine.DirectionType.Bottom, index, Point.Zero);
			this.CreateBlankChunk(stageManager, GameDefine.DirectionType.Left, index + Point.Left);
			this.CreateBlankChunk(stageManager, GameDefine.DirectionType.Right, index + Point.Right);
			this.CreateBlankChunk(stageManager, GameDefine.DirectionType.Top, index + Point.Top);
			this.CreateBlankChunk(stageManager, GameDefine.DirectionType.Bottom, index + Point.Bottom);
			
			var components = GetComponentsInChildren(typeof(IReceiveOnInitializeChunk));
			foreach(var component in components)
			{
				(component as IReceiveOnInitializeChunk).OnInitializeChunk(stageManager, index);
			}
		}

		public void Visible(Chunk ignoreChunk)
		{
			this.node.Visible(ignoreChunk);
		}

		public void Hidden(Chunk ignoreChunk)
		{
			this.node.Hidden(ignoreChunk);
		}

		public void VisibleRelatedChunk()
		{
			this.node.VisibleRelatedChunk(this);
		}

		public void HiddenRelatedChunk()
		{
			this.node.HiddenRelatedChunk(this);
		}

		private void CreateGround(ChunkCreator creator, StageManager stageManager, GameDefine.DirectionType direction, Point chunkIndex, Point position)
		{
			if(!this.doorway.CanCreate(direction))
			{
				return;
			}

			creator.CreateGround(stageManager, chunkIndex, position);
		}

		private void CreateWall(ChunkCreator creator, StageManager stageManager, GameDefine.DirectionType direction, Point chunkIndex, Point position)
		{
			if(!this.doorway.CanCreate(direction))
			{
				return;
			}

			creator.CreateWall(stageManager, chunkIndex, position);
		}

		private void CreateBlankChunk(StageManager stageManager, GameDefine.DirectionType direction, Point chunkIndex)
		{
			if(this.doorway.CanCreate(direction))
			{
				return;
			}

			if(this.node.Contains(direction))
			{
				return;
			}

			stageManager.CreateBlankChunk(this, GameDefine.InverseDirection(direction), chunkIndex);
		}
	}
}
