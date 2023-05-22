using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gestionSon : MonoBehaviour
{
    [SerializeField] private GameObject _soundOn = default;
    [SerializeField] private GameObject _soundOff = default;
[SerializeField] private AudioSource _audioSource;
    //private AudioSource _audioSource;

    private void Start()
    {
        //_audioSource = FindObjectOfType<MusiqueFond>().GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("Muted") == 0)
        {
            _audioSource.Stop();
            _soundOn.SetActive(false);
            _soundOff.SetActive(true);
            
        }
    }

    public void MusiqueOnOff()
    {
        if (PlayerPrefs.GetInt("Muted", 0) == 0)
        {
            _audioSource.Play();
            PlayerPrefs.SetInt("Muted", 1);
            PlayerPrefs.Save();
            _soundOn.SetActive(true);
            _soundOff.SetActive(false);
        }
        else
        {
            _audioSource.Pause();
            PlayerPrefs.SetInt("Muted", 0);
            PlayerPrefs.Save();
            _soundOn.SetActive(false);
            _soundOff.SetActive(true);
        }
    }
}
