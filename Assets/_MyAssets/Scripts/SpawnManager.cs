using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject _prefabEnemy = default;
  //  [SerializeField] private GameObject _prefabEnemy2 = default;
    [SerializeField] private GameObject _prefabEnemy3 = default;
    // [SerializeField] private GameObject[] _prefabEnemy = default;
    [SerializeField] private GameObject[] _listePUPrefabs = default;
    [SerializeField] private GameObject _enemyContainer = default;
    private bool _stopSpawn = false;
    void Start()
    {
        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPURoutine());
    }
    IEnumerator SpawnPURoutine()
    {
        yield return new WaitForSeconds(3f);
        while (!_stopSpawn)
        {
            Vector3 posSpawn = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
            int randomPU = Random.Range(0, _listePUPrefabs.Length);
            GameObject newPu = Instantiate(_listePUPrefabs[randomPU], posSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(8, 15));
        }
    }
    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(3f);
        while (!_stopSpawn)
        {
            Vector3 posSpawn = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
            Vector3 posSpawn2 = new Vector3(Random.Range(-8.5f, 8.5f), 7f, 0f);
            GameObject newEnemy = Instantiate(_prefabEnemy, posSpawn, Quaternion.identity);
           // GameObject newEnemy2 = Instantiate(_prefabEnemy2, posSpawn2, Quaternion.identity);
            GameObject newEnemy3 = Instantiate(_prefabEnemy3, posSpawn2, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(6f);
        }

    }
    public void FinPartie()
    {
        _stopSpawn = true;
         SceneManager.LoadScene(2);
    }
    public void mortJoueur()
    {
        _stopSpawn = true;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
