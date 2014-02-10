using UnityEngine;
using System.Collections;

public class PianoKeyScript : MonoBehaviour {
	
	public int semitone_offset;
	public delegate void AudioCallback();
	public float offset = 1.5f;
	public static int maxPlaysPerTone = 3;

	public static int[] tones;
	
	// Use this for initialization
	void Start () {
		tones = new int[Prefabs.Instance.availableColors.Length];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnMouseDown() {
		//PlayNote();
	}
	
	void OnCollisionEnter(Collision col) {

		if (tones [semitone_offset] > maxPlaysPerTone)
			return;

		audio.pitch = Mathf.Pow (2f, (semitone_offset)/12.0f);
		
		PlaySoundWithCallback(audio.clip, AudioFinished);

		++tones[semitone_offset];
	}

	void AudioFinished()
	{
		--tones [semitone_offset];
	}

	public void PlaySoundWithCallback(AudioClip clip, AudioCallback callback)
	{
		audio.PlayOneShot(clip);
		StartCoroutine(DelayedCallback(clip.length, callback));
	}

	private IEnumerator DelayedCallback(float time, AudioCallback callback)
	{
		yield return new WaitForSeconds(time);
		callback();
	}
}
