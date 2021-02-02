using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids
{
    public class BulletPool
    {
        private readonly int _capacityPool;
        private readonly List<Bullet> _bulletPool;

        private Transform _rootPool;

        public BulletPool(int capacityPool)
        {
            _bulletPool = new List<Bullet>();
            _capacityPool = capacityPool;
            if (!_rootPool)
                _rootPool = new
               GameObject(NameManager.POOL_AMMUNITION).transform;
        }
        //public Bullet GetBullet()
        //{

        //}
    }
}
