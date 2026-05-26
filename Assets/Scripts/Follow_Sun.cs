using UnityEngine;

public class Follow_Sun : MonoBehaviour
{
    // Make the fixed rate a public variable
    public float followSpeed = 10f;

    // Add a public variable to set the Z position
    [SerializeField] private float fixedZPosition = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in screen space
        Vector3 mouseScreenPos = Input.mousePosition;

        // Convert screen position to world position
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, 0f));

        // Move the object towards the mouse position at a fixed rate
        // Create a target position using the mouse's X and Y, but the fixed Z
        Vector3 targetPosition = new Vector3(mouseWorldPos.x, mouseWorldPos.y, fixedZPosition);

        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}