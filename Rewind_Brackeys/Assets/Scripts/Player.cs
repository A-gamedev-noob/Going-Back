using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float _speed = 5f;
    public float _jump = 20f;
    Vector3 direction;
    public Transform _GroundCheck;
    public bool _isGrounded;
    public float _radius = 0.1f;
    public LayerMask _Layers;
    Collider _playerCol;
    public GameManagr _gm;
    bool _ispaused = false;
    public GameObject _pauseVolume;
    bool _canJump = true;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _playerCol = GetComponent<Collider>();
        _pauseVolume.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if(transform.position.y <-8)
        {
            rb.freezeRotation = false;
            rb.AddTorque(new Vector3(0,-4f,-10f)* Time.deltaTime);
            Invoke("Died",2f);
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }

    }

    void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        direction = new Vector3(x,0,y);
        _isGrounded = Physics.CheckSphere(_GroundCheck.position,_radius,_Layers);
        if(Input.GetKeyDown(KeyCode.Space) &&  _isGrounded && _canJump)
        {
            _canJump = false;
            rb.AddForce(new Vector3(0,_jump,0),ForceMode.Impulse);
            StartCoroutine(CanJump());
        }      
    }

    private void FixedUpdate() 
    {
        rb.MovePosition(transform.position + (direction * _speed * Time.fixedDeltaTime));    
    }

    void Died()
    {
        _gm.Restart();
    }

    void PauseGame()
    {
        if(!_ispaused)
        {
            Time.timeScale = 0;
            _pauseVolume.SetActive(true);
            _ispaused = true;
        }
        else
        {
           Resume();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        _ispaused = false;
        _pauseVolume.SetActive(false);
    }

    IEnumerator CanJump()
    {
        yield return new WaitForSeconds(0.6f);
        _canJump = true;
    }

}
