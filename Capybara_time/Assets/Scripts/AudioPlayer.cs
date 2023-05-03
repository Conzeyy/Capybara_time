using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
 * Created by Tyler Costa 19075541
 */

public class AudioPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip _audioClip;
    private AudioSource _audioSource;

    private bool playmusic = false;
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



    //Plays main menu music
    public void playMainMenuMusic()
    {
        if (playmusic==false)
        {
            playmusic = true;
            Debug.Log("Play music is set to true!");
            _audioSource.Play();

        }
        else if(playmusic == true)
        {
            playmusic = false;
            Debug.Log("Play music is false");
            _audioSource.Pause();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
