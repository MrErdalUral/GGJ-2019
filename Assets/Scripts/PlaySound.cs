using System.Collections;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioClip[] _clips;

    [NaughtyAttributes.MinMaxSlider(0, 1)] public Vector2 PitchRandomizer;

    [NaughtyAttributes.Button]
    public void Play()
    {
        StartCoroutine(PlayCoroutine());
    }

    public void Play(AudioClip clip)
    {
        StartCoroutine(PlayCoroutine(clip));
    }

    private IEnumerator PlayCoroutine(AudioClip clip = null)
    {
        if (clip == null)
            clip = _clips.Random();

        var go = new GameObject("PlaySound");
        go.transform.SetParent(transform);

        var source = go.AddComponent<AudioSource>();
        source.loop = false;
        source.clip = clip;
        source.pitch += PitchRandomizer.Random();
        source.Play();

        while (source.isPlaying) yield return null;

        print("Destroy obj");

#if UNITY_EDITOR
        DestroyImmediate(go, false);
#else
        Destroy(go);
#endif
    }
}
