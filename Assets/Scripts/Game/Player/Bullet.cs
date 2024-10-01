using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    BulletManager manager;
    [SerializeField]
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(BulletManager _manager)
    {
        manager = _manager;
    }

    public void Fire(Vector3 startPos, float speed, Vector3 direction)
    {
        transform.position = startPos;
        rb.velocity = direction * speed;
    }
}
