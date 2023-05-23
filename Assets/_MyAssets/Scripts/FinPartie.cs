using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class FinPartie : MonoBehaviour
{
    [SerializeField] TMP_Text _txtPointage = default;

    [SerializeField] TMP_Text _txtMeilleur = default;
    [SerializeField] private GameObject _txtSaisie = default;


    // Start is called before the first frame update
    void Start()
    {

        _txtPointage.text = "Pointage:" + PlayerPrefs.GetInt("pointage");
        if (PlayerPrefs.HasKey("meilleur"))
        {
            if (PlayerPrefs.GetInt("pointage")> PlayerPrefs.GetInt("meilleur"))// 'il existe un pointage plus grand que le meilleur score remplace lempar le meilleur score
            {
                PlayerPrefs.GetInt("meilleur", PlayerPrefs.GetInt("pointage"));
            }
        }
        else
        {
            PlayerPrefs.GetInt("meilleur", PlayerPrefs.GetInt("pointage"));

        }
        PlayerPrefs.Save();
        _txtMeilleur.text = "Meilleur Pointage: " + PlayerPrefs.GetInt("meilleur");
    }

    // Update is called once per frame
    void Update()
    {
        // Permet de red�marrer la partie ou se d�placer au menu de d�part � la fin de la partie
        if (Input.GetKeyDown(KeyCode.R) )
        {
            SceneManager.LoadScene(1);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }

    }
}
