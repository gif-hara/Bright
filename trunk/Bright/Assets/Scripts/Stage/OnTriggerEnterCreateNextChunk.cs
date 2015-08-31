using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// トリガーにヒットしたら次のチャンクを生成するコンポーネント.
	/// </summary>
	public class OnTriggerEnterCreateNextChunk : MonoBehaviour
	{
		void OnTriggerEnter2D(Collider2D other)
		{
			var index = StageManager.GetIndexFromPosition(this.transform.position);
			StageManager.Instance.CreateRandomChunk((int)index.x, (int)index.y);
			Destroy(gameObject);
			NetworkServer.Destroy(gameObject);
		}
	}
}
