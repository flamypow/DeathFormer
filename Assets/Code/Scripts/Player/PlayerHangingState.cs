using System;
using UnityEngine;

namespace Code.Scripts.Player
{
    public class PlayerHangingState : PlayerBaseState
    {
        public PlayerHangingState(PlayerController player) : base(player)
        {

        }
        public override void Enter()
        {
            _player.Data.IsJumping = false;
            _player.PlayerAnim.PlayAnimation(PlayerAnimationConstants.HANGING);
            if (_player.Data.JumpBuffered)
                base.HandleJump();
            _player.EventData.HandlePlayerHanging(_player);

            _player.Data.GravityMultiplier = 0;
            _player.RB.velocity = Vector2.zero;

        }
        public override void Update()
        {
            base.Update();
        }

        public override void HandleJump()
        {
            _player.Data.GravityMultiplier = 1;

            _player.gameObject.transform.SetParent(null);
            base.HandleJump();
        }

        public override void FixedUpdate()
        {
            //base.FixedUpdate();
            if (_player.IsGrounded)
            {
                _player.gameObject.transform.SetParent(null);
                _player.ChangeState(PlayerStates.Idle);
                return;
            }
            _player.Data.GravityMultiplier = 0;
            _player.RB.velocity = Vector2.zero;
        }
    }
}