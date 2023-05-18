using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnnemy : MonoBehaviour
{
    // Start is called before the first frame update
    private UIManager _uiManager;
    private float _vitesseLaserEnnemi;
    [SerializeField] private string _nom = default;
    public void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {

        _vitesseLaserEnnemi = _uiManager.getVitesseEnnemi() + 6.0f;
        transform.Translate(Vector3.down * Time.deltaTime * _vitesseLaserEnnemi);
        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && _nom != "Player")
        {
            Player player = other.GetComponent<Player>();
            player.Damage();
           // Instantiate(_miniExplosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
