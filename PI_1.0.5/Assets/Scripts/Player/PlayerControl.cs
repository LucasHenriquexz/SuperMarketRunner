using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Range(-2, 2)] public float value;
    private CharacterController _controller;

    [SerializeField]
    private float _speed = 10.0f;
    [SerializeField]
    private float _jumpHeight = 10.0f;
    [SerializeField]
    private float _gravity = 1.0f;
    private float _yVelocity = 0.0f;


    void Start()
    {
       
       _controller = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        //Direção:
        Vector3 direction = new Vector3(0, 0, 1);
        //Velocidade:
        Vector3 velocity = direction * _speed;
        
        //Pulo:
        if (_controller.isGrounded == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                _yVelocity = _jumpHeight;
        }
        else
            _yVelocity -= _gravity;

        velocity.y = _yVelocity;

        //Mover:
        _controller.Move(velocity * Time.deltaTime);

        //Mudar posição:
        transform.position = new Vector3(value, transform.position.y, transform.position.z);

       if (Input.GetButtonDown("Right"))
        {
            if (value == 3)
                return;
            value += 3;
        }

        if (Input.GetButtonDown("Left"))
        {
            if (value == -3)
                return;
            value -= 3;
        }           
    }
}
