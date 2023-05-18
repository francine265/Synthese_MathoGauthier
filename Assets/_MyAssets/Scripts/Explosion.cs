using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
  

{
    [SerializeField] private AudioClip _sonExplosion = default;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource.PlayClipAtPoint(_sonExplosion, Camera.main.transform.position, 0.4f);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * 2f);
        
    }
}
