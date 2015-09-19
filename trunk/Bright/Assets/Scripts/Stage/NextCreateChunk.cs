using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	[System.Serializable]
	public class NextCreateChunk
	{
		[SerializeField][EnumFlags]
		private GameDefine.NextChunkType nextChunk;

		public bool CanCreate(GameDefine.NextChunkType nextChunk)
		{
			return (this.nextChunk & nextChunk) > 0;
		}
	}
}
