using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Classes
{
    public class Tank
    {
        public bool _isBot { get; set; }

        public bool _isEnemy { get; set; }

        public Tower _tower { get; set; }

        public Hull _hull { get; set; }

        public Cannon _cannon { get; set; }

        public Tank() {}

        public void SetBotAndEnemy(bool isEnemy, bool isBot)
        {
            _isBot = isBot;
            _isEnemy = isEnemy;
        }

        public Tank(bool isBot ,bool isEnemy,Tower tower, Hull hull, Cannon cannon)
        {
            _isBot = isBot;
            _isEnemy = isEnemy;
            _tower = tower;
            _hull = hull;
            _cannon = cannon;
        }

        public void DefinitionTankModules()
        {
            int rand = UnityEngine.Random.Range(1, 3);
            if (rand == 1)
            {
                _tower = new Tower(7, 1);
            }
            else if (rand == 2)
            {
                _tower = new Tower(8, 2);
            }
            else
            {
                _tower = new Tower(9, 3);
            }
            rand = UnityEngine.Random.Range(1, 3);
            if (rand == 1)
            {
                _hull = new Hull(6f, 2, 1);
            }
            else if (rand == 2)
            {
                _hull = new Hull(4f, 4, 2);
            }
            else
            {
               _hull = new Hull(3f, 6, 3);
            }
            rand = UnityEngine.Random.Range(1, 6);
            if (rand == 1)
            {
                _cannon = new FastCannon(1, 3, 1, 7, true);
            }
            else if (rand == 2)
            {
                _cannon = new FastCannon(2, 4, 2, 7, true);
            }
            else if (rand == 3)
            {
                _cannon = new FastCannon(3, 5, 3, 7, true);
            }
            else if (rand == 4)
            {
                _cannon = new PoweredCannon(2, 4, 1, 7, true);
            }
            else if (rand == 5)
            {
                _cannon = new PoweredCannon(4, 6, 2, 7, true);
            }
            else if (rand == 6)
            {
                _cannon = new PoweredCannon(6, 8, 3, 7, true);
            }
        }

        public void DefinitionTankModulesForChange(string typeModule)
        {
            if (typeModule.Contains("Tower"))
            {
                if (typeModule.Contains("1"))
                {
                    _tower = new Tower(7, 1);
                }
                else if (typeModule.Contains("2"))
                {
                    _tower = new Tower(8, 2);
                }
                else
                {
                    _tower = new Tower(9, 3);
                }
            }
            else if (typeModule.Contains("Hull"))
            {
                if (typeModule.Contains("1"))
                {
                    _hull = new Hull(6f, 2, 1);
                }
                else if (typeModule.Contains("2"))
                {
                    _hull = new Hull(4f, 4, 2);
                }
                else
                {
                    _hull = new Hull(3f, 6, 3);
                }
            }
            else if (typeModule.Contains("FastCannon"))
            {
                if (typeModule.Contains("1"))
                {
                    _cannon = new FastCannon(1, 3, 1, 7, true);
                }
                else if (typeModule.Contains("2"))
                {
                    _cannon = new FastCannon(2, 4, 2, 7, true);
                }
                else
                {
                    _cannon = new FastCannon(3, 5, 3, 7, true);
                }
            }
            else if (typeModule.Contains("PoweredCannon"))
            {
                if (typeModule.Contains("1"))
                {
                    _cannon = new PoweredCannon(2, 4, 1, 7, true);
                }
                else if (typeModule.Contains("2"))
                {
                    _cannon = new PoweredCannon(4, 6, 2, 7, true);
                }
                else
                {
                    _cannon = new PoweredCannon(6, 8, 3, 7, true);
                }
            }
        }

    }
}
