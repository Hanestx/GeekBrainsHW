using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Decorator
{
    internal sealed class ModificationMuffler : ModificationWeapon
    {
        private readonly AudioSource _audioSource;
        private readonly IMuffler _muffler;
        private readonly Vector3 _mufflerPosition;
        private GameObject _mufflerPrefab;

        public ModificationMuffler(AudioSource audioSource, IMuffler muffler, Vector3 mufflerPosition)
        {
            _audioSource = audioSource;
            _muffler = muffler;
            _mufflerPosition = mufflerPosition;
        }
        
        protected override Weapon AddModification(Weapon weapon)
        {
            if (_mufflerPrefab)
            {
                _mufflerPrefab.SetActive(true);
                _audioSource.volume = _muffler.VolumeFireOnMuffler;
                weapon.SetAudioClip(_muffler.AudioClipMuffler);
                weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
                return weapon;
            }
            
            _mufflerPrefab = Object.Instantiate(_muffler.MufflerInstance, _mufflerPosition, Quaternion.identity);
            AddModification(weapon);
            return weapon;
        }

        protected override Weapon RemoveModification(Weapon weapon)
        {
            if (_mufflerPrefab)
            {
                _mufflerPrefab.SetActive(false);
                weapon.SetDefaultAudio();
                weapon.SetDefaultBarrelPosition();
                return weapon;
            }
            return weapon;
        }
    }
}