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
        private Transform refGroundCheck;    // A position marking where to check if the player is grounded.

		[SerializeField]
		private Rigidbody2D refRigidBody2D;

		const float GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded

		public bool Grounded{ private set; get; }            // Whether or not the player is grounded.

        private bool m_FacingRight = true;  // For determining which way the player is currently facing.

        private void FixedUpdate()
        {
            Grounded = false;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(refGroundCheck.position, GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                    Grounded = true;
            }
        }


        public void Move(float move, bool jump)
        {
            //only control the player if grounded or airControl is turned on
            if (Grounded || m_AirControl)
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
            if (Grounded && jump)
            {
                // Add a vertical force to the player.
                Grounded = false;

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
