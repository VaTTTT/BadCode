using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
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

        while (isShooting)
        {
            var shootDirection = (_target.position - transform.position).normalized;
            var newBullet = Instantiate(_bullet, transform.position + shootDirection, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = shootDirection;
            newBullet.GetComponent<Rigidbody>().velocity = shootDirection * _velocity;

            yield return new WaitForSeconds(_shootingDelay);
         }
    }
}

[System.Serializable]
public class Bullet
{
}