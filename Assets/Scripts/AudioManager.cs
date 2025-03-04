using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Fuentes de audio")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("Clips de audio")]
    public AudioClip background;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }
}
