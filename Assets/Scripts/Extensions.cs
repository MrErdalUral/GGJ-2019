using System;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static Color WithAlpha(this Color color, float a) => new Color(color.r, color.g, color.b, a);

    public static Color AddAlpha(this Color color, float a) => new Color(color.r, color.g, color.b, color.a + a);

    public static bool IsZero(this float f) => Mathf.Abs(f) < float.Epsilon;
    public static bool IsZero(this float f, float epsilon) => Mathf.Abs(f) < epsilon;

    public static bool Approx(this float f, float other) => IsZero(f - other);
    public static bool Approx(this float f, float other, float epsilon) => IsZero(f - other, epsilon);

    public static bool Approx(this Vector2 v, Vector2 t) => v.x.Approx(t.x) && v.y.Approx(t.y);
    public static bool Approx(this Vector3 v, Vector3 t) => v.x.Approx(t.x) && v.y.Approx(t.y) && v.z.Approx(t.z);

    public static T GetOrAddComponent<T>(this GameObject self) where T : Component
    {
        var component = self.GetComponent<T>();
        return component == null ? self.AddComponent<T>() : component;
    }

    public static T GetOrAddComponentInChildren<T>(this GameObject self) where T : Component
    {
        var component = self.GetComponentInChildren<T>();
        return component == null ? self.AddComponent<T>() : component;
    }

    public static float Random(this Vector2 v) => UnityEngine.Random.Range(v.x, v.y);

    public static T Random<T>(this T[] array)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));
        if (array.Length == 0)
            throw new ArgumentException("Collection must not be empty.");

        return array[UnityEngine.Random.Range(0, array.Length)];
    }

    public static IEnumerable<Transform> GetChildrenEnumerable(this Transform self)
    {
        for (var i = 0; i < self.childCount; i++)
            yield return self.GetChild(i);
    }
}
