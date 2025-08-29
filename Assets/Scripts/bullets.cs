using UnityEngine;

public class bullets : MonoBehaviour
{
    public float speed = 1f;
    public Vector3 startingHeartOffset;

    private Vector3 spawnPoint;
    private float timer = 0f;
    private bool isDestroyed = false;
    private Camera mainCamera;

    void Start()
    {
        spawnPoint = transform.position;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (isDestroyed) return;

        timer += Time.deltaTime;

        // Movement logic
        float distance = speed * timer;
        transform.position = spawnPoint + (startingHeartOffset * distance);

        // Manual screen boundary check
        CheckIfOffScreen();
    }

    void CheckIfOffScreen()
    {
        if (mainCamera == null) return;

        Vector3 viewportPoint = mainCamera.WorldToViewportPoint(transform.position);

        // Check if bullet is outside screen boundaries with some margin
        if (viewportPoint.x < -0.5f || viewportPoint.x > 1.5f ||
            viewportPoint.y < -0.5f || viewportPoint.y > 1.5f)
        {
            DestroyBullet();
        }
    }

    void OnBecameInvisible()
    {
        if (!isDestroyed)
        {
            DestroyBullet();
        }
    }

    void DestroyBullet()
    {
        if (isDestroyed) return;

        isDestroyed = true;

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