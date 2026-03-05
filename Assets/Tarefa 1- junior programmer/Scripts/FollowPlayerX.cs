using UnityEngine;

public class FollowPlayerX : MonoBehaviour
{
    public Transform plane;

    public Vector3 offset = new Vector3(15f, 3f, 0f);

    void LateUpdate()
    {
        transform.position = plane.position + offset;
        transform.LookAt(plane);
    }
}
