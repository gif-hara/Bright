using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Bright
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
		[SerializeField]
		private float moveSpeed = 1.0f;

        private PlatformerCharacter2D m_Character;
        private bool m_Jump;


        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
			float h = CrossPlatformInputManager.GetAxis("Horizontal");
			//h = h > 0.0f ? 1.0f : h < 0.0f ? -1.0f : 0.0f;
			h *= this.moveSpeed;
            // Pass all parameters to the character control script.
            m_Character.Move(h, m_Jump);
            m_Jump = false;
        }
    }
}
