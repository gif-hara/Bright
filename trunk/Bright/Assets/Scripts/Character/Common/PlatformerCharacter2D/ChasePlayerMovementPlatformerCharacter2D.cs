using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// プレイヤーを追従するコンポーネント.
	/// </summary>
	public class ChasePlayerMovementPlatformerCharacter2D : MonoBehaviour, IPlatformerCharacter2DMove
	{
		[SerializeField]
		private PlatformerCharacter2D character;

		[SerializeField][Range(0.0f, 1.0f)]
		private float smooth;

		private float move = 0.0f;

		void Update()
		{
			var difference = Mathf.Sign(ObjectFinder.Player.transform.position.x - this.transform.position.x);

			if(this.smooth >= 1.0f)
			{
				this.move = difference;
			}
			else
			{
				this.move = Mathf.Clamp(this.move + difference * smooth * Time.deltaTime * 10.0f, -1.0f, 1.0f);
			}
		}

		public float Move()
		{
			return this.move;
		}
	}
}
