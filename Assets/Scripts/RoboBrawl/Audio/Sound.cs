using System;
using UnityEngine;

namespace RoboBrawl
{
    [Serializable]
    public class Sound
    {
        public SoundType Type { get { return type; } set { } }
        public AudioClip Clip { get { return clip; } set { } }
        [SerializeField] private SoundType type;
        [SerializeField] private AudioClip clip;
    }
}