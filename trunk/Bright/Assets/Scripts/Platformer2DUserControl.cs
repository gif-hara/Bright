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

		[ClientCallback]
		void Awake()
		{
			this.character = GetComponent<PlatformerCharacter2D>();
			this.stateSwitcher = GetComponent<PlayerStateSwitcher>();
			this.syncPlayerData = GetComponent<SyncPlayerData>();
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
			if(this.isLocalPlayer)
			{
				float h = CrossPlatformInputManager.GetAxis("Horizontal") * 10;
				this.Move(h);
				var stateType = GameDefine.StateType.Idle;
				if(h > 0.0f || h < 0.0f)
				{
					stateType = GameDefine.StateType.Run;
				}

				this.stateSwitcher.Change(stateType);
				this.syncPlayerData.CmdProvideStateTypeToServer((int)stateType);
			}
            jump = false;
        }

		private void Move(float move)
		{
			this.character.Move(move, jump);
		}

    }
}
