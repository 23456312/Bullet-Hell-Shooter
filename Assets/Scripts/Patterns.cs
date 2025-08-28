using UnityEngine;

public class Patterns : MonoBehaviour
{
    public Spawner spawner;
    private float elapsed = 0f;
    private bool isRunning = true;

    void Update()
    {
        if (!isRunning || spawner == null) return; 

        elapsed += Time.deltaTime;

        if (elapsed < 10f) 
        {
            spawner.pattern = SpawnerType.Star;
            spawner.speed = 10f;
            spawner.bulletLife = 9f; 
        }
        else if (elapsed < 20f) 
        {
            spawner.pattern = SpawnerType.Flower;
            spawner.speed = 10f;
            spawner.bulletLife = 9f;
        }
        else if (elapsed < 30f) 
        {
            spawner.pattern = SpawnerType.Heart;
            spawner.speed = 1f;
            spawner.bulletLife = 9f; 

        }
        else
        {
            isRunning = false;
        }
    }
}