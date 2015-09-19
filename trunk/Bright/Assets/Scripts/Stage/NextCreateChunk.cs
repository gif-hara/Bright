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
		private GameDefine.DirectionType flag;

		public bool CanCreate(GameDefine.DirectionType direction)
		{
			return (this.flag & direction) > 0;
		}
	}
}
