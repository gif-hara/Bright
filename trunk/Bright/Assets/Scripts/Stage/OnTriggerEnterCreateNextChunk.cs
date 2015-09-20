using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// トリガーにヒットしたら次のチャンクを生成するコンポーネント.
	/// </summary>
	[RequireComponent(typeof(BlankChunk))]
	public class OnTriggerEnterCreateNextChunk : MonoBehaviour
	{
		void OnTriggerEnter2D(Collider2D other)
		{
			var blankChunk = GetComponent<BlankChunk>();
			blankChunk.Hypostatization();
			Destroy(gameObject);
			Debug.Log("Create Index = " + blankChunk.Index + " other.name = " + other.name);
		}
	}
}
