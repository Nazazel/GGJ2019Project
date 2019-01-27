using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // To fade out in a scene with just 1 track, call:
    // StartCoroutine(FadeOut(tracks[0], fade));

    // And to fade out in a scene with a single track:
    // StartCoroutine(FadeOut(tracks[0], fade));

    private AudioSource[] tracks;
    public float fade;

    void Start()
    {
        tracks = GetComponents<AudioSource>();
    }

    public void HighToLow() {
        StartCoroutine(FadeOut(tracks[0], fade));
        StartCoroutine(FadeIn(tracks[1], fade));
        if (tracks[0].volume == 0f) {
            StopCoroutine(FadeOut(tracks[0], fade));
        }
        if (tracks[1].volume == 1f) {
            StopCoroutine(FadeIn(tracks[1], fade));
        }
    }

    public void LowToHigh() {
        StartCoroutine(FadeOut(tracks[1], fade));
        StartCoroutine(FadeIn(tracks[0], fade));
        if (tracks[1].volume == 0f) {
            StopCoroutine(FadeOut(tracks[0], fade));
        }
        if (tracks[0].volume == 1f) {
            StopCoroutine(FadeIn(tracks[1], fade));
        }
    }

    public static IEnumerator FadeOut(AudioSource t, float fadeTime) {
        t.volume = 1f;
        while(t.volume > 0f) {
            t.volume -= Time.deltaTime / fadeTime;
            yield return null;
        }
    }

    public static IEnumerator FadeIn(AudioSource t, float fadeTime) {
        t.volume = 0f;
        while(t.volume < 1f) {
            t.volume += Time.deltaTime / fadeTime;
            yield return null;
        }
    }
}
