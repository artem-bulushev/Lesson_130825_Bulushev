using Code.Gameplay.Infrastructure.Services;
using UnityEngine;

namespace Code.Gameplay.Features.Character.ComponentDriven
{
   public class CharacterMovement : MonoBehaviour
   {
      [SerializeField] private StandaloneInputService _inputService;
      [SerializeField] private CharacterController _characterController;
      [SerializeField] private float _speed = 10f;
      private Vector3 _moveDirection;
      public AudioSource _moveSound;

        private void Update()
        {
            Move();
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                if (_moveSound.isPlaying) return;
                {
                    _moveSound.Play();
                }
                
            }
            else
            {
                _moveSound.Stop();
            }
        }

      private void Move()
      {
         float xInput = _inputService.GetHorizontalMoveAxis();
         float zInput = _inputService.GetVerticalMoveAxis();

         _moveDirection = transform.right * xInput + transform.forward * zInput;

         if (_inputService.HasMoveInput())
         {
            _characterController.Move(_moveDirection * _speed * Time.deltaTime);
         }
      }
   }
}