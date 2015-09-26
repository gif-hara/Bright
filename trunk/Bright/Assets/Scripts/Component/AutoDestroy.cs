using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 自動的に死亡するコンポーネント.
	/// </summary>
	public class AutoDestroy : MonoBehaviour
	{
		[SerializeField]
		private GameObject target;

		[SerializeField]
		private float delay;

		// Use this for initialization
		IEnumerator Start ()
		{
			if(this.target == null)
			{
				this.target = this.gameObject;
			}

			yield return new WaitForSeconds(this.delay);

			Destroy(this.target);
		}
	}
}
