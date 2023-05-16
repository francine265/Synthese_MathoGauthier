using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _speed = 6f;
    [SerializeField] private int _points = 100;
    private Player _player;
    void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        MouvementsEnemy();
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
