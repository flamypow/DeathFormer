using Code.Scripts.Managers;
using UnityEngine;

namespace Code.Scripts.Player
{
    public class PlayerRunState: PlayerBaseState
    {
        
        public PlayerRunState(PlayerController player) : base(player){}
        public override void Enter()
        {
            AudioManager.Instance.PlayAudioContinuous(AudioType.PLAYERFOOTSTEP);
            _player.Data.IsJumping = false;
            _player.PlayerAnim.PlayAnimation(PlayerAnimationConstants.RUN);
            if (_player.Data.JumpBuffered)
            {
                AudioManager.Instance.StopPlaying();
                base.HandleJump();
            }
            _player.EventData.HandlePlayerRuns(_player);
                
        }
        public override void Update()
        {
            base.Update();
        }
        public override void HandleJump()
        {
            AudioManager.Instance.StopPlaying();
            base.HandleJump();

        }
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            
            if (!_player.IsGrounded )
            {
                AudioManager.Instance.StopPlaying();
                _player.ChangeState(PlayerStates.InAir);
                return;
            }
            if (_player.RB.velocity.magnitude <= 0.05f)
            {
                AudioManager.Instance.StopPlaying();
                _player.ChangeState(PlayerStates.Idle);
            }
        }
    }
}