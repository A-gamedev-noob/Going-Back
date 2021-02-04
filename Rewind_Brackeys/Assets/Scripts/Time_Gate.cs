using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Gate : MonoBehaviour
{
  
    enum Role {Loader,Past,Present}
    [SerializeField] Role _currentRole;
    public GameManagr GM;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            if(_currentRole == Role.Loader)
            {
                LoadNextLevel();
            }
        }
    }

    void LoadNextLevel()
    {
        GM.LoadNextLevel();
    }

}
