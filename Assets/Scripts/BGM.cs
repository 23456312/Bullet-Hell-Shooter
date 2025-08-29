using UnityEngine;

public class BGM : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip bgm;
    void Start()
    {
        musicSource.clip = bgm;
        musicSource.Play();
    }

    
}
