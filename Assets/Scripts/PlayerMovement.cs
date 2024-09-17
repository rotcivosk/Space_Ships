using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] float playerSpeed = 5f;


    [SerializeField] private float minX = -5f; // Limite mínimo no eixo X
    [SerializeField] private float maxX = 5f;  // Limite máximo no eixo X
  
    private Vector3 moveDirection; // Direção do movimento

    void Start()
    {
        
    }

    void Update()
    {
        HandleInput();
        MovePlayer();
    }

    // Método responsável por capturar as entradas de movimento
    private void HandleInput()
    {
        float moveVertical = 0f;
        float moveHorizontal = 0f;

        if (Input.GetKey(KeyCode.W)){
            moveVertical = 1f;
        } 
        if (Input.GetKey(KeyCode.S)){
            moveVertical = -1f;
        }        
        if (Input.GetKey(KeyCode.A)){
            moveHorizontal = -1f;
        }        
        if (Input.GetKey(KeyCode.D)){
            moveHorizontal = 1f;
        }

        moveDirection = new Vector3(moveHorizontal, moveVertical, 0f).normalized;
    }

    private void MovePlayer()
    {
        if (moveDirection != Vector3.zero)
        {
            transform.Translate(moveDirection * playerSpeed * Time.deltaTime);
            float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        }
    }
}
