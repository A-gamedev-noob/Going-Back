using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    enum Role {Story,Random,Triggered}
    [SerializeField] Role _currentRole;
    public DialogueManager DialogueManager;
    public int _index;

    private void OnTriggerEnter(Collider other) 
    {
        if(_currentRole == Role.Story && other.CompareTag("Player"))
        {
            DialogueManager.Story(_index);
        }
        if (_currentRole == Role.Triggered && other.CompareTag("Player"))
        {
            DialogueManager.Triggered(_index);
        }
        if (_currentRole == Role.Random && other.CompareTag("Player"))
        {
            DialogueManager.Random(_index);
        }
        Remove();
    }

    void Remove()
    {
        gameObject.SetActive(false);
    }

}
