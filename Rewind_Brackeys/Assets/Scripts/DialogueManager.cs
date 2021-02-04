using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    
    public Text _text;
    public Text _textBackup;
    public Text _inst;
    public string[] _Random;
    public string[] _Story;
    public string[] _triggered;
    public float _deleteion = 2f;
    float _intsdelete = 5f;

    private void Start() {
        _text.text = " ";
        _inst.text = " ";
        _textBackup.text = " ";
    }

    public void Story(int index)
    {
        if(_text.text == " ")
        {
            _text.text = _Story[index];
            StartCoroutine(Delete(_deleteion,_text));
        }
        else
        {
            _textBackup.text = _Story[index];
            StartCoroutine(Delete(_deleteion,_textBackup));
        }
    }

    IEnumerator Delete(float delay,Text txt)
    {
        yield return new WaitForSeconds(delay);
        txt.text = " ";   
    }

    public void Triggered(int index)
    {
        _inst.text =_triggered[index];
        StartCoroutine(Delete(_intsdelete,_inst));
    }

    public void Random(int index)
    {
        if (_text.text == " ")
        {
            _text.text = _Random[index];
            StartCoroutine(Delete(_deleteion, _text));
        }
        else
        {
            _textBackup.text = _Random[index];
            StartCoroutine(Delete(_deleteion, _textBackup));
        }
    }   
}
