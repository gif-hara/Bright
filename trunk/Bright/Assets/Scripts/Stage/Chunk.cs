using UnityEngine;
using UnityEngine.Assertions;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// チャンクコンポーネント.
	/// </summary>
	[RequireComponent(typeof(ChunkCreator))]
	public class Chunk : ChunkBase
	{
		public ChunkDoorway Doorway{ get{ return this.doorway; } }
		[SerializeField]
		private ChunkDoorway doorway;

		public void Initialize(StageManager stageManager, Point index, BlankChunk blankChunk)
		{
			if(blankChunk != null)
			{
				this.node = blankChunk.Node;
			}

			base.Initialize(stageManager, index);
			var creator = GetComponent<ChunkCreator>();
			var max = StageManager.ChunkSize - 1;
			
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

			stageManager.CreateBlankChunk(this, InverseDirection(direction), chunkIndex);
		}

		private GameDefine.DirectionType InverseDirection(GameDefine.DirectionType direction)
		{
			switch(direction)
			{
			case GameDefine.DirectionType.Left:
				return GameDefine.DirectionType.Right;
			case GameDefine.DirectionType.Right:
				return GameDefine.DirectionType.Left;
			case GameDefine.DirectionType.Top:
				return GameDefine.DirectionType.Bottom;
			case GameDefine.DirectionType.Bottom:
				return GameDefine.DirectionType.Top;
			default:
				Assert.IsTrue(false, "不正な値です. direction = " + direction);
				return GameDefine.DirectionType.Left;
			}
		}
	}
}
