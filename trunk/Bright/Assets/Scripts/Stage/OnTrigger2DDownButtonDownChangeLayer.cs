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
	public class OnTrigger2DDownButtonDownChangeLayer : MonoBehaviour
	{
		[SerializeField]
		private string enterLayerName;
		
		[SerializeField]
		private string exitLayerName;

		private Dictionary<GameObject, DownButtonDownEvent.EventFunction> functorDictionary = new Dictionary<GameObject, DownButtonDownEvent.EventFunction>();

		void OnTriggerEnter2D(Collider2D other)
		{
			var downButtonDownEvent = other.gameObject.GetComponent<DownButtonDownEvent>();
			if(downButtonDownEvent == null)
			{
				return;
			}

			DownButtonDownEvent.EventFunction functor = () =>
			{
				other.gameObject.layer = LayerMask.NameToLayer(this.enterLayerName);
			};

			if(!this.functorDictionary.ContainsKey(other.gameObject))
			{
				this.functorDictionary.Add(other.gameObject, functor);
				downButtonDownEvent.Accept(functor);
			}
		}
		void OnTriggerExit2D(Collider2D other)
		{
			var downButtonDownEvent = other.gameObject.GetComponent<DownButtonDownEvent>();
			if(downButtonDownEvent == null)
			{
				return;
			}

			if(this.functorDictionary.ContainsKey(other.gameObject))
			{
				downButtonDownEvent.Remove(this.functorDictionary[other.gameObject]);
				this.functorDictionary.Remove(other.gameObject);
			}
		}
	}
}
