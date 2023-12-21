using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {
    List<AudioSource> audios = new List<AudioSource>();

    public AudioClip footStep;
    public AudioClip getCoin;

    void Start() {
        for (int i = 0; i < 3; i++) {
            var audio = gameObject.AddComponent<AudioSource>();
            audios.Add(audio);
        }
        audios[0].clip = footStep;
        audios[1].clip = getCoin;
    }

    public void PlayFootStepSound() {
        audios[0].Play();
    }

    public void PickUpCoin() {
        audios[1].Play();
    }
}
