using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

namespace Bright
{
    public class Platformer2DUserControl : NetworkBehaviour
    {
        private bool jump;

		private PlatformerCharacter2D character;
		
		private PlayerStateSwitcher stateSwitcher;

		private SyncPlayerData syncPlayerData;

		private Rigidbody2D rigidBody2D;

		[ClientCallback]
		void Awake()
		{
			this.character = GetComponent<PlatformerCharacter2D>();
			this.stateSwitcher = GetComponent<PlayerStateSwitcher>();
			this.syncPlayerData = GetComponent<SyncPlayerData>();
			this.rigidBody2D = GetComponent<Rigidbody2D>();
		}

		[ClientCallback]
        void Update()
        {
        	if (!jump)
        	{
        	    // Read the jump input in Update so button presses aren't missed.
        	    jump = CrossPlatformInputManager.GetButtonDown("Jump");
        	}
        }

		[ClientCallback]
        void FixedUpdate()
        {
			float h = CrossPlatformInputManager.GetAxis("Horizontal") * 10;
			this.Move(h);
			var stateType = GetStateType(h);
			this.stateSwitcher.Change(stateType);
			this.syncPlayerData.CmdProvideStateTypeToServer((int)stateType);
            jump = false;
        }

		private void Move(float move)
		{
			this.character.Move(move, jump);
		}

		private GameDefine.StateType GetStateType(float moveVector)
		{
			var result = GameDefine.StateType.Idle;

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

			return result;
		}
    }
}
