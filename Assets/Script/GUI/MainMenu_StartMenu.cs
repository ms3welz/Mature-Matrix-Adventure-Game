using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu_StartMenu : MonoBehaviour {

	public string githubLink;
	public string surveiLink;
	public string bugLink;

	public Image soundImage;
	public Sprite soundOn;
	public Sprite soundOff;

	SoundManager soundManager;

	// Use this for initialization
	void Start () {
		if (AudioListener.volume == 0)
			soundImage.sprite = soundOff;
		else
			soundImage.sprite = soundOn;

		soundManager = FindObjectOfType<SoundManager> ();
	}
	
	public void TurnSound(){
		if (AudioListener.volume == 0) {
			AudioListener.volume = 1;
			soundImage.sprite = soundOn;
		} else {
			AudioListener.volume = 0;
			soundImage.sprite = soundOff;
		}

		SoundManager.PlaySfx (soundManager.soundClick);
	}

	public void OpenSurvei(){
		Application.OpenURL (surveiLink);

		SoundManager.PlaySfx (soundManager.soundClick);
	}

	public void OpenGitHub(){
		Application.OpenURL (githubLink);

		SoundManager.PlaySfx (soundManager.soundClick);
	}

	public void OpenBug(){
		Application.OpenURL (bugLink);

		SoundManager.PlaySfx (soundManager.soundClick);
	}

	public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
