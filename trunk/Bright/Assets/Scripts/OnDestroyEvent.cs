using UnityEngine;
using UnityEngine.Events;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// Destroy時に登録されているイベントを実行するコンポーネント.
	/// </summary>
	public class OnDestroyEvent : MonoBehaviour
	{
		public UnityEvent DestroyEvent{ get{ return this.destroyEvent; } }
		[SerializeField]
		private UnityEvent destroyEvent = new UnityEvent();

		void OnDestroy()
		{
			destroyEvent.Invoke();
		}
	}
}
