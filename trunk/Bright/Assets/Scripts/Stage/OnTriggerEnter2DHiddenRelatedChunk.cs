using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 衝突時に隣接するチャンクを非表示にするコンポーネント.
	/// </summary>
	public class OnTriggerEnter2DHiddenRelatedChunk : MonoBehaviour
	{
		private bool canExecute = true;

		void OnTriggerEnter2D(Collider2D other)
		{
			if(!this.canExecute)
			{
				return;
			}

			this.canExecute = false;
			GetComponent<Chunk>().HiddenRelatedChunk();
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
