﻿using UnityEngine;

namespace Code.Scripts.Player
{
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator _animator;

        void Awake()
        {
            _animator = GetComponent<Animator>(); 
            _animator.Play(PlayerAnimationConstants.IDLE);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {

            if (other.CompareTag("Obstacle"))
            {
                _animator.Play(PlayerAnimationConstants.DIE);
                
            }
        }
        
        public void PlayAnimation(string animationName)
        {
            _animator?.Play(animationName);
        }
    }

    public static class PlayerAnimationConstants
    {
        public const string IDLE = "Idle";
        public const string WALK = "Walk";
        public const string RUN = "Run";
        public const string AIR = "JumpMid";
        public const string JUMP = "Jump";
        public const string DIE = "DeathSampleAnim";
        public const string HANGING = "Hanging";
    }
}