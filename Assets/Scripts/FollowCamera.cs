using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    public void SetObject(GameObject obj)
    {
        player = obj;
        offset = transform.position - obj.transform.position;
    }

    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
