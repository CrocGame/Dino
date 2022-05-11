using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] private GameObject _meteor;
    [SerializeField] private float _timeSpawn;
    [SerializeField] private int _maxCountSpawn;
    private float _elepsedTime = 0;

    private void Start()
    {
        Initialize(_meteor);
    }
    private void Update()
    {
        _elepsedTime += Time.deltaTime;

        if (_elepsedTime >= _timeSpawn)
        {
            int count = Random.Range(1, _maxCountSpawn + 1);
            int[] test = RandomSpawnPoint(count);
            for (int i = 0; i < count; i++)
            {
                SpawnObject(test[i]);
            }
        }
    }

    private void SpawnObject(int index)
    {
        if (TryGetObject(out GameObject meteor))
        {
            _elepsedTime = 0;
            Vector3 spawnPoint = _spawnPoints[index].position;
            meteor.transform.position = spawnPoint;
            meteor.SetActive(true);

        }
    }

    private int[] RandomSpawnPoint(int count)
    {
        int[] numbers=new int[count];
        for (int i = 0; i < count; i++)
        {
            int number=0;
            numbers[i] = -1;
            bool flag = true;
            while (flag)
            {
                number = Random.Range(0, _spawnPoints.Count);
                foreach (var item in numbers)
                {
                    if (item == number) 
                    {
                        flag = true;
                        break; 
                    }
                    else
                    {
                        flag = false;
                    }
                }
            }
            numbers[i] = number;
        }
        return numbers;
    }


}
