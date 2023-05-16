using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar2 : MonoBehaviour
{

    static Image Barre;
   static TextMeshProUGUI txt;
    public float max { get; set; }
    private float Valeur;
   
    // Start is called before the first frame update
    void Start()
    {
        Barre = GetComponent<Image>();
        txt = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public float valeur
    {
        get { return Valeur; }
        set
        {
            Valeur = Mathf.Clamp(value, 0, max);
            if (Barre != null)
            {
                Barre.fillAmount = (1 / max) * Valeur;
                txt.text = Barre.fillAmount * 100 + "%";
            }

        }
    }
}
