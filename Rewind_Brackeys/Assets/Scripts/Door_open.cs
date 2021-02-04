using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_open : MonoBehaviour
{
    Animator _anim;
    public float _delay = 3f;
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) 
    {
        _anim.SetTrigger("Activated");
        StartCoroutine(CloseTimer());
    }

    IEnumerator CloseTimer()
    {
        yield return new WaitForSeconds (_delay);
        _anim.SetTrigger("Activated");
    }

}
