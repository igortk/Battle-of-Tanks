using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace Assets.Classes
{
    public class FastCannon:Cannon
    {
        public bool _hit { get; set; }
        public Sprite _fastCannon { get; set; }
    
        public FastCannon(int damage, int shotDistance, int lvl, int speedMove, bool hit) : 
                                                base(damage, shotDistance, lvl, speedMove,hit)
        {

        }

        public override bool CannonShot(int probabilityHit)
        {
            int probability = UnityEngine.Random.Range(1,10);
            if (probability<=probabilityHit)
            {
                return _hit = true;
            }
            return _hit = false;
        }
    }
}
