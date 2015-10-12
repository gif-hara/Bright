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
	public class RandomMovementPlatformerCharacter2D : MonoBehaviour, IPlatformerCharacter2DMove
	{
		[SerializeField]
		private PlatformerCharacter2D character;
		
		[SerializeField][Range(0.0f, 1.0f)]
		private float smooth;
		
		private float move = 0.0f;

		private float direction = 0.0f;

		void OnEnable()
		{
			this.direction = (Random.value >= 0.5f) ? -1.0f : 1.0f;
		}

		void Update()
		{
			if(this.smooth >= 1.0f)
			{
				this.move = this.direction;
			}
			else
			{
				this.move = Mathf.Clamp(this.move + this.direction * smooth * Time.deltaTime * 10.0f, -1.0f, 1.0f);
			}
		}
		
		public float Move()
		{
			return this.move;
		}
	}
}
