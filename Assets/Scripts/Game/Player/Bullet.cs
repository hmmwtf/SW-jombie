using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    BulletManager manager;
    Rigidbody2D rb;

    // 오브젝트의 속도가 너무 높아지지 않게 곱해지는 값
    const float bulletSpeed = 10f;

    Vector2 dir;

    float bulletDamage;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init(BulletManager _manager)
    {
        manager = _manager;
    }

    public void Fire(Vector3 startPos, Vector2 direction)
    {
        bulletDamage = GameManager.Instance.currentGunType.BulletDamage;

        // startPos에서 direction 방향으로 총알 발사
        transform.position = startPos;
        dir = direction.normalized;

        // direction 방향으로 회전
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);
    }

    private void FixedUpdate()                              
    {
        rb.MovePosition(rb.position + dir * GameManager.Instance.currentGunType.BulletSpeed * bulletSpeed * Time.deltaTime);
    }

    // Wall 태그와 충돌하면 비활성    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            gameObject.SetActive(false);
        }
    }
}
