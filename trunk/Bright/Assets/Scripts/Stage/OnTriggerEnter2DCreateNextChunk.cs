using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// トリガーにヒットしたら次のチャンクを生成するコンポーネント.
	/// </summary>
	[RequireComponent(typeof(BlankChunk))]
	public class OnTriggerEnter2DCreateNextChunk : MonoBehaviour
	{
		private bool isCreated = false;

		void OnTriggerEnter2D(Collider2D other)
		{
			if(this.isCreated)
			{
				return;
			}

			var chunk = GetComponent<Chunk>();
			chunk.Hypostatization();
			chunk.DestroyBlankChunk();
			this.isCreated = true;
		}
	}
}
