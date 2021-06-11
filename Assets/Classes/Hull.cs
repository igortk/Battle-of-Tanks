using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Classes
{
    public class Hull : Module
    {
        public int _hp { get; set; }

        public float _speed { get; set; }

        public Hull(float speed, int hp, int lvl):base(lvl)
        {
            _speed = speed;
            _hp = hp;
        }
    }
}
