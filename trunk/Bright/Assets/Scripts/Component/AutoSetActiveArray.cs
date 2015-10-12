using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// 自動でSetActiveを呼び出すコンポーネント.
	/// </summary>
	public class AutoSetActiveArray : MonoBehaviour
	{
		[System.Serializable]
		public class Element
		{
			[SerializeField]
			private GameObject target;
			
			[SerializeField]
			private bool isActive;

			public void Proccess()
			{
				this.target.SetActive(this.isActive);
			}
		}

		[SerializeField]
		private List<Element> elements;

		[SerializeField]
		private DelayTimer delay;

		[SerializeField]
		private bool loop;

		void Update()
		{
			this.delay.Update();

			if(!this.delay.Complete)
			{
				return;
			}

			this.elements.ForEach(e => e.Proccess());

			if(this.loop)
			{
				this.delay.Reset();
			}
			else
			{
				this.enabled = false;
			}
		}
	}
}
