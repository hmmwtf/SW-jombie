using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun Type", menuName = "Gun Type")]
public class GunType : ScriptableObject
{
    // scriptable object�� ���� ������ ���� �����ϸ� �װ� �ش� ������Ʈ�� ���������� �����
    // ���� ĸ��ȭ�� Ȯ���� �ɾ���� ������ ���� ������ ���� ������ Ŭ������ ����ؼ� ���� �����ؾ���.

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
