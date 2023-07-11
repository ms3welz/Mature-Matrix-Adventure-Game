using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuizKey : MonoBehaviour,IPlayerRespawnListener {
	public GameObject GameQuiz;
	//public GameObject Controller;

	public int pointToAdd = 100;
	public int bulletToAdd = 5;
	public int coinToAdd = 5;
	public int healthToGive = 50;

	public GameObject Effect;
	public bool isRespawnCheckPoint = true;
	public AudioClip sound;
	[Range(0,1)]
	public float soundVolume = 0.5f;


	void OnTriggerEnter2D(Collider2D other){
		SoundManager.PlaySfx (sound, soundVolume);
		//if (Time.timeScale == 0) {
		//	GameQuiz.SetActive (false);
		//	Time.timeScale = 1;
		//} else {
			GameQuiz.SetActive (true);
			//Controller.SetActive (false);
		//	Time.timeScale = 0;
		//}

		var Player = other.gameObject.GetComponent<Player> ();
		if (Player == null)
				return;

		GameManager.Instance.AddBullet (bulletToAdd);
		GameManager.Instance.AddPoint (pointToAdd);
		GameManager.Instance.AddCoin (coinToAdd);
		GameManager.Instance.AddPoint (pointToAdd);

		Player.GiveHealth (healthToGive, gameObject);

		if (Effect != null)
			Instantiate (Effect, transform.position, transform.rotation);

		gameObject.SetActive (false);
	}

	public void OnPlayerRespawnInThisCheckPoint (CheckPoint checkpoint, Player player)
	{
		if (isRespawnCheckPoint)
			gameObject.SetActive (true);
	}
}
