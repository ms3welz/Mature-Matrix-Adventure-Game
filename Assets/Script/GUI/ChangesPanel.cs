using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangesPanel : MonoBehaviour
{
    public static ChangesPanel Instance;

    SoundManager soundManager;

    void Awake(){
		Instance = this;
		soundManager = FindObjectOfType<SoundManager> ();
	}

    public GameObject PanelStart;
    public GameObject PanelEnd;
    
    public void ChangeNewPanel() 
    {
        PanelStart.SetActive(false);
        PanelEnd.SetActive(true);

        SoundManager.PlaySfx (soundManager.soundClick);
    }
}
