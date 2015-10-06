using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// CreatePrefabExtensionイベント時にModifiedHitPointイベントをブロードキャストするコンポーネント.
	/// </summary>
	public class CreatePrefabExtensionBroadcastModifiedHitPoint : MonoBehaviour, IReceiveCreatePrefabExtension
	{
		[SerializeField]
		private ModifiedHitPointPropertyHolder holder;

		public void OnCreatePrefabExtension(GameObject instance)
		{
			ExecuteEventsExtensions.Broadcast<IReceiveModifiedHitPoint>(instance, null, (handler, eventData) => handler.OnModifiedHitPoint(holder.Max, holder.Value, holder.Damage));
		}
	}
}
