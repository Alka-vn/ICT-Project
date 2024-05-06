using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField]public Camera mainCamera; // Assign in the Inspector or via code
    public Transform fruitTransform;
    private float width;
    private float height;

    private int speed;
    private float directionX;
    private int rotationSpeed;


    private float topBound;
    private float leftBound;
    private float rightBound;
    private void Awake()
    {
        Random.InitState(System.Environment.TickCount); // Initialize random seed once
    }

    private void Start()
    {
        GameObject cameraObject = GameObject.FindGameObjectWithTag("Camera");

        if (cameraObject != null)
        {
            mainCamera = cameraObject.GetComponent<Camera>();

            if (mainCamera != null)
            {
                // Successfully assigned the cameraObject to mainCamera
                Debug.Log("Camera assigned successfully!");
            }
            else
            {
                Debug.LogError("Failed to assign camera. Make sure the cameraObject has a Camera component.");
            }
        }
        else
        {
            Debug.LogError("No GameObject with the 'Camera' tag found!");
        }
        Debug.Log("The main Camera is ",mainCamera);
        CalculateScreenDimensions();
        InitializeFruitProperties();
    }

    private void CalculateScreenDimensions()
    {

        float cameraOrthoSize = mainCamera.orthographicSize;
        float cameraAspect = mainCamera.aspect;

        topBound = cameraOrthoSize;
        leftBound = -cameraOrthoSize * cameraAspect;
        rightBound = cameraOrthoSize * cameraAspect;
    }



    private void InitializeFruitProperties()
    {
        float randomX = Random.Range(leftBound, rightBound);
        float randomY = topBound;
        fruitTransform.position = new Vector3(randomX, randomY);

        speed = 1;
        directionX = Random.Range(-0.6f, 0.6f);
        rotationSpeed = Random.Range(80, 100);
    }
    private void Update()
    {
        Vector3 newPosition = fruitTransform.position + new Vector3(directionX, -1.0f,0) * speed * Time.deltaTime;
        fruitTransform.position = newPosition;
        if (fruitTransform.position.z >= 0)
        {
            newPosition = new Vector3(fruitTransform.position.x, fruitTransform.position.y, -1);
            fruitTransform.position = newPosition;
        }
        fruitTransform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

}

 
