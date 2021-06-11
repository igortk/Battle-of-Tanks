using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Classes
{
    public static class PathToPrefabs
    {
        public const string Chassis = "Chassis";
        //--------------Название модуля для вражеских танков--------------------------

        public struct Enemy
        {
            public const string EnemyFastCannon1 = "EnemyFastCannon1";
            public const string EnemyFastCannon2 = "EnemyFastCannon2";
            public const string EnemyFastCannon3 = "EnemyFastCannon3";
            public const string EnemyHull1 = "EnemyHull1";
            public const string EnemyHull2 = "EnemyHull2";
            public const string EnemyHull3 = "EnemyHull3";
            public const string EnemyPoweredCannon1 = "EnemyPoweredCannon1";
            public const string EnemyPoweredCannon2 = "EnemyPoweredCannon2";
            public const string EnemyPoweredCannon3 = "EnemyPoweredCannon3";
            public const string EnemyTower1 = "EnemyTower1";
            public const string EnemyTower2 = "EnemyTower2";
            public const string EnemyTower3 = "EnemyTower3";
        }

        //--------------Название модуля для союзных танков--------------------------
        public struct Player
        {
            public const string PlayerFastCannon1 = "PlayerFastCannon1";
            public const string PlayerFastCannon2 = "PlayerFastCannon2";
            public const string PlayerFastCannon3 = "PlayerFastCannon3";
            public const string PlayerHull1 = "PlayerHull1";
            public const string PlayerHull2 = "PlayerHull2";
            public const string PlayerHull3 = "PlayerHull3";
            public const string PlayerPoweredCannon1 = "PlayerPoweredCannon1";
            public const string PlayerPoweredCannon2 = "PlayerPoweredCannon2";
            public const string PlayerPoweredCannon3 = "PlayerPoweredCannon3";
            public const string PlayerTower1 = "PlayerTower1";
            public const string PlayerTower2 = "PlayerTower2";
            public const string PlayerTower3 = "PlayerTower3";
        }
        public static string GetCannonTypeLvl(Tank tank)
        {
            if (tank._isEnemy)
            {
                if (tank._cannon is FastCannon)
                {
                    switch (tank._cannon.LvlModul)
                    {
                        case 1: return Enemy.EnemyFastCannon1;
                        case 2: return Enemy.EnemyFastCannon2;
                        case 3: return Enemy.EnemyFastCannon3;
                    }
                }
                else if (tank._cannon is PoweredCannon)
                {
                    switch (tank._cannon.LvlModul)
                    {
                        case 1: return Enemy.EnemyPoweredCannon1;
                        case 2: return Enemy.EnemyPoweredCannon2;
                        case 3: return Enemy.EnemyPoweredCannon3;
                    }
                }
            }
            else
            {
                if (tank._cannon is FastCannon)
                {
                    switch (tank._cannon.LvlModul)
                    {
                        case 1: return Player.PlayerFastCannon1;
                        case 2: return Player.PlayerFastCannon2;
                        case 3: return Player.PlayerFastCannon3;
                    }
                }
                else if (tank._cannon is PoweredCannon)
                {
                    switch (tank._cannon.LvlModul)
                    {
                        case 1: return Player.PlayerPoweredCannon1;
                        case 2: return Player.PlayerPoweredCannon2;
                        case 3: return Player.PlayerPoweredCannon3;
                    }
                }
            }
            return "";
        }

        public static string GetHullLvl(Tank tank)
        {
            if (tank._isEnemy)
            {
                switch (tank._hull.LvlModul)
                {
                    case 1: return Enemy.EnemyHull1;
                    case 2: return Enemy.EnemyHull2;
                    case 3: return Enemy.EnemyHull3;
                    default: return "";
                }
            }
            else
            {
                switch (tank._hull.LvlModul)
                {
                    case 1: return Player.PlayerHull1;
                    case 2: return Player.PlayerHull2;
                    case 3: return Player.PlayerHull3;
                    default: return "";
                }
            }
        }
        
        public static string GetTowerLvl(Tank tank)
        {
            if (tank._isEnemy)
            {
                switch (tank._tower.LvlModul)
                {
                    case 1: return Enemy.EnemyTower1;
                    case 2: return Enemy.EnemyTower2;
                    case 3: return Enemy.EnemyTower3;
                    default: return "";
                }
            }
            else
            {
                switch (tank._tower.LvlModul)
                {
                    case 1: return Player.PlayerTower1;
                    case 2: return Player.PlayerTower2;
                    case 3: return Player.PlayerTower3;
                    default: return "";
                }
            }

        }

        public static string GetRandomModulLvl(Tank tank)
        {
            string pathCannon, pathTower, pathHull;
            int probability = Random.Range(1, 5);
            switch (probability)
            {
                case 1:
                    pathCannon = GetCannonTypeLvl(tank);
                    return pathCannon;
                case 2:
                    pathTower = GetTowerLvl(tank);
                    return pathTower;
                default:
                    pathHull = GetHullLvl(tank);
                    return pathHull;
            }
        }


        //public 
        /*

        public static string GetObjectPath(GameObject droppedItem,Tank tank)
        {
            var whoseModule = droppedItem.name.Contains("Enemy");
            if (tank._isEnemy)
            {

            }
        }*/
    }
}
