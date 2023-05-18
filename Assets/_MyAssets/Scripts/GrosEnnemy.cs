using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrosEnnemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _speed = 6f;
    [SerializeField] private GameObject _enemyLaserPrefab = default;
    [SerializeField] private int _points = 100;
    private Player _player;
    private UIManager _uiManager;
    private float _fireRate;
    private float _canFire;
    void Start()
    {
        _player = FindObjectOfType<Player>();
        _uiManager = FindObjectOfType<UIManager>().GetComponent<UIManager>();
        _canFire = Random.Range(0.5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        MouvementsEnemy();
        TirEnnemi();
    }
    private void TirEnnemi()
    {
        if (_uiManager.getScore() >700)
        {
            if (Time.time > _canFire)
            {
                _fireRate = Random.Range(1f, 3f);
                _canFire = Time.time + _fireRate;
                Instantiate(_enemyLaserPrefab, transform.position + new Vector3(0f, -0.9f, 0f), Quaternion.identity);
            }
        }
    }
    private void MouvementsEnemy()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);
        if (transform.position.y < -6f)
        {
            float randomX = Random.Range(-8.5f, 8.5f);

            transform.position = new Vector3(randomX, 6f, 0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            UIManager uIManager = FindObjectOfType<UIManager>();
            uIManager.AjouterScore(_points);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else if (collision.tag == "Player")
        {
            _player.Damage();
            Destroy(gameObject);
        }
    }
}
