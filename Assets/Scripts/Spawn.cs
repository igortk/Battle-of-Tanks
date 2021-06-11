using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    //Префаб земли
    public GameObject CellGround;
    //Префаб камня
    public GameObject CellStone;
    //База противников
    public GameObject EnemyBase;
    //База игрока
    public GameObject PlayerBase;
    //База игрока
    public GameObject Tank;
    //Центр клетки
    private float centerY = 0.5f;
    private float centerX = 0.5f;
    //максимальная ширита и длина
    public readonly int Width = 40;
    public readonly int Height = 40;
    //количество танко в данный момент на карте и в резерве
    public int QuantityEnemyNow=0;
    public int QuantityAlliesNow=0;
    private int reserveEnemyTank = 28;
    private int reserveAllieTank = 28;

    public Vector3[,] vector3s;
    public List<Vector3> vector3s2;

    void Start()
    {
        vector3s = new Vector3[Width, Height];
        int xVec=0, yVec=0;
        //Цент одной клетки (x*0.5,y*0.5) поэтому цикл начинается с 0.5f
        for (float x = centerX; x <= Width; x++)
        {
            xVec = (int)(x- centerX);
            for (float y = centerY; y <= Height; y++)
            {
                yVec = (int)(y - centerY);
                if (x - centerX == 0 || x - centerX == Width - 1)
                {
                    Instantiate(CellStone, new Vector2(x, y), Quaternion.Euler(0, 0, 90));
                }
                else if (y - centerY == 0 || y - centerY == Height - 1)
                {
                    Instantiate(CellStone, new Vector2(x, y), Quaternion.identity);
                }
                int rand = Random.Range(1, 30);
                if (x< Width - 4&& x>4 && y < Height - 4&& y>4)
                {
                    if (rand <= 3)
                    {
                        Instantiate(CellStone, new Vector2(x, y), Quaternion.identity);
                        continue;
                    }
                    else if(rand <= 6 && rand > 3)
                    {
                        Instantiate(CellStone, new Vector2(x, y), Quaternion.Euler(0, 0, 90));
                    }
                }
                if (x- centerX == Width/2 && y- centerY == 37)
                {
                    Instantiate(CellGround, new Vector2(x, y), Quaternion.identity);
                    vector3s2.Add(new Vector3(x, y));
                    vector3s[xVec,yVec] = new Vector3(0, 0);
                    Instantiate(EnemyBase, new Vector2(x+centerX, y+centerY), Quaternion.identity).
                                                 GetComponent<Base>().SetEnemyOrNot(true);
                    
                    Instantiate(Tank, new Vector2(x + centerX - 2, y + centerY), Quaternion.Euler(0,0,180)).
                                                 GetComponent<TankFunction>().tank.SetBotAndEnemy(true, true);
                    Instantiate(Tank, new Vector2(x + centerX + 2, y + centerY), Quaternion.Euler(0, 0, 180)).
                                                 GetComponent<TankFunction>().tank.SetBotAndEnemy(true, true);
                    QuantityEnemyNow = 2;
                }
                else if (x - centerX == Width / 2 && y - centerY == 1)
                {
                    Instantiate(CellGround, new Vector2(x, y), Quaternion.identity);
                    vector3s2.Add(new Vector3(x, y));
                    vector3s[xVec,yVec] = (new Vector3(x, y));
                    Instantiate(PlayerBase, new Vector2(x + centerX, y + centerY), Quaternion.identity).
                                        GetComponent<Base>().SetEnemyOrNot(false);

                    Instantiate(Tank, new Vector2(x + centerX-2, y + centerY), Quaternion.identity).
                                        GetComponent<TankFunction>().tank.SetBotAndEnemy(false,true);
                    Instantiate(Tank, new Vector2(x + centerX + 2, y + centerY), Quaternion.identity).
                                        GetComponent<TankFunction>().tank.SetBotAndEnemy(false,false);
                    QuantityAlliesNow = 2;
                }
                else
                { 
                    Instantiate(CellGround, new Vector2(x, y), Quaternion.identity);
                    vector3s2.Add(new Vector3(x, y));
                    vector3s[xVec,yVec] = (new Vector3(x, y));
                }
            }
        }
    }

    void RespiwnTank()
    {
        if (QuantityAlliesNow < 2 && reserveAllieTank > 0 && QuantityAlliesNow!= reserveAllieTank)
        {
            Instantiate(Tank, new Vector2(19, 2), Quaternion.identity).
                        GetComponent<TankFunction>().tank.SetBotAndEnemy(false, true);

            reserveAllieTank--;
            QuantityAlliesNow++;
        }
        else if (QuantityEnemyNow < 2 && reserveEnemyTank > 0 && QuantityEnemyNow!= reserveEnemyTank)
        {
            Instantiate(Tank, new Vector2(19, 38), Quaternion.Euler(0, 0, 180)).
                       GetComponent<TankFunction>().tank.SetBotAndEnemy(true, true);

             reserveEnemyTank--;
             QuantityEnemyNow++;
        }
    }

    public void FindTank()
    {
        if (QuantityAlliesNow + QuantityEnemyNow < 4)
        {
            if (reserveEnemyTank > 0)
            {
                RespiwnTank();
            }
            else if(QuantityAlliesNow>0)
            {
                RespiwnTank();
            }
            else
            {
                Debug.Log("Congratulation!\nYou won");
            }
        }
    }
}
