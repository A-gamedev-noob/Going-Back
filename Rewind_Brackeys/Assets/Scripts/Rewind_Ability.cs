 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewind_Ability : MonoBehaviour
{
    public bool _ispresent = true;
    GameObject[] _pastObjects;
    GameObject[] _presentObjects;
    public bool _canRewind = true;
    public bool _canImmune = true;
    public Camera _cam;
    public float _maxlength;
    int ly;
    public Material _dissolveMat;
    public float _test = 0.1f;

    private void Awake() 
    {
        _pastObjects = DetectObjectsInPast(9);
        _presentObjects = DetectObjectsInPresent(10);
    }
  
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && _canRewind)
        {
            Changetime();
        }
        if(Input.GetMouseButtonDown(0))
        {
         //   FindImmune(12, ly);
           // MakeImune();
        }
        if(Input.GetKeyDown(KeyCode.C))
        {
          //  Animate();
        }
        
    }


    GameObject[] DetectObjectsInPast(int ly)
    {
        GameObject[] GOar = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        List<GameObject> Objects = new List<GameObject>();
        for(int i=0;i<GOar.Length;i++)
        {
            if(GOar[i].layer == ly)
            {
                Objects.Add(GOar[i]);
            }
        }
        return Objects.ToArray();
    }
    GameObject[] DetectObjectsInPresent(int ly)
    {
        GameObject[] GOar = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        List<GameObject> Objects = new List<GameObject>();
        for (int i = 0; i < GOar.Length; i++)
        {
            if (GOar[i].layer == ly)
            {
                Objects.Add(GOar[i]);
            }
        }
       return Objects.ToArray();
    }

    void Changetime()
    {
        if (_ispresent)
        {
            PresentHide();
        }
            
        else
        {
            PastHide();
        }
    }

    private void PastHide()
    {
        for (int x = 0; x < _pastObjects.Length; x++)
        {
            if(_pastObjects[x].layer == 9)
            {
                MeshRenderer mesh = _pastObjects[x].GetComponent<MeshRenderer>();
                Collider col = _pastObjects[x].GetComponent<Collider>();
                Rigidbody rb = _pastObjects[x].GetComponent<Rigidbody>();
                if (mesh != null)
                {
                    mesh.enabled = false;
                    if (col != null)
                    {
                        col.enabled = false;
                    }
                    if (rb != null)
                    {
                        rb.useGravity = false;
                    }
                }
                else
                {
                    if (col != null)
                    {
                        col.enabled = false;
                    }
                }
            }
        }
        for (int x = 0; x < _presentObjects.Length; x++)
        {
            if(_presentObjects[x].layer == 10)
            {
                MeshRenderer mesh = _presentObjects[x].GetComponent<MeshRenderer>();
                Collider col = _presentObjects[x].GetComponent<Collider>();
                Rigidbody rb = _presentObjects[x].GetComponent<Rigidbody>();
                if (_presentObjects[x].GetComponent<MeshRenderer>() != null)
                {
                    mesh.enabled = true;
                    if (col != null)
                    {
                        col.enabled = true;
                    }
                    if (rb != null)
                    {
                        rb.useGravity = true;
                    }
                }
                else
                {
                    if (col != null)
                    {
                        col.enabled = true;
                    }
                }
            }
        }
        _ispresent = true;
    }

    private void PresentHide()
    {
        _ispresent = false;
        for (int x = 0; x < _presentObjects.Length; x++)
        {
            if(_presentObjects[x].layer == 10)
            {
                MeshRenderer mesh = _presentObjects[x].GetComponent<MeshRenderer>();
                Collider col = _presentObjects[x].GetComponent<Collider>();
                Rigidbody rb = _presentObjects[x].GetComponent<Rigidbody>();
                if (mesh != null)
                {
                    mesh.enabled = false;
                    if (col != null)
                    {
                        col.enabled = false;
                    }
                    if (rb != null)
                    {
                        rb.useGravity = false;
                    }
                }
                else
                {
                    if (col != null)
                    {
                        col.enabled = false;
                    }
                }
            }
        }
        for (int x = 0; x < _pastObjects.Length; x++)
        {
            if(_pastObjects[x].layer == 9)
            {
                MeshRenderer mesh = _pastObjects[x].GetComponent<MeshRenderer>();
                Collider col = _pastObjects[x].GetComponent<Collider>();
                Rigidbody rb = _pastObjects[x].GetComponent<Rigidbody>();
                if (mesh != null)
                {
                    mesh.enabled = true;
                    if (col != null)
                    {
                        col.enabled = true;
                    }
                    if (rb != null)
                    {
                        rb.useGravity = true;
                    }

                }
                else
                {
                    if (col != null)
                    {
                        col.enabled = true;
                    }
                }
            }
        }
    }

    void MakeImune()
    {
        Ray ray;
        RaycastHit hit;
        var mousepos = Input.mousePosition;
        ray = _cam.ScreenPointToRay(mousepos);

        if(Physics.Raycast(ray.origin, ray.direction, out hit, _maxlength))
        {
            ly = hit.collider.gameObject.layer;
            float dis = Vector3.Distance(_cam.transform.position, hit.point);
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.blue);
            if (hit.collider.gameObject.layer == 9 || hit.collider.gameObject.layer == 10 || hit.collider.gameObject.layer == 11)
            {
                hit.collider.gameObject.layer = LayerMask.NameToLayer("Immune");
                if(hit.transform.childCount != 0)
                {
                    GetChildren(hit.collider.gameObject);
                }
            }
            else
            {

            }
        }

    }

    void GetChildren(GameObject obj)
    {
        for(int x=0;x<obj.transform.childCount;x++)
        {
            obj.transform.GetChild(x).gameObject.layer = LayerMask.NameToLayer("Immune");
        }
    }
    void FindImmune(int ly,int OGL)
    {
        GameObject[] GOar = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        for (int i = 0; i < GOar.Length; i++)
        {
            if (GOar[i].layer == ly)
            {
                GOar[i].layer = OGL;
            }
        }
    }

    void Animate()
    {
        float value = Mathf.Lerp(-0.7f,0.7f,_test);
        _dissolveMat.SetFloat("Vector1_F418E86F",value);
    }

}
