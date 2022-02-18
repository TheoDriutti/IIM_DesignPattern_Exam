using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFire : MonoBehaviour
{
    [SerializeField] Transform _spawnPoint;
    [SerializeField] Bullet _bulletPrefab;

    private bool _isShielded = false;

    public void FireBullet(int power)
    {
        if (!_isShielded)
        {
            var b = BulletPool.Instance.GetBulletFromPool();
            b.transform.position = _spawnPoint.position;
            b.gameObject.SetActive(true);
            b.Init(_spawnPoint.TransformDirection(Vector3.right), power);
            
            //var b = Instantiate(_bulletPrefab, _spawnPoint.transform.position, Quaternion.identity, null)
            //    .Init(_spawnPoint.TransformDirection(Vector3.right), power);
        }
    }

    public void SetShield(bool val)
    {
        _isShielded = val;
    }
}