using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;
        public bool isWindowOpen = false;

        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void ToggleWindowOpen()
        {
            if (isWindowOpen == false)
            {
                isWindowOpen = true;
            }
            else
            {
                isWindowOpen = false;
            }
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (isWindowOpen)
            {
                // stop player from any form of movement whenever window is open
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                return;
            }
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
