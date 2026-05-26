using UnityEngine;

public class Spin_FerrisWheelBars : MonoBehaviour
{
    // Make the fixed rate a public variable, allowing adjustment in the Inspector
    [SerializeField] private float spinRate = 90f; // Degrees per second
    [SerializeField] private Vector3 pivotPoint = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Spin the object around its own local Z-axis at the fixed rate
        // This keeps the object in place while rotating it
        transform.Rotate(Vector3.forward * spinRate * Time.deltaTime);
    }
}