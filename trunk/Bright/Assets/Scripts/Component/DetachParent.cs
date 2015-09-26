using UnityEngine;
using System.Collections;

namespace Bright
{
	public class DetachParent : MonoBehaviour
	{
		public enum Timing : int
		{
			Awake,
			Start,
		}

		[SerializeField]
		private Timing timing;

		void Awake()
		{
			if(this.timing == Timing.Awake)
			{
				this.transform.parent = null;
			}
		}

		void Start ()
		{
			if(this.timing == Timing.Start)
			{
				this.transform.parent = null;
			}
		}
		
	}
}