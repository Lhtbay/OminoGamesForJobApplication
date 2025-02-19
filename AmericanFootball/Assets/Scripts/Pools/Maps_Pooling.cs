﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maps_Pooling : MonoBehaviour
{
    [Header ("Maps Settings")]
    [SerializeField] private GameObject _mapObject;
    [SerializeField] private GameObject _mapWinObject;
    [SerializeField] private int _mapMaxCount;

    private int _lastListCount= 0;

    public List<GameObject> _mapsList;

    private Game_Manager _gameManager;

    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Game_Manager>();

        for (int i = 0; i < _gameManager.Map_Count; i++)
        {           
            if (_mapsList.Count == 0)
            {               
                _mapsList = new List<GameObject>();
                GameObject newMap = Instantiate(_mapObject, transform.position, Quaternion.identity);

                newMap.transform.parent = transform;

                _mapsList.Add(newMap);                             
            }
            else
            {
                GameObject newMap = Instantiate(_mapObject, 
                    _mapsList[_lastListCount].transform.position+new Vector3 (0,0,+10), 
                    Quaternion.identity);

                newMap.transform.parent = transform;
             
                _mapsList.Add(newMap);
                _lastListCount++;
          
            }
        }
        GameObject winnerMap = Instantiate(_mapWinObject,
                    _mapsList[_lastListCount].transform.position + new Vector3(0, 0, +10.2f),
                    Quaternion.identity);

        winnerMap.transform.parent = transform;

        _mapsList.Add(winnerMap);
        _lastListCount++;
    }

}
