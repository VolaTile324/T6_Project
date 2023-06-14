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
        [SerializeField] private Sprite _playerSprite;
        public float speed;
        public VariableJoystick joystick;
        private bool isInteracting = false;

        private Animator animator;
        private Vector2 lastDir;

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

            plData.characterImage = _playerSprite;
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
            dir.Normalize();
            GetComponent<Rigidbody2D>().velocity = dir * speed;

            // set animation
            if (GetComponent<Rigidbody2D>().velocity == Vector2.zero)
            {
                if (lastDir.x == -1)
                {
                    animator.Play("PLIdleSide");
                }
                else if (lastDir.x == 1)
                {
                    animator.Play("PLIdleSideR");
                }
                else if (lastDir.y == 1)
                {
                    animator.Play("PLIdleBack");
                }
                else if (lastDir.y == -1)
                {
                    animator.Play("PLIdleFront");
                }
            }
            if (GetComponent<Rigidbody2D>().velocity != Vector2.zero)
            {
                if (dir.x == -1)
                {
                    animator.Play("PLMoveSide");
                    lastDir = dir;
                }
                else if (dir.x == 1)
                {
                    animator.Play("PLMoveSideR");
                    lastDir = dir;
                }
                else if (dir.y == 1)
                {
                    animator.Play("PLMoveBack");
                    lastDir = dir;
                }
                else if (dir.y == -1)
                {
                    animator.Play("PLMoveFront");
                    lastDir = dir;
                }
            }
        }
    }
}
