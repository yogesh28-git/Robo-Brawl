using System.Collections.Generic;
using UnityEngine;

namespace RoboBrawl
{
    public class GenericObjectPool<T,U> : MonoSingletonGeneric<T> 
        where T: GenericObjectPool<T,U> 
        where U: MonoBehaviour
    {
        private Queue<U> objectPool = new Queue<U>();

        public virtual U GetFromPool( Transform spawnPos )
        {
            U item;
            if (objectPool.Count == 0 )
            {
                item = CreateNewItem( );
                item.gameObject.SetActive( false );
            }
            else
            {
                item = objectPool.Dequeue( );
            }
            item.transform.position = spawnPos.position;
            item.transform.rotation = spawnPos.rotation;
            item.gameObject.SetActive( true );
            return item;
        }

        public virtual void ReturnToPool( U item)
        {
            item.gameObject.SetActive( false );
            objectPool.Enqueue( item );
        }

        public virtual U CreateNewItem( )
        {
            return null as U;
        }
    }
}
