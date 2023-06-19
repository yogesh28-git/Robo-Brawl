using System;
using UnityEngine;

namespace RoboBrawl
{
    public class AudioManagerService : MonoSingletonGeneric<AudioManagerService>
    {   
        [SerializeField] private Sound[] sounds;

        [SerializeField]
        private AudioSource music;
        [SerializeField]
        private AudioSource sfx;

        public void PlayMusic( SoundType sound )
        {
            Sound item = Array.Find( sounds, i => i.Type == sound );
            AudioClip clip = item.Clip;
            if ( clip != null )
            {
                music.clip = clip;
                music.Play( );
            }
        }
        public void PlaySfx( SoundType sound )
        {
            Sound item = Array.Find( sounds, i => i.Type == sound );
            AudioClip clip = item.Clip;
            if ( clip != null )
            {
                sfx.PlayOneShot( clip );
            }
        }
    }
}
