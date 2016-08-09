using UnityEngine;
using System.Collections;

public enum SoundState
{
	BUTTON_CLICK,
    GENIUS_RED,
    GENIUS_BLUE,
    GENIUS_GREEN,
    GENIUS_YELLOW
}

public class SoundController : MonoBehaviour 
{
	public AudioClip buttonClick;
	public AudioClip geniusRedColor;
	public AudioClip geniusBlueColor;
	public AudioClip geniusYellowColor;
	public AudioClip geniusGreenColor;

    //singleton
    private static SoundController soundControllerInstance;

	void Awake () 
	{
		if(soundControllerInstance == null)
		{
			soundControllerInstance = this;
			DontDestroyOnLoad (gameObject);
		}

		else
		{
			DestroyImmediate (gameObject);
		}
	}

	public static void PlaySound(SoundState newSoundState)
	{
		switch(newSoundState)
		{
		    case SoundState.BUTTON_CLICK:
			    soundControllerInstance.GetComponent<AudioSource>().PlayOneShot(soundControllerInstance.buttonClick);
			    break;

            case SoundState.GENIUS_BLUE:
                soundControllerInstance.GetComponent<AudioSource>().PlayOneShot(soundControllerInstance.geniusBlueColor);
                break;

            case SoundState.GENIUS_GREEN:
                soundControllerInstance.GetComponent<AudioSource>().PlayOneShot(soundControllerInstance.geniusGreenColor);
                break;

            case SoundState.GENIUS_RED:
                soundControllerInstance.GetComponent<AudioSource>().PlayOneShot(soundControllerInstance.geniusRedColor);
                break;

            case SoundState.GENIUS_YELLOW:
                soundControllerInstance.GetComponent<AudioSource>().PlayOneShot(soundControllerInstance.geniusYellowColor);
                break;
        }
	}
}
