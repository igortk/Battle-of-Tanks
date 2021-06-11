using Assets.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TankFunction : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _componentRigidbody;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _firePoint;
    private GameObject _droppedItem;
    private float _waitingShootTime;
    private float _startWaitTime;
    private bool _destroid;
    public Tank tank = new Tank();
    List<Vector3> targets;

    void Start()
    {
        targets = GameObject.FindObjectOfType<Spawn>().vector3s2;
        _startWaitTime = 1.5f;
        _componentRigidbody = GetComponent<Rigidbody2D>();
        _componentRigidbody.freezeRotation = true;
        _destroid = false;
        tank.DefinitionTankModules();
        //Башня
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = 
                    Resources.Load<Sprite>("Sprites/"+PathToPrefabs.GetTowerLvl(tank));
        //Пушка
        gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = 
                    Resources.Load<Sprite>("Sprites/" + PathToPrefabs.GetCannonTypeLvl(tank));
        //Шасси
        gameObject.transform.GetChild(3).GetComponent<SpriteRenderer>().sprite = 
                    Resources.Load<Sprite>("Sprites/" + PathToPrefabs.Chassis);
        //Корпус
        gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = 
                    Resources.Load<Sprite>("Sprites/" + PathToPrefabs.GetHullLvl(tank));
        //Проверка на игрока
        if (!tank._isBot && !tank._isEnemy)
        {
            GameObject.FindObjectOfType<FollowCamera>().SetObject(gameObject);
        }
    }

    void Update()
    {
        _componentRigidbody.velocity = Vector2.zero;
        _waitingShootTime -= Time.deltaTime;

        if (!tank._isBot)
        {
            PlayerAction();
        }
        else
        {
            BotMoving();
            //Shoot();
        }
    }
  
    void Shoot()
    {
        if (_waitingShootTime <= 0)
        {
            if (tank._cannon is FastCannon)
            {
                Vector3 distanceBullet;
                Instantiate(_bullet, _firePoint.transform.position, _firePoint.transform.rotation).
                            GetComponent<Bullet>().SetData(new CannonBullet(tank._cannon.CannonShot(tank._tower._accuracy),
                            tank._cannon._shotDistance,
                            tank._cannon._bullet._damage,
                            tank._cannon._bullet._speedMove), this.tank);
                float angle = _firePoint.transform.rotation.eulerAngles.z;
                switch (angle)
                {
                    case 180: 
                        distanceBullet = new Vector3(-0.15f, 0.15f);
                        break;
                    case 90:
                        distanceBullet = new Vector3(-0.15f, 0.15f);
                        break;
                    case 270:
                        distanceBullet = new Vector3(0.15f, -0.15f);
                        break;
                    default:
                        distanceBullet = new Vector3(0.15f, -0.15f);
                        break;
                }
                Instantiate(_bullet, _firePoint.transform.position+ distanceBullet, _firePoint.transform.rotation).
                            GetComponent<Bullet>().SetData(new CannonBullet(tank._cannon.CannonShot(tank._tower._accuracy),
                            tank._cannon._shotDistance,
                            tank._cannon._bullet._damage,
                            tank._cannon._bullet._speedMove), this.tank);
            }
            else
            {
                Instantiate(_bullet, _firePoint.transform.position, _firePoint.transform.rotation).
                             GetComponent<Bullet>().SetData(new CannonBullet(tank._cannon.CannonShot(tank._tower._accuracy),
                             tank._cannon._shotDistance,
                             tank._cannon._bullet._damage,
                             tank._cannon._bullet._speedMove), this.tank);
            }
            _waitingShootTime = _startWaitTime;
        }
    }
 
    public void TakeDamage(int damage)
    {
        GameObject.FindObjectOfType<Spawn>();
        tank._hull._hp -= damage;
        if (tank._hull._hp <= 0)
        {
            Die();
        }
        else
        {
            return;
        }
        if (tank._isEnemy)
        {
            GameObject.FindObjectOfType<Spawn>().QuantityEnemyNow--;
            GameObject.FindObjectOfType<Spawn>().FindTank();
        }
        else if (!tank._isEnemy)
        {
            GameObject.FindObjectOfType<Spawn>().QuantityAlliesNow--;
            GameObject.FindObjectOfType<Spawn>().FindTank();
        }
    }

    void Die()
    {
        if (!tank._isBot && !tank._isEnemy)
        {
            Debug.Log("You lose");
            SceneManager.LoadScene(0);
        }
        else
        {
            Object ModulSprite = Resources.Load<Object>("Prefabs/" + PathToPrefabs.GetRandomModulLvl(tank));
            Instantiate(ModulSprite, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void PlayerAction()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            _componentRigidbody.velocity += Vector2.left * tank._hull._speed;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            _componentRigidbody.velocity += Vector2.right * tank._hull._speed;
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            _componentRigidbody.velocity += Vector2.up * tank._hull._speed;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            _componentRigidbody.velocity += Vector2.down * tank._hull._speed;
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
        if (_droppedItem!=null)
        {
            if (Input.GetKey(KeyCode.M))
            {
                Destroy(_droppedItem.gameObject);
            }
            else if(Input.GetKey(KeyCode.Z))
            {
                if (_droppedItem.tag == "Enemy" || _droppedItem.tag == "Player")
                {
                    if (!tank._isEnemy)
                    {
                        AdaptationModules(_droppedItem.gameObject);
                        Destroy(_droppedItem.gameObject);
                    }
                    else
                    {
                        _destroid = true;
                    }
                }
            }
        }
    }

    void BotMoving()
    {
        int randomPointIndex = Random.Range(1,targets.Count);
        transform.position = Vector3.MoveTowards(transform.position, targets[randomPointIndex], tank._hull._speed*Time.deltaTime);
    }

    private void AdaptationModules(GameObject objItem)
    {
        string typeModule = objItem.GetComponent<SpriteRenderer>().sprite.name;
        tank.DefinitionTankModulesForChange(typeModule);
        if (typeModule.Contains("Tower"))
        {
            //Башня
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = 
                Resources.Load<Sprite>("Sprites/" + PathToPrefabs.GetTowerLvl(tank));
        }
        else if(typeModule.Contains("Cannon"))
        {
            //Пушка
            gameObject.transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = 
                Resources.Load<Sprite>("Sprites/" + PathToPrefabs.GetCannonTypeLvl(tank));
        }
        else if (typeModule.Contains("Hull"))
        {
            //Корпус
            gameObject.transform.GetChild(4).GetComponent<SpriteRenderer>().sprite = 
                Resources.Load<Sprite>("Sprites/" + PathToPrefabs.GetHullLvl(tank));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_destroid)
        {
            Destroy(other.gameObject);
            _destroid = false;
            return;
        }
        _droppedItem = other.gameObject;
        _destroid = false;
    }
}
