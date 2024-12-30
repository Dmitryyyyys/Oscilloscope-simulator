using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 5f; 
    public float rotationSpeed = 5f; 
    public Transform tableObject; 
    private Vector3 lastMousePosition; 
    private bool rotateAroundTable = false;
    private Rigidbody rb; 

    private Vector3 initialPosition; 
    private Quaternion initialRotation; 

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

        
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void HandleMovement()
    {
        
        if (!rotateAroundTable)
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

            float moveForward = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime; 
            float moveRight = Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime; 

            Vector3 movement = forward * moveForward + right * moveRight;

        
            if (CanMove(movement))
            {
        
                Vector3 newPosition = rb.position + movement;
                rb.MovePosition(newPosition);
            }
        }
    }

    private bool CanMove(Vector3 movement)
    {
        
        RaycastHit hit;
        
        Vector3 newPosition = rb.position + movement;

        
        return !Physics.Raycast(rb.position, movement.normalized, out hit, movement.magnitude);
    }

    private void HandleRotation()
    {
        
        if (Input.GetMouseButton(1))
        {
            Vector3 mouseDelta = Input.mousePosition - lastMousePosition;

            float horizontalRotation = mouseDelta.x * rotationSpeed * Time.deltaTime;
            float verticalRotation = -mouseDelta.y * rotationSpeed * Time.deltaTime;

            if (rotateAroundTable)
            {
        
                transform.RotateAround(tableObject.position, Vector3.up, horizontalRotation);
                transform.RotateAround(tableObject.position, transform.right, verticalRotation);
            }
            else
            {
               
                transform.Rotate(0, horizontalRotation, 0, Space.World);
                transform.Rotate(verticalRotation, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetMouseButton(1))
        {
            ResetCameraToInitialPosition();
            rotateAroundTable = true; 
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            rotateAroundTable = false; 
        }

        lastMousePosition = Input.mousePosition;
    }

    private void ResetCameraToInitialPosition()
    {
        rb.position = initialPosition; 
        rb.rotation = initialRotation; 
    }
}
