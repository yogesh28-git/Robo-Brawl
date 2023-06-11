using System.Collections;
using UnityEngine;

namespace RoboBrawl
{
    public interface ICharacterView
    {
        public IDamagable GetController( );
    }
}