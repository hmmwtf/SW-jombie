using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 dir;

    public float speed = 5.0f;
    public BulletManager bulletManager;

    bool canFire = true;

    private void FixedUpdate()
    {
        // �Է��� �޾ƿ� ��ġȭ�ϱ� (����: �����̸� moveH�� -1, �������̸� moveH�� 1)
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        // ���� �Է¿� ���� �̵� ���� ����
        Vector3 movement = new Vector3(moveH, moveV, 0.0f);

        // �̵� ���͸� �̿��� �̵�
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // ���콺�� ��ġ�� �޾ƿ� �÷��̾�� ���콺�� �ٶ󺸴� ������ ����
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = (mousePos - transform.position).normalized;

        // ���� ������ ������ ���� (�Լ��� ��ȯ���� �����ε� �������� ������ ���⿡ ��ȯ����)
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // ȸ���ϱ� (90���� ���� ����)
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);

        // Ű �Է� �޾� ����
        if (Input.GetButton("Fire1") && canFire)
        {
            FireBullet();
            StartCoroutine(FireRate());
        }
        
        // �÷��̾� ��ġ�� ����Ʈ ��ǥ�� �޾ƿ� ȭ�� ���̸� ����ְ� ��ȯ.
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0) pos.x = 0;
        if (pos.x > 1) pos.x = 1;
        if (pos.y < 0) pos.y = 0;
        if (pos.y > 1) pos.y = 1;

        transform.position = Camera.main.ViewportToWorldPoint(pos);

    }

    IEnumerator FireRate()
    {
        canFire = false;
        yield return new WaitForSeconds(GameManager.Instance.currentGunType.FireRate);
        canFire = true;
    }

    [ContextMenu("Fire Bullet")]
    void FireBullet()
    {
        bulletManager.FireBullet(transform.position, dir);
    }
}
