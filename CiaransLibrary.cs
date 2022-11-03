using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   <para>A library of functions that Unity probably should have by default - and some others</para>
/// </summary>
public struct CiaransLibrary 
{
    /// <summary>
    ///   <para>Get direction between two three-dimensional points.</para>
    /// </summary>
    /// <param name="pointA">Origin point.</param>
    /// <param name="pointB">Point you want the direction of.</param>
    public static Vector3 GetDirection (Vector3 pointA, Vector3 pointB)
    {
        Vector3 direction;
        direction = (pointA - pointB).normalized;
        return -direction; 
    }

    /// <summary>
    ///   <para>Get direction between two three-dimensional points.</para>
    /// </summary>
    /// <param name="pointA">Origin point.</param>
    /// <param name="pointB">Point you want the direction of.</param>
    /// <param name="normalized">Normalize the vector after  calculation.</param>
    public static Vector3 GetDirection(Vector3 pointA, Vector3 pointB, bool normalized)
    {
        Vector3 direction;
        if (normalized)
        {
            direction = (pointA - pointB).normalized;
        }
        else
        {
            direction = (pointA - pointB);
        }
        return -direction;
    }

    /// <summary>
    ///   <para>Get direction between two two-dimensional points.</para>
    /// </summary>
    /// <param name="pointA">Origin point.</param>
    /// <param name="pointB">Point you want the direction of.</param>
    public static Vector2 GetDirection(Vector2 pointA, Vector2 pointB)
    {
        Vector2 direction;
        direction = (pointA - pointB).normalized;
        return -direction;
    }

    /// <summary>
    ///   <para>Get direction between two two-dimensional points.</para>
    /// </summary>
    /// <param name="pointA">Origin point.</param>
    /// <param name="pointB">Point you want the direction of.</param>
    /// <param name="normalized">Normalize the vector after  calculation.</param>
    public static Vector2 GetDirection(Vector2 pointA, Vector2 pointB, bool normalized)
    {
        Vector2 direction;
        if (normalized)
        {
            direction = (pointA - pointB).normalized;
        }
        else
        {
            direction = (pointA - pointB);
        }
        return -direction;
    }

    /// <summary>
    ///   <para>Get direction between two four-dimensional points.</para>
    /// </summary>
    /// <param name="pointA">Origin point.</param>
    /// <param name="pointB">Point you want the direction of.</param>
    public static Vector4 GetDirection(Vector4 pointA, Vector4 pointB)
    {
        Vector4 direction;
        direction = (pointA - pointB).normalized;
        return -direction;
    }

    /// <summary>
    ///   <para>Get direction between two four-dimensional points.</para>
    /// </summary>
    /// <param name="pointA">Origin point.</param>
    /// <param name="pointB">Point you want the direction of.</param>
    /// <param name="normalized">Normalize the vector after  calculation.</param>
    public static Vector4 GetDirection(Vector4 pointA, Vector4 pointB, bool normalized)
    {
        Vector4 direction;
        if (normalized)
        {
            direction = (pointA - pointB).normalized;
        }
        else
        {
            direction = (pointA - pointB);
        }
        return -direction;
    }

    /// <summary>
    /// Returns all colliders within a cone. Think of it like a camera frustrum.
    /// </summary>
    /// <param name="position">the origin of the cone</param>
    /// <param name="forwardDirection">the direction the cone is facing in</param>
    /// <param name="range">the range of the cone</param>
    /// <param name="angle">the angle of the cone</param>
    /// <returns></returns>
    public static Collider[] OverlapCone(Vector3 position, Vector3 forwardDirection, float range, float angle) 
    {
        var CollidersFromOverlapSphere = Physics.OverlapSphere(position, range);
        List<Collider> colliders = new List<Collider>();
        foreach (Collider collider in CollidersFromOverlapSphere)
        {
            Vector3 direction = GetDirection(position, collider.transform.position, true);
            float angleToCollider = Vector3.Angle(forwardDirection, direction);

            if (angleToCollider < angle) // if angle to collider is greater than angle
            {
                colliders.Add(collider);
            }
        }
        return colliders.ToArray();

    }

    /// <summary>
    /// Returns true if a specific value is within a specific range
    /// </summary>
    /// <param name="value">The value to be clamped</param>
    /// <param name="min">The smallest you want the value to be</param>
    /// <param name="max">the largest you want the value to be</param>
    /// <returns></returns>
    public static bool Clamp(float value, float min, float max)
    {
        if (value < max || value > min)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns true if a specific value is within a specific range
    /// </summary>
    /// <param name="value">The value to be clamped</param>
    /// <param name="min">The smallest you want the value to be</param>
    /// <param name="max">the largest you want the value to be</param>
    /// <returns></returns>
    public static bool Clamp(int value, int min, int max)
    {
        if (value < max || value > min)
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// Returns true if an unbroken line, heading in a specified direction, can be trance to a specified object
    /// </summary>
    /// <param name="origin">line origin</param>
    /// <param name="direction">the direction the line will go in</param>
    /// <param name="target">the target object</param>
    /// <returns></returns>
    public static bool CheckIfLineOfSightUnbroken(Vector3 origin, GameObject target)
    {
        RaycastHit hit;

        Vector3 direction = GetDirection(origin, target.transform.position);

        if (Physics.Raycast(origin, direction, out hit))
        {
            if (hit.transform.gameObject == target)
            {
                return true;
            }
        }


        return false;
    }

    /// <summary>
    /// Returns true if an unbroken line, heading in a specified direction, can be trance to a specified object
    /// </summary>
    /// <param name="origin">line origin</param>
    /// <param name="direction">the direction the line will go in</param>
    /// <param name="target">the target object</param>
    /// <returns></returns>
    public static bool CheckIfLineOfSightUnbroken(Vector3 origin, Vector3 direction, GameObject target)
    {
        RaycastHit hit;

        if (Physics.Raycast(origin, direction, out hit))
        {
            if (hit.transform.gameObject == target)
            {
                return true;
            }
        }


        return false;
    }

    

    /// <summary>
    /// Us as parameter in List.Sort() to bubble sort that list.
    /// </summary>
    /// <returns></returns>
    public static int BubbleSort(int a, int b) 
    {
        if (a < b)
        {
            return 1;
        }
        else if (a > b)
        {
            return -1;
        }
        return 0;
    }

    /// <summary>
    /// Us as parameter in List.Sort() to bubble sort that list.
    /// </summary>
    /// <returns></returns>
    public static int BubbleSort(float a, float b)
    {
        if (a < b)
        {
            return 1;
        }
        else if (a > b)
        {
            return -1;
        }
        return 0;
    }
    
    public static int Negate (int number)
    {
         return -1 * number;
    }
    
    public static float Negate (float number)
    {
         return -1 * number;
    }
}
