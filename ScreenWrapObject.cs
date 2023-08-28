using UnityEngine;

public static class ScreenWrapObject
{
    // ScreenWrapObject.WrapObject is used to wrap objects around the screen edges.
    // The transform parameter represents the object's transform that needs to be wrapped.
    // The camera parameter is used to define the screen boundaries.
    public static void WrapObject(Transform transform, Camera camera)
    {
        // Get the object's position in world coordinates.
        Vector3 position = transform.position;

        // Get the screen boundaries in world coordinates.
        float screenLeft = camera.ScreenToWorldPoint(new Vector3(0, 0, position.z)).x;
        float screenRight = camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, position.z)).x;
        float screenTop = camera.ScreenToWorldPoint(new Vector3(0, Screen.height, position.z)).y;
        float screenBottom = camera.ScreenToWorldPoint(new Vector3(0, 0, position.z)).y;

        // Check if the object is outside the screen boundaries.
        // If so, wrap it to the opposite side.
        if (position.x < screenLeft)
        {
            position.x = screenRight;
        }
        else if (position.x > screenRight)
        {
            position.x = screenLeft;
        }

        if (position.y > screenTop)
        {
            position.y = screenBottom;
        }
        else if (position.y < screenBottom)
        {
            position.y = screenTop;
        }

        // Update the object's position to wrap it around the screen.
        transform.position = position;
    }
}
