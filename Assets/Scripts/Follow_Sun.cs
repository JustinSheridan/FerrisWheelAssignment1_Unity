using UnityEngine;

public class Follow_Sun : MonoBehaviour
{
    public float followSpeed = 10f;
    [SerializeField] private float fixedZPosition = 0f;
    
    // Curve defines the pulse shape (e.g., goes up and down)
    [SerializeField] private AnimationCurve scaleCurve;
    
    // Speed of the pulse
    [SerializeField] private float pulseSpeed = 2f;

    void Start()
    {
        // Provide default cubic curve for pulsing if not assigned
        if (scaleCurve == null)
        {
            // Example: Start at 0.5, go up to 1.5, back down to 0.5
            scaleCurve = new AnimationCurve(
                new Keyframe(0f, 0.5f),
                new Keyframe(0.5f, 1.5f),
                new Keyframe(1f, 0.5f)
            );
        }
    }

    void Update()
    {
        // Follows the mouse
        Vector3 mouseScreenPos = Input.mousePosition;
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(new Vector3(mouseScreenPos.x, mouseScreenPos.y, Camera.main.nearClipPlane));
        Vector3 targetPosition = new Vector3(mouseWorldPos.x, mouseWorldPos.y, fixedZPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);

        // Pulsing the curve
        // Mathf.PingPong creates a value that goes 0 -> 1 -> 0 -> 1 indefinitely
        float pulseValue = Mathf.PingPong(Time.time * pulseSpeed, 1f);
        
        float scaleFactor = scaleCurve.Evaluate(pulseValue);
        
        // Scale with Lerp
        Vector3 targetScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * 10f);
    }
}