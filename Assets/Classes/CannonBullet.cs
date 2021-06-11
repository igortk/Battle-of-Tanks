using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Classes
{
    public class CannonBullet
    {
        //расстояние выстрела
        public int _shotDistance { get; set; }
        //Урон снаряда 
        public int _damage { get; set; }
        //Скорость снаряда
        public float _speedMove { get; set; }
        //попадание
        public bool _hit { get; set; }

        public CannonBullet()
        { }

        public CannonBullet(bool hit, int shotDistance,int damage, float speedMove)
        {
            _hit = hit;
            _shotDistance = shotDistance;
            _damage = damage;
            _speedMove = speedMove;
        }

        public void SetParams(bool hit,int shotDistance, int damage, float speedMove)
        {
            _hit = hit;
            _shotDistance = shotDistance;
            _damage = damage;
            _speedMove = speedMove;
        }

    }
}
