using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// チャンク初期化時にイベントをフック出来るインターフェイス.
	/// </summary>
	public interface IReceiveOnInitializeChunk : IEventSystemHandler
	{
		void OnInitializeChunk(StageManager stageManager, Point chunkIndex);
	}
}
