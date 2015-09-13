using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// チャンクの入り口データ.
	/// </summary>
	[CreateAssetMenu]
	public class ChunkDoorway : ScriptableObject
	{
		[SerializeField][EnumFlags]
		private GameDefine.ChunkDoorwayType flag;

		public bool CanCreate(GameDefine.ChunkDoorwayType type)
		{
			return (flag & type) > 0;
		}
	}
}
