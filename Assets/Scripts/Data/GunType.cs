using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun Type", menuName = "Gun Type")]
public class GunType : ScriptableObject
{
    // scriptable object는 게임 내에서 값을 수정하면 그게 해당 오브젝트에 영구적으로 저장됨
    // 따라서 캡슐화를 확실히 걸어놓고 수정할 일이 있으면 따로 보관용 클래스를 사용해서 값을 수정해야함.

    [SerializeField] private string gunName;
    public string GunName { get { return gunName; } }

    [SerializeField] private Sprite gunSprite;
    public Sprite GunSprite { get { return gunSprite; } }

    [SerializeField] private float fireRate;
    public float FireRate { get { return fireRate; } }

    [SerializeField] private float bulletSpeed;
    public float BulletSpeed { get { return bulletSpeed; } }

    [SerializeField] private float bulletDamage;
    public float BulletDamage { get { return bulletDamage; } }

    [SerializeField] private int maxAmmo;
    public int MaxAmmo { get { return maxAmmo; } }
}
