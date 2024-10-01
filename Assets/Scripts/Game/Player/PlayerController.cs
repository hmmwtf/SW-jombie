using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f;
    public BulletManager bulletManager;

    private void Start()
    {


    }

    private void FixedUpdate()
    {
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveH, moveV, 0.0f);

        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        if (Input.GetButton("Fire1"))
        {
            FireBullet();
        }
    }

    [ContextMenu("Fire Bullet")]
    void FireBullet()
    {
        bulletManager.FireBullet(transform.position, Vector3.up);
    }
}
