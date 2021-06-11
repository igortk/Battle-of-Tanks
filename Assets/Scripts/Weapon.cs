using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    //public Transform FirePoint;
    public GameObject bullet;

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Shoot() => Instantiate(bullet,gameObject.transform.position, gameObject.transform.rotation);
}
