using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private int poolSize;
    [SerializeField] private Bullet _bulletPrefab;

    private static BulletPool _instance;
    public static BulletPool Instance
    {
        get { return _instance; }
    }

    private List<Bullet> pool;

    void Awake()
    {
        _instance  = this;

        pool = new List<Bullet>();
        for (int i = 0; i < poolSize; i++)
        {
            var bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity, null);
            bullet.gameObject.SetActive(false);
            pool.Add(bullet);
        }
    }

    public Bullet GetBulletFromPool()
    {
        Bullet bulletFromPool = pool[Random.Range(0, poolSize)];
        while (bulletFromPool.gameObject.activeInHierarchy)
        {
            bulletFromPool = pool[Random.Range(0, poolSize)];
        }

        return bulletFromPool;
    } 
}
