using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Base : MonoBehaviour
{
    private int helth = 10;
    private Rigidbody2D componentRigidbody;
    private bool isEnemy;

    void Start()
    {
        componentRigidbody = GetComponent<Rigidbody2D>();
        componentRigidbody.freezeRotation = true;
    }

    public void TakeDamage(int damage)
    {
        helth -= damage;
        if (helth <= 0)
        {
            DestroyBase();
        }
    }

    void DestroyBase()
    {
        Destroy(gameObject);
        if (!isEnemy)
        {
            Debug.Log("You Lose");
            SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("You Won");
            SceneManager.LoadScene(0);
        }
    }

    public void SetEnemyOrNot(bool isEm)
    {
        isEnemy = isEm;
    }
}

