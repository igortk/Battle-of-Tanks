using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Classes
{
    public class Tower : Module
    {
        public int _accuracy { get; set; }

        public Tower(int accuracy, int lvl):base(lvl)
        {
            _accuracy = accuracy;
        }
    }
}
