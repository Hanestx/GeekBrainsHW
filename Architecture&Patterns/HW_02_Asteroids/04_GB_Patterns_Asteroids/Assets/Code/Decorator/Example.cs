using UnityEngine;

namespace Asteroids.Decorator
{
    internal sealed class Example : MonoBehaviour
    {
        private IFire _fire;
        private Weapon _weapon;
        private ModificationWeapon _modificationWeaponAim;
        private ModificationWeapon _modificationWeaponMuffler;

        private bool _isAim = true;
        private bool _isMuffler = true;

        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        
        [Header("Muffler Gun")]
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _mufflerPrefab;
        
        [Header("Aim Gun")]
        [SerializeField] private GameObject _aimPrefab;
        [SerializeField] private Transform _barrelPositionAim;
        
        private void Start()
        {
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            _weapon = new Weapon(ammunition, _barrelPosition, 999.0f, _audioSource, _audioClip);
            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPosition, _mufflerPrefab);
            var aim = new Aim(_aimPrefab, _barrelPositionAim);
            
            _modificationWeaponMuffler = new ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);
            _modificationWeaponMuffler.ApplyModification(_weapon);
            _fire = _modificationWeaponMuffler;

            _modificationWeaponAim = new ModificationAim(aim, _barrelPositionAim.position);
            _modificationWeaponAim.ApplyModification(_weapon);

        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }

            if (Input.GetKeyDown(KeyCode.C))
            {
                if (_isAim)
                {
                    _modificationWeaponAim.CanselModification(_weapon);
                    _isAim = false;
                }
                else
                {
                    _modificationWeaponAim.ApplyModification(_weapon);
                    _isAim = true;
                }
            }
            
            if (Input.GetMouseButtonDown(1))
            {
                if (_isMuffler)
                {
                    _modificationWeaponMuffler.CanselModification(_weapon);
                    _isMuffler = false;
                }
                else
                {
                    _modificationWeaponMuffler.ApplyModification(_weapon);
                    _isMuffler = true;
                }
                
            }
        }
    }
}