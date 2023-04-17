using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioClip _audioClip;
    private AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        if (_audioSource == null)
        {
            Debug.LogError("Audio Source is null!");
        }
        else
        {
            _audioSource.clip = _audioClip;
        }
    }

    // Update is called once per frame
    void Update()
    {
     //   PlayAudio();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayAudio()
    {
        
        _audioSource.Play();
    }
}
