using UnityEngine;

public enum SpawnerType { Star, Flower, Heart }

public class Spawner : MonoBehaviour
{
    public SpawnerType pattern;
    public GameObject Bullets;
    public float bulletLife = 1f;
    public float speed = 1f;
    public float heartSpeedMultiplier = 0.5f; 

    private float firingRate = 2f;
    public int star = 5;
    public int flower = 20;
    private float angle2 = 0f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= firingRate)
        {
            FirePattern();
            timer = 0;
        }
    }

    void FirePattern()
    {
        switch (pattern)
        {
            case SpawnerType.Star:
                StarShape();
                break;
            case SpawnerType.Flower:
                Flowershape();
                break;
            case SpawnerType.Heart:
                Heartshape();
                break;
        }
    }

    void StarShape()
    {
        int points = 50; 
        float outerRadius = 1.5f;
        float innerRadius = 0.6f;
        float sizeScaler = 1.0f;

        for (int i = 0; i < points; i++)
        {
            float t = Mathf.PI * 2 * i / points;


            float radius = Mathf.Lerp(innerRadius, outerRadius, Mathf.Abs(Mathf.Cos(2.5f * t)));

            float x = Mathf.Cos(t) * radius;
            float y = Mathf.Sin(t) * radius;

            Vector3 starOffset = new Vector3(x, y, 0) * sizeScaler;
            Vector3 dir = starOffset.normalized;

            SpawnBullet(dir, starOffset, speed);
        }
    }


    void Flowershape()
    {
        int numberOfPetals = flower;
        float angleStep = 360f / numberOfPetals;
        float baseRadius = 1.5f;
        float waveAmplitude = 1.0f;
        int pointsPerPetal = 5; 

        for (int i = 0; i < numberOfPetals; i++)
        {
            float petalAngle = i * angleStep + angle2;

            for (int j = 0; j < pointsPerPetal; j++)
            {
                float t = j / (float)(pointsPerPetal - 1); 

                float petalLength = baseRadius + waveAmplitude * Mathf.Sin(t * Mathf.PI);

                float radianAngle = petalAngle * Mathf.Deg2Rad;
                float x = Mathf.Cos(radianAngle) * petalLength * t; 
                float y = Mathf.Sin(radianAngle) * petalLength * t;

                Vector3 petalOffset = new Vector3(x, y, 0f);
                Vector3 dir = petalOffset.normalized;

                SpawnBullet(dir, petalOffset, speed);
            }
        }


        angle2 += 10f;
    }



    void Heartshape()
    {
        int points = 100;
        float sizeScaler = 1.0f;

        for (int i = 0; i < points; i++)
        {
            float t = Mathf.PI * 2 * i / points;
            float x = 16 * Mathf.Pow(Mathf.Sin(t), 3);
            float y = 13 * Mathf.Cos(t) - 5 * Mathf.Cos(2 * t) - 2 * Mathf.Cos(3 * t) - Mathf.Cos(4 * t);
            Vector3 heartOffset = new Vector3(x, y, 0) * sizeScaler;
            Vector3 dir = heartOffset.normalized;
            SpawnBullet(dir, heartOffset, speed * heartSpeedMultiplier);
        }
    }

    void SpawnBullet(Vector3 direction, Vector3 shapeOffset, float bulletSpeed)
    {
        GameObject bullet = Instantiate(Bullets, transform.position, Quaternion.identity);
        bullets b = bullet.GetComponent<bullets>();
        if (b != null)
        {
            b.speed = bulletSpeed; 
            b.bulletLife = bulletLife;
            b.startingHeartOffset = shapeOffset;
            bullet.transform.right = direction;
        }
    }

}