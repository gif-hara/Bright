using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	public class OnTrigger2DChangeLayer : MonoBehaviour
	{
		[SerializeField]
		private string enterLayerName;

		[SerializeField]
		private string exitLayerName;

		private Dictionary<GameObject, int> collisionObjects = new Dictionary<GameObject, int>();

		void OnTriggerEnter2D(Collider2D other)
		{
			if(this.collisionObjects.ContainsKey(other.gameObject))
			{
				this.collisionObjects[other.gameObject]++;
				return;
			}

			other.gameObject.layer = LayerMask.NameToLayer(this.enterLayerName);
			this.collisionObjects.Add(other.gameObject, 1);
		}
		void OnTriggerExit2D(Collider2D other)
		{
			this.collisionObjects[other.gameObject]--;

			if(this.collisionObjects[other.gameObject] <= 0)
			{
				other.gameObject.layer = LayerMask.NameToLayer(this.exitLayerName);
				this.collisionObjects.Remove(other.gameObject);
			}
		}
	}
}
