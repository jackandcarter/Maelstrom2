using UnityEngine;

public class SphereWrapper : MonoBehaviour
{
    public GameObject[] objectsToWrap;
    public float attractionStrength = 1f;
    public float attractionDistance = 2f;

    private Mesh sphereMesh;
    private float sphereRadius;

    void Start()
    {
        // Get the mesh and radius of the sphere
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if (meshFilter != null)
        {
            sphereMesh = meshFilter.mesh;
            sphereRadius = meshFilter.transform.localScale.x / 2f; // Assuming uniform scaling
        }
        else
        {
            Debug.LogError("SphereWrapper script requires a MeshFilter component on the sphere GameObject.");
        }
    }

    void Update()
    {
        WrapObjects();
    }

    void WrapObjects()
    {
        foreach (GameObject obj in objectsToWrap)
        {
            WrapObject(obj.transform);
        }
    }

    void WrapObject(Transform objTransform)
    {
        Vector3 objectPosition = objTransform.position;
        Vector3 directionToCenter = transform.position - objectPosition;
        float distanceToCenter = directionToCenter.magnitude;

        if (distanceToCenter > sphereRadius)
        {
            // Wrap object to the opposite side of the sphere
            Vector3 wrappedPosition = transform.position - directionToCenter.normalized * (sphereRadius - 0.1f);
            objTransform.position = wrappedPosition;
        }

        // Apply attraction force if the object is within the attraction distance from the boundary
        if (distanceToCenter > sphereRadius - attractionDistance)
        {
            Vector3 attractionDirection = directionToCenter.normalized;
            float attractionForce = (distanceToCenter - (sphereRadius - attractionDistance)) * attractionStrength;
            objTransform.GetComponent<Rigidbody>().AddForce(attractionDirection * attractionForce);
        }
    }
}
