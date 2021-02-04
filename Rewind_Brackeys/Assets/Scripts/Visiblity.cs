using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visiblity : MonoBehaviour
{
    MeshRenderer _mesh;
    void Start()
    {
        _mesh = GetComponent<MeshRenderer>();
        Collider coll = transform.GetComponent<Collider>();
        if(gameObject.layer == 9)
        {
            if(_mesh != null)
            {
                _mesh.enabled = false;
                if(coll != null)
                {
                    coll.enabled = false;
                }
                if(transform.GetComponent<Rigidbody>() != null)
                {
                    transform.GetComponent<Rigidbody>().useGravity = false;
                }   
            }
            else
            {
                Collider col = transform.GetComponent<Collider>();
                if(col != null)
                {
                    col.enabled = false;
                }
                if(transform.GetComponent<Rigidbody>() != null)
                {
                    transform.GetComponent<Rigidbody>().useGravity = false;
                }
                
            }
            for (int x = 0; x < transform.childCount; x++)
            {
                if(transform.GetChild(x).GetComponent<MeshRenderer>()!=null)
                {
                    transform.GetChild(x).GetComponent<MeshRenderer>().enabled = false;
                }
                StartCoroutine(DisablePhysics(x));
            }
            if (transform.childCount != 0)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Collider chcol = transform.GetChild(i).GetComponent<Collider>();
                    MeshRenderer chomesh = transform.GetChild(i).GetComponent<MeshRenderer>();
                    Rigidbody choRB = transform.GetChild(i).GetComponent<Rigidbody>();
                    if (chcol != null)
                    {
                        chcol.enabled = false;
                    }
                    if (chomesh != null)
                    {
                        chomesh.enabled = false;
                    }
                    if (choRB != null)
                    {
                        choRB.useGravity = false;
                    }
                }
            }
        }
    }

    IEnumerator DisablePhysics(int index)
    {
        yield return new WaitForSeconds(2f);
        if(transform.GetChild(index).GetComponent<Rigidbody>() != null)
        {
            transform.GetChild(index).GetComponent<Rigidbody>().useGravity = false;
        }    
        if(transform.GetChild(index).GetComponent<Collider>() != null)
        {
            transform.GetChild(index).GetComponent<Collider>().enabled = false;
        }
    }
}
