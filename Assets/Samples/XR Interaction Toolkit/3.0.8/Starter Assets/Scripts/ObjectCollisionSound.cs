using UnityEngine;

public class ObjectCollisionSound : MonoBehaviour
{
    public AudioSource collideSound;

    private void OnCollisionEnter(Collision collision)
    {
        collideSound.Play();
    }
}
