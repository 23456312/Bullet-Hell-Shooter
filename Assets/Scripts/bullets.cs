using UnityEngine;

public class bullets : MonoBehaviour
{
    public float speed = 1f;
    public float bulletLife = 1f;
    public Vector3 startingHeartOffset; 

    private Vector3 spawnPoint;
    private float timer = 0f;

    void Start()
    {
        spawnPoint = transform.position;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= bulletLife)
        {
            DestroyBullet();
            return;
        }

        
        float distance = speed * timer; 
        transform.position = spawnPoint + (startingHeartOffset * distance);
    }

    void OnBecameInvisible()
    {
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if (BulletCounter.Instance != null)
            BulletCounter.Instance.RemoveBullet();
        Destroy(gameObject);
    }

    void OnEnable()
    {
        if (BulletCounter.Instance != null)
            BulletCounter.Instance.AddBullet();
    }
}