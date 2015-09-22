using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 衝突時に隣接するチャンクを表示にするコンポーネント.
	/// </summary>
	public class OnTriggerEnter2DVisibleChunk : MonoBehaviour
	{
		private bool canExecute = true;

		void OnTriggerEnter2D(Collider2D other)
		{
			if(!this.canExecute)
			{
				return;
			}

			this.canExecute = false;
			var chunk = GetComponent<Chunk>();
			chunk.Visible(chunk);
		}

		void OnTriggerExit2D(Collider2D other)
		{
			if(this.canExecute)
			{
				return;
			}

			this.canExecute = true;
		}
	}
}
