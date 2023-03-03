using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float walkSpeed = 50f;

    private Rigidbody playerRigidbody;

    public float lookSensitivity;

    [SerializeField]
    private float cameraRotationLimit;
    [SerializeField]
    private float playerRotationLimit;
    private float currentCameraRotationX = 0f;
    private float currentCharacterRotationY = 0f;

    [SerializeField]
    private Camera theCamera;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isGameover)
        {
            return;
        }
        Move();
        CameraRotation();
        CharacterRotation();
    }

    private void Move()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * moveX;
        Vector3 moveVertical = transform.forward * moveZ; 

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * walkSpeed;
        
        playerRigidbody.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    private void CameraRotation()
    {
        float rotationX = Input.GetAxisRaw("Mouse Y");
        float cameraRotationX = rotationX * lookSensitivity;
        currentCameraRotationX -= cameraRotationX;

        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }
    
    private void CharacterRotation()
    {
        float rotationY = Input.GetAxisRaw("Mouse X");
        float characterRotation = rotationY * lookSensitivity;
        currentCharacterRotationY += characterRotation;

        currentCharacterRotationY = Mathf.Clamp(currentCharacterRotationY, -playerRotationLimit, playerRotationLimit);

        playerRigidbody.MoveRotation(Quaternion.Euler(0f, currentCharacterRotationY, 0f));
    }
}
