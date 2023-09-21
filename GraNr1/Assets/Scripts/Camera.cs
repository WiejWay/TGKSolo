using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public string targetTag = "UFO"; 
    public float smoothTime = 0.2f; 
    private Vector3 velocity = Vector3.zero;

    void LateUpdate()
    {
        GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);

        if (targetObject != null)
        {
            Vector3 targetPosition = new Vector3(targetObject.transform.position.x, targetObject.transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}

