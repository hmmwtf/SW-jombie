using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public Bullet bulletPrefab;
    [SerializeField]
    private Bullet[] bullets;
    int idx = 0;

    public float bulletSpeed = 5.0f;

    private void Start()
    {
        bullets = new Bullet[10];
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i] = Instantiate(bulletPrefab, transform);
            bullets[i].Init(this);
            bullets[i].gameObject.SetActive(false);
        }
    }

    public void FireBullet(Vector3 start, Vector3 dir)
    {
        var bul = bullets[idx++];
        if (idx >= bullets.Length)
        {
            idx = 0;
        }

        bul.gameObject.SetActive(true);
        bul.Fire(start, bulletSpeed, dir);
    }
}
