using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{

  //  [SerializeField] private int _score = default;
    [SerializeField] private TextMeshProUGUI _txtScore = default;
  //  [SerializeField] private TextMeshProUGUI _txtGameOver = default;
  //  [SerializeField] private TextMeshProUGUI _txtRestart = default;
  //  [SerializeField] private TextMeshProUGUI _txtQuit = default;


    [SerializeField] private GameObject _pausePanel = default;
    private bool _pauseOn = false;

    [SerializeField] private float _vitesseEnnemi = 6.0f;
    [SerializeField] private float _augVitesseParNiveau = 2.0f;
    [SerializeField] private int _pointageAugmentation = 500;

    private int _score = 0;
    private bool _estChanger = false;
    // Start is called before the first frame update

    private void Start()
    {
        _score = 0;
      //  _txtGameOver.gameObject.SetActive(false);
       
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
        /*  if (_txtRestart.gameObject.activeSelf && Input.GetKeyDown(KeyCode.R))
          {
              SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
          }
          else if (_txtRestart.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Escape))
          {
              SceneManager.LoadScene(0);
          }

          if ((Input.GetKeyDown(KeyCode.Escape) && !_txtRestart.gameObject.activeSelf) && !_pauseOn)
          {
              _pausePanel.SetActive(true);
              Time.timeScale = 0;
              _pauseOn = true;
          }
          else if ((Input.GetKeyDown(KeyCode.Escape) && !_txtRestart.gameObject.activeSelf) && _pauseOn)
          {
              _pausePanel.SetActive(false);
              Time.timeScale = 1;
              _pauseOn = false;
          }*/
    }
    public void AjouterScore(int points)
    {
        _score += points;
        UpdateScore();
    }

    private void UpdateScore()
    {
        _txtScore.text = "Score : " + _score.ToString();
    }


    private void GameOverSequence()
    {
        /*
        _txtGameOver.gameObject.SetActive(true);
        _txtRestart.gameObject.SetActive(true);
        _txtQuit.gameObject.SetActive(true);
        StartCoroutine(GameOverBlinkRoutine());*/
        PlayerPrefs.SetInt("pointage", _score);
        PlayerPrefs.Save();
        SceneManager.LoadScene(1);
    }

    /* IEnumerator GameOverBlinkRoutine()
     {
        while (true)
         {
             _txtGameOver.gameObject.SetActive(true);
             yield return new WaitForSeconds(0.7f);
             _txtGameOver.gameObject.SetActive(false);
             yield return new WaitForSeconds(0.7f);
         }
     }
    */
    public void ChargerDepart()
    {
        SceneManager.LoadScene(0);
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
}

