using UnityEngine;
using System.Collections;

public class MusicPlay : MonoBehaviour {
	float time;
	// Use this for initialization
	AudioSource audio;
	void Start () {
	time = 0;
		audio = GetComponent<AudioSource>();
		audio.Play();
		//gameObject.GetComponent<AudioSource>().loop = true;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		if(time > 20){//play after x seconds
			if(audio.isPlaying)
				gameObject.GetComponent<AudioSource>().Stop();
			gameObject.GetComponent<AudioSource>().Play();
			time = 0;
		}
	}
}
