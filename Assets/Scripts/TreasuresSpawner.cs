using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasuresSpawner : MonoBehaviour
{
    [SerializeField] private int _frequency;
    [SerializeField] private Treasure _template;

    private Transform[] _spawnPoints;
    private float _runningTime;

    void Start()
    {
        _spawnPoints = GetComponentsInChildren<Transform>();
        StartCoroutine(SpawnTreasure(_frequency));    
    }

    private IEnumerator SpawnTreasure(int frequency)
    {
        while(frequency > 0)
        {            
            var waitingTime = new WaitForSeconds(frequency);

            Transform currentSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];

            if (currentSpawnPoint.childCount == 0)
            {
                Instantiate(_template, currentSpawnPoint);
            }

            yield return waitingTime;
        }  
    }
}
