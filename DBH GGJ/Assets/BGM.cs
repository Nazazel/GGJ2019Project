using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM : MonoBehaviour
{
    // In the main menu, there should only be 1 AudioSource attached to the BGM object.
    //      It should have some ambience loaded into it.
    // In that case, you can use these calls to fade the music out/in:
    // StartCoroutine(FadeOut(tracks[0], fade));
    // StartCoroutine(FadeIn(tracks[0], fade));

    // In the level, there should be at least 2 AudioSources attached to the BGM object.
    //      The first one has the High tension theme.
    //      The second one has the Low tension theme.
    //      An optional third one has an easter egg.
    // Use HighToLow() and LowToHigh() to switch between the two tracks.
    // Use PlayWilhelm() to play the Wilhelm scream.

    private AudioSource[] tracks;
    public float fade;
    private bool alreadyTransitioned = false;

    void Start()
    {
        tracks = GetComponents<AudioSource>();
    }

    public void PlayWilhelm() {
        if (tracks.Length == 3) {
            tracks[2].Play();
        }
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
        if (alreadyTransitioned)
            return;
        alreadyTransitioned = true;
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
