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
        // 입력을 받아와 수치화하기 (예시: 왼쪽이면 moveH가 -1, 오른쪽이면 moveH가 1)
        float moveH = Input.GetAxis("Horizontal");
        float moveV = Input.GetAxis("Vertical");

        // 들어온 입력에 따라 이동 벡터 생성
        Vector3 movement = new Vector3(moveH, moveV, 0.0f);

        // 이동 벡터를 이용해 이동
        transform.Translate(movement * speed * Time.deltaTime, Space.World);

        // 마우스의 위치를 받아와 플레이어에서 마우스를 바라보는 방향을 구함
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dir = (mousePos - transform.position).normalized;

        // 구한 방향의 각도를 구함 (함수의 반환값은 라디안인데 돌릴때는 각도를 쓰기에 변환해줌)
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        // 회전하기 (90도를 빼서 보정)
        transform.rotation = Quaternion.Euler(0, 0, angle - 90f);

        // 키 입력 받아 실행
        if (Input.GetButton("Fire1") && canFire)
        {
            FireBullet();
            StartCoroutine(FireRate());
        }
        
        // 플레이어 위치를 뷰포트 좌표로 받아와 화면 밖이면 집어넣고 변환.
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
