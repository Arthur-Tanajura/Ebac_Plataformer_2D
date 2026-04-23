using Unity.VisualScripting;
using UnityEngine;

public class AudioPlayerHelper : MonoBehaviour
{
    public KeyCode KeyCode = KeyCode.P;
    public AudioSource audioSource;

    void Update()
    {
        if (Input.GetKey(KeyCode))
        {
            Play();
        }
    }

    public void Play()
    {

        audioSource.Play();
    }

}
