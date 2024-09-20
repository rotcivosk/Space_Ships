using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update


    [SerializeField] float playerSpeed = 5f;
    [SerializeField] private float minX = -5f;
    [SerializeField] private float maxX = 5f; 
    [SerializeField] private float minY = -5f;
    [SerializeField] private float maxY = 5f; 
    private Vector3 moveDirection;
    public SpriteRenderer spriteRenderer;
    [SerializeField] Sprite movingDown;
    [SerializeField] Sprite movingUp;
    [SerializeField] Sprite movingRight;
    

    void Start()
    {
    }

    void Update()
    {
        HandleInput();
        MovePlayer();
    }
    private void HandleInput()
    {
        float moveVertical = 0f;
        float moveHorizontal = 0f;

        if (Input.GetKey(KeyCode.W)){
            moveVertical = 1f;
            spriteRenderer.sprite = movingUp;
        } 
        if (Input.GetKey(KeyCode.S)){
            moveVertical = -1f;
            spriteRenderer.sprite = movingDown;
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
            float clampedY = Mathf.Clamp(transform.position.y, minY, maxY);
            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }  else {
           spriteRenderer.sprite = movingRight;
        }
    }
}
