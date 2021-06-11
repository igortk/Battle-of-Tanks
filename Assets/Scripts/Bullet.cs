using Assets.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour
{
    public Rigidbody2D RigidBodyBullet;
    private Vector2 startPoint;
    private CannonBullet CannonBullet = new CannonBullet();
    private Tank tank;

    void Start()
    {
        RigidBodyBullet.velocity = transform.up * CannonBullet._speedMove;
        startPoint = gameObject.transform.position;
    }

    private void Update()
    {
        if (System.Math.Abs(Vector2.Distance(startPoint, gameObject.transform.position))>= CannonBullet._shotDistance)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Если объект *collision* является модулем врага(Enemy) или союзника(player)
        if (collision.tag == "Enemy" || collision.tag == "Player") return;
        
        TankFunction enemy = collision.GetComponent<TankFunction>();
        if (enemy != null)
        {
            if (CannonBullet._hit)
            {
               enemy.TakeDamage(CannonBullet._damage);
            }
        }
        else
        {
            Base enemyBase = collision.GetComponent<Base>();
            if (enemyBase != null)
            {
                if (CannonBullet._hit)
                {
                    enemyBase.TakeDamage(CannonBullet._damage);
                }
            }
        }
        Destroy(gameObject);
    }

    public void SetData(CannonBullet cannon,Tank tank)
    {
        CannonBullet = cannon;
        this.tank = tank;
    }
}
