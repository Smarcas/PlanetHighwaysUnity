using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Fuentes de audio")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Clips de audio")]
    public AudioClip background;
    public AudioClip buttonClicked;
    public AudioClip coinSound;
    public AudioClip carHit;
    public AudioClip deathSound;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
