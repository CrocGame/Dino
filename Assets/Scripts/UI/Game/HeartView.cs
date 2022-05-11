using System.Collections.Generic;
using UnityEngine;

public class HeartView : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private GameObject _template;
    [SerializeField] private Dino _dino;

    private List<GameObject> _heartsList = new List<GameObject>();

    private void OnEnable()
    {
        _dino.onTakeDamage += OnTakeDamage;
        _dino.onHealth += OnHealth;
    }

    private void OnDisable()
    {
        _dino.onTakeDamage -= OnTakeDamage;
        _dino.onHealth -= OnHealth;
    }

    private void Start()
    {
        for (int i = 0; i < _dino.MaxHealths; i++)
        {
            GameObject heart= Instantiate(_template, _container);
            if(i>=_dino.Healths)
                heart.SetActive(false);
            _heartsList.Add(heart);
        }
    }

    private void OnTakeDamage()
    {
        GameObject heart = _heartsList[_dino.Healths];
        heart.SetActive(false);
    }
    private void OnHealth()
    {
        GameObject heart = _heartsList[_dino.Healths-1];
        heart.SetActive(true);
    } 

}
