using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Bright
{
	/// <summary>
	/// .
	/// </summary>
	[RequireComponent(typeof(StateManager))]
	public class StartState : MonoBehaviour
	{
		[SerializeField]
		private GameObject refStateObject;

		// Use this for initialization	
		void Start ()
		{
			GetComponent<StateManager>().Change(refStateObject);
		}
	}
}
