using System;
using UnityEngine;
using UnityEngine.Networking;

namespace Bright
{
    public class PlatformerCharacter2D : NetworkBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character

		[SerializeField]
		private StateManager refStateManager;

		[SerializeField]
		private GameObject refIdleState;

		[SerializeField]
		private GameObject refRunState;

		[SerializeField]
        private Transform refGroundCheck;    // A position marking where to check if the player is grounded.

		[SerializeField]
		private Rigidbody2D refRigidBody2D;

		const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;            // Whether or not the player is grounded.
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up


        private bool m_FacingRight = true;  // For determining which way the player is currently facing.

        private void FixedUpdate()
        {
            m_Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(refGroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    m_Grounded = true;
            }
        }


        public void Move(float move, bool jump)
        {
            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
				if(this.isLocalPlayer)
				{
                	refRigidBody2D.velocity = new Vector2(move*m_MaxSpeed, refRigidBody2D.velocity.y);
				}

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }

            // If the player should jump...
            if (m_Grounded && jump)
            {
                // Add a vertical force to the player.
                m_Grounded = false;

				if(this.isLocalPlayer)
				{
                	refRigidBody2D.AddForce(new Vector2(0f, m_JumpForce));
				}
            }
        }

        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}
