using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; // DOTween‚Ì–¼‘O‹óŠÔ‚ğ’Ç‰Á

public class AutoShot : MonoBehaviour
{
    public GameObject bulletPrefab; // ’e‚ÌƒvƒŒƒnƒu
    public GameObject player; // ’e‚ÌƒvƒŒƒnƒu
    public Transform firePoint; // ’e‚ª”­Ë‚³‚ê‚éˆÊ’u
    public float attackInterval = 1f; // UŒ‚ŠÔŠu
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
        canAttack = false; // UŒ‚’†‚Í‘¼‚ÌUŒ‚‚ğ–h‚®

        // DOTween‚ÅUŒ‚ŠÔŠu‚ğŠÇ—
        DOVirtual.DelayedCall(0, () => FireBullet(enemy)); // ‰‰ñUŒ‚
        DOVirtual.DelayedCall(attackInterval, () =>
        {
            if (enemy != null) // “G‚ª‚Ü‚¾‘¶İ‚·‚éê‡
            {
                FireBullet(enemy);
                DOVirtual.DelayedCall(attackInterval, () => Attack(enemy)); // Ä‹A“I‚ÉŒÄ‚Ño‚·
            }
            else
            {
                canAttack = true; // “G‚ª‚¢‚È‚­‚È‚Á‚½‚çUŒ‚‰Â”\‚É–ß‚·
            }
        });
    }

    private void FireBullet(Transform target)
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Vector3 direction = (target.position - firePoint.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = direction * 20f; // ’e‘¬’²®
    }
}
