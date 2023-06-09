using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Hex.TopDownGame
{
    public class TopDownCharacterController : MonoBehaviour
    {
        [SerializeField] private DialogData data;
        public float speed;
        public VariableJoystick joystick;
        private bool isInteracting = false;

        private Animator animator;

        public DialogData plData { get => data; }
        public bool IsInteracting { get => isInteracting; }

        private void Awake()
        {
            Unfreeze();
        }

        private void Start()
        {
            animator = GetComponent<Animator>();
            if (PlayerPrefs.HasKey("CharName"))
            {
                plData.characterName = PlayerPrefs.GetString("CharName", "Doe");
            }
            else
            {
                plData.characterName = "Doe";
            }
        }

        public void Freeze()
        {
            isInteracting = true;
        }

        public void Unfreeze()
        {
            isInteracting = false;
        }

        private void Update()
        {
            if (isInteracting)
            {
                GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                animator.SetBool("IsMoving", false);
                return;
            }

            // create movement based on joystick
            Vector2 dir = Vector2.up * joystick.Vertical + Vector2.right * joystick.Horizontal;
            if (dir.x == -1)
            {
                animator.SetInteger("Direction", 3);
            }
            else if (dir.x == 1)
            {
                animator.SetInteger("Direction", 2);
            }
            if (dir.y == 1)
            {
                animator.SetInteger("Direction", 1);
            }
            else if (dir.y == -1)
            {
                animator.SetInteger("Direction", 0);
            }
            
            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
