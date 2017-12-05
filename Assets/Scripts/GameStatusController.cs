using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameStatusController : MonoBehaviour {
	public int maxAmountOfUps = 1;
	public int maxAmountOfDowns = 1;
	public GameObject stageProgressBar;

	private int currentAmoutOfUps = 0;
	private int currentAmoutOfDowns = 0;

	private Image progressImage;
	private Text progressText;
	private bool hasGameStarted = false;

	// Use this for initialization
	void Start() {
		if(stageProgressBar != null) {
			this.progressImage = stageProgressBar.transform.GetChild(0).GetComponent<Image>();
			this.progressText = stageProgressBar.transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
		}
		
	}
	
	// Update is called once per frame
	void Update() {
		
	}

	public void SetGameStarted() {
		if(this.hasGameStarted) {
			this.hasGameStarted = false;
		} else {
			this.hasGameStarted = true;
		}
	}

	public bool GetGameStarted() {
		return this.hasGameStarted;
	}

	public void gameOverVerifier() {
		if(hasGameStarted) {
			if(progressImage.fillAmount == 1f) {
				Debug.Log("Progress: " + progressImage.fillAmount + "\tYou Win!");
				hasGameStarted = false;
			} else {
				Debug.Log("Progress: " + progressImage.fillAmount + "\tYou Lose!");
				hasGameStarted = false;
			}
		}
	}

	public void increaseProgress(bool isQuarkUp) {
		
		if(isQuarkUp) {
			if(currentAmoutOfUps == maxAmountOfUps) {
				return;
			}
			currentAmoutOfUps++;
		} else {
			if(currentAmoutOfDowns == maxAmountOfDowns) {
				return;
			}
			currentAmoutOfDowns++;
		}

		progressImage.fillAmount = (float)(currentAmoutOfUps + currentAmoutOfDowns) / (float)(maxAmountOfUps + maxAmountOfDowns);
		progressText.text = ((int)(progressImage.fillAmount * 100)) + "%";
	}
}
