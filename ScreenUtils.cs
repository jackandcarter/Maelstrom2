using UnityEngine;

public static class ScreenUtils
{
    public static float ScreenLeft
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(Vector3.zero).x;
        }
    }

    public static float ScreenRight
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
        }
    }

    public static float ScreenTop
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        }
    }

    public static float ScreenBottom
    {
        get
        {
            return Camera.main.ScreenToWorldPoint(Vector3.zero).y;
        }
    }
}
