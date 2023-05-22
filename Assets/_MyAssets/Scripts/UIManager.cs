using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _txtScore = default;
    [SerializeField] private GameObject _panneauInfo = default;
    [SerializeField] private GameObject _panneauReglages = default;
    [SerializeField] private TextMeshProUGUI _txtTemps = default;
    [SerializeField] private GameObject _pausePanel = default;
    [SerializeField] private float _vitesseEnnemi = 6.0f;
    [SerializeField] private float _augVitesseParNiveau = 2.0f;
    [SerializeField] private int _pointageAugmentation = 500;
    private bool _pauseOn = false;
    private int _score = 0;
    private bool _estChanger = false;
    private bool _keyDown =false;
    float currentTime;
    private bool infoActif = false;
    private bool reglagesActif = false;


    private void Start()
    {
        _score = 0;
        UpdateScore();
    }
    public int getScore()
    {
        return _score;
    }
    private void AugmentVitesseEnnemi()
    {
        _vitesseEnnemi += _augVitesseParNiveau;
    }
    private void Update()
    {
        if (_score % _pointageAugmentation == 0 && _score != 0 && _estChanger == false)
        {
            AugmentVitesseEnnemi();
            _estChanger = true;
        }
        else if (_score % _pointageAugmentation != 0)
        {
            _estChanger = false;
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)|| Input.GetKeyDown(KeyCode.Space))
        {
            _keyDown = true;
        }
        if (_keyDown == true &&  SceneManager.GetActiveScene().name == "SampleScene" )
        {

            currentTime += Time.deltaTime;
            _txtTemps.text = currentTime.ToString("f2");

        }

          if (Input.GetKeyDown(KeyCode.Escape)  && !_pauseOn)
          {
              _pausePanel.SetActive(true);
              Time.timeScale = 0;
              _pauseOn = true;
          }
          else if ((Input.GetKeyDown(KeyCode.Escape) ) && _pauseOn)
          {
              _pausePanel.SetActive(false);
              Time.timeScale = 1;
              _pauseOn = false;
          }
          
    }
    private void UpdateScore()
    {
        _txtScore.text = "Score : " + _score.ToString();
    }

    public void AjouterScore(int points) {
        _score += points;
        UpdateScore();
    }

    private void GameOverSequence()
    {
        PlayerPrefs.SetInt("pointage", _score);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }


    public void ChargerDepart()
    {
        SceneManager.LoadScene(0);
    }
    public void ChargerJeu()
    {
        SceneManager.LoadScene(1);
    }
        public void ChargerInformations()
    {
      if( !_panneauInfo.activeSelf )
        {
        _panneauInfo.SetActive(true);
        }
        else
        {
        _panneauInfo.SetActive(false);
        }
        
    }
    public void ChargerReglages()
    {
        

         if( !_panneauReglages.activeSelf )
        {
        _panneauReglages.SetActive(true);
        }
        else
        {
        _panneauReglages.SetActive(false);
        }
    }
    public void FermerReglages()
    {
        _panneauReglages.SetActive(false);
    }
    IEnumerator FinPartie()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
        _pauseOn = false;
    }
    public float getVitesseEnnemi()
    {
        return _vitesseEnnemi;
    }

    public void Quitter()
    {
        Application.Quit();
    }

    public void ChangerScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index + 1);
    }
    
}

