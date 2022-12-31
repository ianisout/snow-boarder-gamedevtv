using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float reloadDelay = 2f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip crashSFX;

    SurfaceEffector2D surfaceEffector2D;
    public bool hasCrashed = false;

    void Start()
    {
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground" && !hasCrashed)
        {
            Invoke("ReloadScene", reloadDelay);
            Invoke("Crash", 0.2f);

            FindObjectOfType<PlayerController>().DisableControls();
            hasCrashed = true;

            surfaceEffector2D.speed = 0;
            surfaceEffector2D.forceScale = 0;
            
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    void Crash()
    {
        crashEffect.Play();
    }
}
