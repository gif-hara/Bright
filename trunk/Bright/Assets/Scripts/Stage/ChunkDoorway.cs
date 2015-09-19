using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// チャンクの入り口データ.
	/// </summary>
	[System.Serializable]
	public class ChunkDoorway
	{
		[SerializeField][EnumFlags]
		private GameDefine.ChunkDoorwayType flag;

		public bool CanCreate(GameDefine.ChunkDoorwayType type)
		{
			return (flag & type) > 0;
		}
	}
}
