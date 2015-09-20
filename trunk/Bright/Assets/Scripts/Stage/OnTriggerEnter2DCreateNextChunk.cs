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
		void OnTriggerEnter2D(Collider2D other)
		{
			var blankChunk = GetComponent<BlankChunk>();
			blankChunk.Hypostatization();
			Destroy(gameObject);
		}
	}
}
