using UnityEngine;

public static class Extensions
{
    public static Color WithAlpha(this Color color, float a) => new Color(color.r, color.g, color.b, a);

    public static Color AddAlpha(this Color color, float a) => new Color(color.r, color.g, color.b, color.a + a);

    public static bool IsZero(this float f) => Mathf.Abs(f) < float.Epsilon;
    public static bool IsZero(this float f, float epsilon) => Mathf.Abs(f) < epsilon;

    public static bool Approx(this float f, float other) => IsZero(f - other);
    public static bool Approx(this float f, float other, float epsilon) => IsZero(f - other, epsilon);

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
}
