using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private GameObject _laserPrefab = default;
      [SerializeField] private GameObject _triplelaserPrefab = default;
    [SerializeField] private float _fireRate = 0.5f; // cadence de tire
                                                     //   [SerializeField] private GameObject _explosionPrefab = default;
                                                     //    [SerializeField] private AudioClip _laserSound = default;*/

    private float _canFire = -1f;// le temps entre les tires
     private bool _isTripleActive = false;
                                   private float _cadenceInitiale;
                                 //  private Animator _anim;

      private GameObject _shield;

    //[SerializeField] private int _viesJoueurs = 5;
    HealthBar2 BarreDevie = new HealthBar2();

    void Start()
    {
   


        BarreDevie.max = 100;
        BarreDevie.valeur = 100;
        _cadenceInitiale = _fireRate;
          _shield = transform.GetChild(4).gameObject;
        //   _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        MouvementsJoueur();
        Fire();
    }

    private void Fire()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > _canFire)
        {
            _canFire = Time.time + _fireRate;
            //  AudioSource.PlayClipAtPoint(_laserSound, Camera.main.transform.position, 0.3f);
            if (!_isTripleActive)
            {
                Instantiate(_laserPrefab, (transform.position + new Vector3(0f, 1.15f, 0f)), Quaternion.identity);
            }
             else
            {
                    Instantiate(_triplelaserPrefab, (transform.position + new Vector3(0f, 3.5f, 0f)), Quaternion.identity);
            }

        }
    }

    private void MouvementsJoueur()
    {
        float posHorizontal = Input.GetAxis("Horizontal");
        float posVertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(posHorizontal, posVertical, 0);
        transform.Translate(direction * Time.deltaTime * _speed);

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -4.1f, 0.5f), 0f);

        if (transform.position.x >= 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0f);
        }
        else if (transform.position.x <= -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0f);
        }

    }
    public void Damage()
    {
         if (!_shield.activeSelf)// si j'ai pas de bouclié on enleve une vie et change l'image
        {
            BarreDevie.valeur -= 10;
         
           // _viesJoueurs--;
             //  UIManager uIManager = FindObjectOfType<UIManager>();
            //  uIManager.ChangeLivesDisplayImage(_viesJoueurs);
        

            }
            else
            {
                _shield.SetActive(false);
            }
          
            if (BarreDevie.valeur == 0)
            {
                SpawnManager spawnManager = FindObjectOfType<SpawnManager>();
                //même chose de facon différente
                //SpawnManager spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
                spawnManager.FinPartie();
                //    Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
        
         public void PowerTripleShot()
         {
             _isTripleActive = true;
             StartCoroutine(Triple());

         }
         IEnumerator Triple()
         {
             yield return new WaitForSeconds(5f);
             _isTripleActive = false;
         }
        
        public void SpeedPowerUp()
        {
            float nouvellecadence = _cadenceInitiale - 0.4f;
            if (nouvellecadence <= 0)
            {
                nouvellecadence = 0.01f;
            }
            _fireRate = nouvellecadence;
            StartCoroutine(Cadence());
        }
        IEnumerator Cadence()
        {
            yield return new WaitForSeconds(5f);
            _fireRate = _cadenceInitiale;
        }
        public void ShieldPowerUp()
        {
            _shield.SetActive(true);
        }
        
    }

