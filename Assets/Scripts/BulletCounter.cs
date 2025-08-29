using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class BulletCounter : MonoBehaviour
{
    public static BulletCounter Instance;

    [SerializeField] private TMP_Text bulletCountText;
    private int bulletCount = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateBulletCountText();
    }

    public void AddBullet()
    {
        bulletCount++;
        UpdateBulletCountText();
    }

    public void RemoveBullet()
    {
        bulletCount--;
        UpdateBulletCountText();
    }

    void UpdateBulletCountText()
    {
        if (bulletCountText != null)
            bulletCountText.text = "Balas Activas: " + bulletCount;
    }

    public int GetBulletCount()
    {
        return bulletCount;
    }
}
