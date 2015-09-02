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
			StageManager.Instance.CreateNextChunk();
			Destroy(gameObject);
			NetworkServer.Destroy(gameObject);
		}
	}
}
