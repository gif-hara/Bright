using System;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.CrossPlatformInput;

namespace Bright
{
    public class Platformer2DUserControl : NetworkBehaviour
    {
		[SerializeField]
		private PlatformerCharacter2D refCharacter;

		[SerializeField]
		private float moveSpeed = 1.0f;

		[SyncVar]
		private float syncMove;

        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Update()
        {
			if(this.isLocalPlayer)
			{
            	if (!m_Jump)
            	{
            	    // Read the jump input in Update so button presses aren't missed.
            	    m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            	}
			}
        }

        private void FixedUpdate()
        {
			if(this.isLocalPlayer)
			{
				float h = CrossPlatformInputManager.GetAxis("Horizontal");
				h *= this.moveSpeed;
				this.Move(h);
				this.TransmitMove(h);
			}
			else
			{
				this.Move(syncMove);
			}
            m_Jump = false;
        }

		private void Move(float move)
		{
			this.refCharacter.Move(move, m_Jump);
		}

		[Command]
		void CmdProvideMoveToServer(float syncMove)
		{
			this.syncMove = syncMove;
		}

		[Client]
		void TransmitMove(float move)
		{
			CmdProvideMoveToServer(move);
		}

    }
}
