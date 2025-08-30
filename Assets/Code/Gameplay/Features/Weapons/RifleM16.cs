using Code.Gameplay.Infrastructure.Services;
using UnityEngine;
using UnityEngine.Audio;

namespace Code.Gameplay.Features.Weapons
{
   public class RifleM16 : MonoBehaviour
   {
      [SerializeField] private Transform _shootPoint;
      [SerializeField] private float _bulletSpeed;
      [SerializeField] private GameObject _bulletPrefab;
      [SerializeField] private StandaloneInputService _inputService;
        [SerializeField] private AudioClip _clip;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private AudioMixerGroup _audioMixerGroup;


        public void Update()
      {
         if (_inputService.HasShootInput())
         {
            Shoot();
         }
      }

      public void Shoot()
      {
         Bullet bulletInstance = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.identity).GetComponent<Bullet>();
         bulletInstance.transform.position = _shootPoint.position;
         bulletInstance.transform.forward = transform.forward;
         bulletInstance.SetDirection(transform.forward, _bulletSpeed);
            _audioSource.PlayOneShot(_clip);
            _audioMixerGroup.audioMixer.SetFloat("VolumeShooting", Random.Range(0, 5));
        }
   }
}