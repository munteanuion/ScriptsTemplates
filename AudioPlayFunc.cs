using UnityEngine;

public class AudioPlayFunc : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private KeyCode _buttonulPornesteSunetul;

    private void Update()
    {
        if (Input.GetKeyDown(_buttonulPornesteSunetul))
        {
            PlaySound();
        }
    }

    public void PlaySound()
    {
        if (GameManager.Instance._canPlaySoundSetting)
        {
            audioSource.clip = audioClip;
            audioSource.Play();
        }
    }
    public void PlaySound(float invokeTime)
    {
        Invoke("PlaySound", invokeTime);
    }
}
