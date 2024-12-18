using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // DOTweenの名前空間を追加

public class AutoShot : MonoBehaviour
{
    public GameObject bulletPrefab; // 弾のプレハブ
    public GameObject player; // 弾のプレハブ
    public Transform firePoint; // 弾が発射される位置
    public float attackInterval = 1f; // 攻撃間隔
    private bool canAttack = true;

    void Start()
    {
      
            Attack(player.transform);
    }

    //void OnTriggerStay(Collider other)
    //{
    //    if (other.CompareTag("Enemy") && canAttack)
    //        if (transform.position.x < 0 && canAttack)
    //        {
    //            Attack(other.transform);
    //        }
    //}

    private void Attack(Transform enemy)
    {
        canAttack = false; // 攻撃中は他の攻撃を防ぐ

        // DOTweenで攻撃間隔を管理
        DOVirtual.DelayedCall(0, () => FireBullet(enemy)); // 初回攻撃
        DOVirtual.DelayedCall(attackInterval, () =>
        {
            if (enemy != null) // 敵がまだ存在する場合
            {
                FireBullet(enemy);
                DOVirtual.DelayedCall(attackInterval, () => Attack(enemy)); // 再帰的に呼び出す
            }
            else
            {
                canAttack = true; // 敵がいなくなったら攻撃可能に戻す
            }
        });
    }

    private void FireBullet(Transform target)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector3 direction = (target.position - firePoint.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = direction * 20f; // 弾速調整
    }
}
