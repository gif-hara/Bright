using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

namespace Bright
{
	/// <summary>
	/// PlatformerCharacter2Dの更新を行うコンポーネント.
	/// </summary>
	public class PlatformerCharacter2DUpdater : MonoBehaviour, IReceiveSetMovement, IReceiveLanding
	{
		[SerializeField]
		private PlatformerCharacter2D character;

		[SerializeField]
		private GameObject propertyHolder;

		private IPlatformerCharacter2DMove move = null;

		private IPlatformerCharacter2DJump jump = null;

		private IPlatformerCharacter2DLockDirection lockDirection = null;

		private bool canMove = true;

		private float cachedMove = 0.0f;

		private bool cachedJump = false;

		private bool cachedLockDirection = false;

		void Start()
		{
			this.move = this.propertyHolder.GetComponent(typeof(IPlatformerCharacter2DMove)) as IPlatformerCharacter2DMove;
			this.jump = this.propertyHolder.GetComponent(typeof(IPlatformerCharacter2DJump)) as IPlatformerCharacter2DJump;
			this.lockDirection = this.propertyHolder.GetComponent(typeof(IPlatformerCharacter2DLockDirection)) as IPlatformerCharacter2DLockDirection;
		}

		void Update()
		{
			this.cachedMove = this.Move;
			this.cachedJump = this.Jump;
			this.cachedLockDirection = this.LockDirection;
		}

		void FixedUpdate()
		{
			if(!this.canMove)
			{
				return;
			}

			this.character.Move(this.cachedMove, this.cachedJump, this.cachedLockDirection);
		}

		public void OnSetMovement(bool canMove)
		{
			this.canMove = canMove;
		}

		public void OnLanding()
		{
			this.canMove = true;
		}

		private float Move
		{
			get
			{
				return this.move == null ? 0.0f : this.move.Move();
			}
		}

		private bool Jump
		{
			get
			{
				return this.jump == null ? false : this.jump.Jump();
			}
		}

		private bool LockDirection
		{
			get
			{
				return this.lockDirection == null ? false : this.lockDirection.LockDirection();
			}
		}
	}
}
