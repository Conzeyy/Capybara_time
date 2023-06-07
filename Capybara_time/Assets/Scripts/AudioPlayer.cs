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
    [SerializeField]
    private AudioClip _secondaudioClip;
    [SerializeField]
    private AudioClip _enemyaudioClip;

    private AudioSource _audioSource;

    private bool playmusic = false;
    private bool isCoolingDown = false;
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

    public void enemyWarning(bool canPlay)
    {
        if (isCoolingDown == false && canPlay == true)
        {
            StartCoroutine(AudioCoolDownLoop(_enemyaudioClip));

        } else
        {
            StopCoroutine(AudioCoolDownLoop(_enemyaudioClip));

        }

    }

    public void foodTrayCollected()
    {

        if (isCoolingDown == false)
        {
            StartCoroutine(AudioCoolDownLoop(_secondaudioClip));

        }
    }

    public void keyCollected()
    {
        if (isCoolingDown == false)
        {
            StartCoroutine(AudioCoolDownLoop(_audioClip));

        }
    }

    IEnumerator AudioCoolDownLoop(AudioClip audio)
    {
        isCoolingDown = true;
        //_audioSource.Play(); 
        _audioSource.clip = audio;
        _audioSource.Play();
        yield return new WaitForSeconds(0.3f);

        isCoolingDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
