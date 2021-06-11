using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Classes
{
    public class Cannon : Module
    {
        public CannonBullet _bullet { get; set; }

        public int _shotDistance { get; set; }

        public Cannon(int damage, int shotDistance, int lvl,int speedMove,bool hit):base(lvl)
        {
            _bullet = new CannonBullet(hit,shotDistance, damage, speedMove);
            _shotDistance = shotDistance;
        }

        public virtual bool CannonShot(int probabilityHit) { return true; }
    }
}
