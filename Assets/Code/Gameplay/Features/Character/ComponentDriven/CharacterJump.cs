using Code.Gameplay.Infrastructure.Services;
using UnityEngine;
using UnityEngine.Audio;

namespace Code.Gameplay.Features.Character.ComponentDriven
{
   public class CharacterJump : MonoBehaviour
   {
      [SerializeField] private CharacterController _characterController;
      [SerializeField] private float _gravity = -10f;
      [SerializeField] private float _jumpHeight = 5;
      [SerializeField] private Transform _groundCheck;
      [SerializeField] private LayerMask _groundLayer;
      [SerializeField] private StandaloneInputService _inputService;
        [SerializeField] private AudioClip _clip;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioMixerGroup _audioMixerGroup;

        private Vector3 _velocity;
      private bool _isGrounded;


      private void Update()
      {
         CheckIsGrounded();
         ProcessJump();
      }

      private void ProcessJump()
      {
         if (_inputService.IsJumpBtnUp())
            if (_isGrounded)
                {
                    Jump();
                    _audioSource.PlayOneShot(_clip);
                    _audioMixerGroup.audioMixer.SetFloat("VolumeBounce", Random.Range(-20, 0));
                }
               
            else
               _velocity.y += _gravity * Time.deltaTime;
         else
            _velocity.y += _gravity * Time.deltaTime;
         
         _characterController.Move(_velocity * Time.deltaTime);
      }

      private void CheckIsGrounded() => 
         _isGrounded = Physics.CheckSphere(_groundCheck.position, 0.3f, _groundLayer);

      private void Jump()
      {
         _velocity.y = Mathf.Sqrt(_jumpHeight * 2 * -_gravity);
      }
   }
}