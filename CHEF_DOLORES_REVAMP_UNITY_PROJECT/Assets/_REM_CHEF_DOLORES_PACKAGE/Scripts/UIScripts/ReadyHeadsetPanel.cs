using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class ReadyHeadsetPanel : MonoBehaviour {

	public Image[] fillClocks;
	public GameObject buttonOK;

	public void StartTimer(){

		StartCoroutine (StartTimerRoutine ());
	}

	IEnumerator StartTimerRoutine(){
		//Disables button
		buttonOK.SetActive(false);
		//Tweens fill image and then calls the method to load the scene
		foreach (var item in fillClocks) {
			DOTween.To (
				()=> item.fillAmount,
				x=> item.fillAmount =x,
				0,
				10
			);
		}
		yield return new WaitForSeconds (10);
		XRSettings.enabled = true;
		SceneManager.LoadScene (2);
	}
}
