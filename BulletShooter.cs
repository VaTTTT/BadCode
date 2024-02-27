using System.Collections;
using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _target;
    [SerializeField] private float _velocity;
    [SerializeField] private float _shootingDelay;

    private void Start() 
    {
        StartCoroutine(Shoot());
    }
    
    private IEnumerator Shoot()
    {
        bool isShooting = enabled;

        WaitForSeconds shootingDelay = new WaitForSeconds(_shootingDelay);

        while (isShooting)
        {
            Vector3 shootDirection = (_target.position - transform.position).normalized;
            Bullet newBullet = Instantiate(_bullet, transform.position + shootDirection, Quaternion.identity);

            newBullet.transform.up = shootDirection;
            newBullet.GetComponent<Rigidbody>().velocity = shootDirection * _velocity;

            yield return shootingDelay;
         }
    }
}