using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

namespace Bright
{
    public class Platformer2DUserControl : MonoBehaviour, IReceiveEndAttack
    {
        private bool jump;

		private bool attack;

		private float velocity;

		private bool lockDirection;

		private GameDefine.StateType currentStateType;

		private PlatformerCharacter2D character;
		
		private PlayerStateSwitcher stateSwitcher;

		private Rigidbody2D rigidBody2D;

		private ExecuteOnStartAttack executeOnStartAttack;

		void Awake()
		{
			this.character = GetComponent<PlatformerCharacter2D>();
			this.stateSwitcher = GetComponent<PlayerStateSwitcher>();
			this.rigidBody2D = GetComponent<Rigidbody2D>();
			this.executeOnStartAttack = GetComponent<ExecuteOnStartAttack>();
		}

        void Update()
        {
        	if (!this.jump)
        	{
				jump = Bright.Input.JumpButtonDown;
        	}
			if(!this.attack && Bright.Input.AttackButton)
			{
				this.attack = true;
				this.executeOnStartAttack.Execute();
			}

			this.lockDirection = Bright.Input.AttackButton;

			this.velocity = HorizontalMoveVelocity;
			ChangeState(CurrentStateType);
        }

        void FixedUpdate()
        {
			this.Move(this.FinalVelocity, this.jump, this.lockDirection || this.attack);
            jump = false;
        }

		public void OnEndAttack()
		{
			this.attack = false;
			ChangeState(CurrentStateType);
		}

		private void Move(float move, bool jump, bool lockDirection)
		{
			this.character.Move(move, jump, lockDirection);
		}

		private void ChangeState(GameDefine.StateType newStateType)
		{
			if(this.currentStateType == newStateType)
			{
				return;
			}

			this.stateSwitcher.Change(newStateType);
			this.currentStateType = newStateType;
		}

		private float HorizontalMoveVelocity
		{
			get
			{
				float result = 0.0f;

				if(Bright.Input.LeftButton)
				{
					result -= 1.0f;
				}
				if(Bright.Input.RightButton)
				{
					result += 1.0f;
				}

				return result;
			}
		}

		private float FinalVelocity
		{
			get
			{
				var result = this.velocity;
				if(this.lockDirection)
				{
					result *= 0.5f;
				}

				return result;
			}
		}

		private bool IsMove
		{
			get
			{
				return this.velocity > 0.0f || this.velocity < 0.0f;
			}
		}

		private bool IsFall
		{
			get
			{
				return this.rigidBody2D.velocity.y <= 0.0f;
			}
		}

		private GameDefine.StateType CurrentStateType
		{
			get
			{
				var result = GameDefine.StateType.Idle;

				if(this.attack)
				{
					result = GameDefine.StateType.Attack;
				}
				else
				{
					if(this.character.Grounded)
					{
						if(this.IsMove)
						{
							result = GameDefine.StateType.Run;
						}
					}
					else
					{
						result = this.IsFall ? GameDefine.StateType.Fall : GameDefine.StateType.Jump;
					}
				}

				return result;
			}
		}
	}
}
