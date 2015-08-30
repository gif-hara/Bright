using System;
using UnityEngine;
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

		private SyncPlayerData syncPlayerData;

		private Rigidbody2D rigidBody2D;

		void Awake()
		{
			this.character = GetComponent<PlatformerCharacter2D>();
			this.stateSwitcher = GetComponent<PlayerStateSwitcher>();
			this.syncPlayerData = GetComponent<SyncPlayerData>();
			this.rigidBody2D = GetComponent<Rigidbody2D>();
		}

        void Update()
        {
        	if (!this.jump)
        	{
        	    // Read the jump input in Update so button presses aren't missed.
				jump = Bright.Input.JumpButtonDown;
        	}
			if(!this.attack && Bright.Input.AttackButton)
			{
				this.attack = true;
			}
			if(!this.lockDirection)
			{
				this.lockDirection = Bright.Input.AttackButton;
			}

			this.velocity = HorizontalMoveVelocity;
			ChangeState(GetStateType(this.velocity));
        }

        void FixedUpdate()
        {
			this.Move(this.FinalVelocity, this.jump, this.lockDirection);
            jump = false;
        }

		public void OnEndAttack()
		{
			this.attack = false;
			this.lockDirection = Bright.Input.AttackButton;
			ChangeState(GetStateType(this.velocity));
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
			this.syncPlayerData.CmdProvideStateTypeToServer((int)newStateType);
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

				result *= 10;

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

		private GameDefine.StateType GetStateType(float moveVector)
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
					if(moveVector > 0.0f || moveVector < 0.0f)
					{
						result = GameDefine.StateType.Run;
					}
				}
				else
				{
					result = this.rigidBody2D.velocity.y > 0.0f ? GameDefine.StateType.Jump : GameDefine.StateType.Fall;
				}
			}


			return result;
		}
    }
}
