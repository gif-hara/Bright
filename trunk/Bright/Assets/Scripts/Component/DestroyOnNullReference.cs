using UnityEngine;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// targetがDestroyされたタイミングで自分自身もDestroyするコンポーネント.
	/// </summary>
	public class DestroyOnNullReference : MonoBehaviour
	{
		[SerializeField]
		private GameObject target;

#if UNITY_EDITOR
		private bool isQuitApplication = false;
#endif

		void Start()
		{
			var destroyEvent = target.GetComponent<OnDestroyEvent>();
			if(destroyEvent == null)
			{
				destroyEvent = target.AddComponent<OnDestroyEvent>();
			}

#if UNITY_EDITOR
			destroyEvent.DestroyEvent.AddListener(() =>
			{
				if(!this.isQuitApplication)
				{
					Destroy(gameObject);
				}
			});
#else
			destroyEvent.DestroyEvent.AddListener(() => Destroy(gameObject));
#endif
		}
#if UNITY_EDITOR
		void OnApplicationQuit()
		{
			this.isQuitApplication = true;
		}
#endif

		public void SetTarget(GameObject target)
		{
			this.target = target;
		}
	}
}