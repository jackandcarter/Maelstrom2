using UnityEngine;
using System.Collections.Generic;

namespace BulletTypes
{
    public enum BulletType
    {
        Normal,
        Repeater,
        LongRange,
        Spreader,
        HomingMissile
    }
}

public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance { get; private set; } // Singleton instance.

    public GameObject normalBulletPrefab;
    public GameObject repeaterBulletPrefab;
    public GameObject longRangeBulletPrefab;
    public GameObject spreaderBulletPrefab;
    public GameObject homingMissilePrefab;

    private Dictionary<BulletTypes.BulletType, Queue<GameObject>> bulletPools;

    private void Awake()
    {
        // Ensure there's only one instance of BulletManager.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Initialize the bullet pools.
        bulletPools = new Dictionary<BulletTypes.BulletType, Queue<GameObject>>();

        // Initialize each bullet pool.
        InitializeBulletPool(BulletTypes.BulletType.Normal, normalBulletPrefab, 100);
        InitializeBulletPool(BulletTypes.BulletType.Repeater, repeaterBulletPrefab, 100);
        InitializeBulletPool(BulletTypes.BulletType.LongRange, longRangeBulletPrefab, 100);
        InitializeBulletPool(BulletTypes.BulletType.Spreader, spreaderBulletPrefab, 100);
        InitializeBulletPool(BulletTypes.BulletType.HomingMissile, homingMissilePrefab, 100);
    }

    private void InitializeBulletPool(BulletTypes.BulletType bulletType, GameObject bulletPrefab, int initialPoolSize)
    {
        Queue<GameObject> bulletPool = new Queue<GameObject>();

        // Instantiate and populate the initial pool.
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(false);
            bulletPool.Enqueue(bullet);
        }

        // Add the bullet pool to the dictionary.
        bulletPools[bulletType] = bulletPool;
    }

    public GameObject GetBullet(BulletTypes.BulletType bulletType)
    {
        if (bulletPools.ContainsKey(bulletType) && bulletPools[bulletType].Count > 0)
        {
            GameObject bullet = bulletPools[bulletType].Dequeue();
            bullet.SetActive(true);
            return bullet;
        }
        else
        {
            // If the pool is empty, instantiate a new bullet and increase the pool size.
            GameObject bulletPrefab = GetBulletPrefab(bulletType);
            GameObject bullet = Instantiate(bulletPrefab);
            bullet.SetActive(true);
            return bullet;
        }
    }

    public void ReturnBullet(BulletTypes.BulletType bulletType, GameObject bullet)
    {
        if (bulletPools.ContainsKey(bulletType))
        {
            bullet.SetActive(false);
            bulletPools[bulletType].Enqueue(bullet);
        }
    }

    private GameObject GetBulletPrefab(BulletTypes.BulletType bulletType)
    {
        switch (bulletType)
        {
            case BulletTypes.BulletType.Normal:
                return normalBulletPrefab;
            case BulletTypes.BulletType.Repeater:
                return repeaterBulletPrefab;
            case BulletTypes.BulletType.LongRange:
                return longRangeBulletPrefab;
            case BulletTypes.BulletType.Spreader:
                return spreaderBulletPrefab;
            case BulletTypes.BulletType.HomingMissile:
                return homingMissilePrefab;
            default:
                return normalBulletPrefab;
        }
    }
}
