using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeRotate : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    private void Update()
    {
        Vector3 moveDirection = player.position - transform.position;

        float angle = Mathf.Atan(moveDirection.x / moveDirection.z) * Mathf.Rad2Deg;

        if (moveDirection.z < 0)
        {
            angle += 180;
        }

        transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
