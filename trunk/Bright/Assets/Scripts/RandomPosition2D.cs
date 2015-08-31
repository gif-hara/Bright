using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// ランダムで座標を設定するコンポーネント.
	/// </summary>
	public class RandomPosition2D : MonoBehaviour
	{
		[SerializeField]
		private Transform target;

		[SerializeField]
		private Vector2 min;

		[SerializeField]
		private Vector2 max;

		void Awake()
		{
			this.target.position = new Vector3(
				Random.Range(min.x, max.x),
				Random.Range(min.y, max.y),
				0.0f
				) + this.target.position;
		}

		void OnDrawGizmosSelected()
		{
			Gizmos.matrix = transform.localToWorldMatrix;
			Gizmos.DrawLine(new Vector3(min.x, min.y, 0.0f), new Vector3(min.x, max.y, 0.0f));
			Gizmos.DrawLine(new Vector3(min.x, max.y, 0.0f), new Vector3(max.x, max.y, 0.0f));
			Gizmos.DrawLine(new Vector3(max.x, max.y, 0.0f), new Vector3(max.x, min.y, 0.0f));
			Gizmos.DrawLine(new Vector3(max.x, min.y, 0.0f), new Vector3(min.x, min.y, 0.0f));
		}
	}
}
