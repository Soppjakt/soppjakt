using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    private CharacterController characterController;
    private float jumpVelocity;
    private float rotateX = 0;

    [Header("PlayerController")]
    public float jumpSpeed;
    public float gravity;

    public float moveSpeed;

    public float sensitivity;

    [Header("Camera")]
    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {



        //Rotate player
        float rotateY = Input.GetAxis("Mouse X") * Time.deltaTime * sensitivity;
        transform.Rotate(new Vector3(0, rotateY, 0));

        //Rotate camera
        rotateX -= Input.GetAxis("Mouse Y") * Time.deltaTime * sensitivity;
        rotateX = Mathf.Clamp(rotateX, -60, 60f);
        cam.transform.localRotation = Quaternion.Euler(rotateX, 0, 0);

        //weaponPosition.localRotation = Quaternion.Euler(rotateX, 0, 0);

        //Player input
        float moveVertical = Input.GetAxis("Vertical") * moveSpeed;
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;

        //Jump input
        jumpVelocity -= gravity * Time.deltaTime;
        if (characterController.isGrounded && Input.GetButton("Jump"))
        {
            jumpVelocity = jumpSpeed;

        }

        //Move matrix
        Vector3 moveDirection = new Vector3(moveHorizontal, jumpVelocity, moveVertical);
        moveDirection = transform.rotation * moveDirection;
        //Player move - This tells the character controller to move the player.
        characterController.Move(moveDirection * Time.deltaTime);


    }
}