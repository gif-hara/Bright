using System;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

namespace Bright
{

    public class PlatformerCharacter2D : MonoBehaviour, IReceiveSetMovement
    {
        [SerializeField] private float m_MaxSpeed = 10f;                    // The fastest the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
		[SerializeField] private float movableDelay;

        private Transform m_GroundCheck;    // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
		public bool Grounded{ private set; get; }
        const float k_CeilingRadius = .01f; // Radius of the overlap circle to determine if the player can stand up
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;  // For determining which way the player is currently facing.
		private bool notifyLanding = false;
		private bool canMove = true;

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            Grounded = false;

            var colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
				{
                    Grounded = true;
					break;
				}
            }

			NotifyLanding();
        }

		public void OnSetMovement(bool canMove)
		{
			this.notifyLanding = canMove;
			this.canMove = canMove;

			if(!this.canMove)
			{
				StartCoroutine(this.MovableCoroutine());
			}
		}

        public void Move(float move, bool jump, bool lockDirection)
        {
            if ((Grounded || m_AirControl) && this.canMove)
            {
                m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

                if (move > 0 && !m_FacingRight && !lockDirection)
                {
                    Flip();
                }
                else if (move < 0 && m_FacingRight && !lockDirection)
                {
                    Flip();
                }
            }
            if (Grounded && jump)
            {
                Grounded = false;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
        }

        public void Flip()
        {
            m_FacingRight = !m_FacingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

		private void NotifyLanding()
		{
			if(this.Grounded == this.notifyLanding)
			{
				return;
			}

			this.notifyLanding = this.Grounded;
			if(this.notifyLanding)
			{
				ExecuteEvents.Execute<IReceiveLanding>(this.gameObject, null, (handler, eventData) => handler.OnLanding());
			}
		}

		private IEnumerator MovableCoroutine()
		{
			yield return new WaitForSeconds(this.movableDelay);

			this.canMove = true;
		}
    }
}
