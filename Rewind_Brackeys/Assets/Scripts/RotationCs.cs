using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationCs : MonoBehaviour
{

    [SerializeField] Camera _cam;
    [SerializeField] float _maxlength;
    Vector3 _direction;
    Quaternion _rotation;
    Vector3 _pos;


    void Update()
    {
        if(_cam!=null)
        {
            Targeting();
        }
        else{
            print("no camerA");
        }
    }

    void RotatetoMouse(GameObject obj, Vector3 destination)
    {
        _direction = destination - obj.transform.position;
        _rotation = Quaternion.LookRotation(_direction);
        obj.transform.localRotation = Quaternion.Lerp(obj.transform.rotation, _rotation, 1);
    } 

    void Targeting()
    {
        RaycastHit hit;
        var mousepos = Input.mousePosition;
        Ray ray = _cam.ScreenPointToRay(mousepos);
        if(Physics.Raycast(ray.origin,ray.direction,out hit,_maxlength))
        {
            RotatetoMouse(gameObject,hit.point);
            Debug.DrawRay(ray.origin,ray.direction * 100,Color.red);
        }
        else
        {
            var pos =  ray.GetPoint(_maxlength);
            RotatetoMouse(gameObject,pos);
        }
    }

    public Quaternion Rotationdata()
    {
        return _rotation;
    }

    void look()
    {
        var mpos = Input.mousePosition;
        transform.LookAt(mpos);
    }

}
