using UnityEngine;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// 接触した他のオブジェクトの移動量を同期するコンポーネント.
	/// </summary>
	public class SyncMovementCollide : MonoBehaviour
	{
		private List<Transform> collidedObjects = new List<Transform>();

		private Transform myTransform;

		private Vector3 oldPosition;

		void Start()
		{
			this.myTransform = this.transform;
			oldPosition = this.myTransform.position;
		}

		// Update is called once per frame
		void LateUpdate ()
		{
			if(this.collidedObjects.Count <= 0)
			{
				this.oldPosition = this.myTransform.position;
				return;
			}

			this.collidedObjects.RemoveAll(t => t == null);
			var diffPosition = this.myTransform.position - this.oldPosition;
			this.collidedObjects.ForEach(t => t.position += diffPosition);
			this.oldPosition = this.myTransform.position;
		}

		void OnCollisionEnter2D(Collision2D other)
		{
			if(this.collidedObjects.Find(t => t == other.transform) != null)
			{
				return;
			}

			this.collidedObjects.Add(other.transform);
		}

		void OnCollisionExit2D(Collision2D other)
		{
			this.collidedObjects.Remove(other.transform);
		}
	}
}
