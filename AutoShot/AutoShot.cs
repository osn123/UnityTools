using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // DOTween�̖��O��Ԃ�ǉ�

public class AutoShot : MonoBehaviour
{
    public GameObject bulletPrefab; // �e�̃v���n�u
    public GameObject player; // �e�̃v���n�u
    public Transform firePoint; // �e�����˂����ʒu
    public float attackInterval = 1f; // �U���Ԋu
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
        canAttack = false; // �U�����͑��̍U����h��

        // DOTween�ōU���Ԋu���Ǘ�
        DOVirtual.DelayedCall(0, () => FireBullet(enemy)); // ����U��
        DOVirtual.DelayedCall(attackInterval, () =>
        {
            if (enemy != null) // �G���܂����݂���ꍇ
            {
                FireBullet(enemy);
                DOVirtual.DelayedCall(attackInterval, () => Attack(enemy)); // �ċA�I�ɌĂяo��
            }
            else
            {
                canAttack = true; // �G�����Ȃ��Ȃ�����U���\�ɖ߂�
            }
        });
    }

    private void FireBullet(Transform target)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector3 direction = (target.position - firePoint.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = direction * 20f; // �e������
    }
}
