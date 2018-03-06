using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickHandler : MonoBehaviour {

	public static ClickHandler instance;

	void Awake(){
		instance = this;
	}

	public void CheckClickProperties(){
	

		//Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3") || Input.GetMouseButtonDown(0)
		if (Input.GetMouseButtonDown(0) || Input.GetButtonDown("Fire1") || Input.GetButtonDown("Fire2") || Input.GetButtonDown("Fire3") || Input.GetButtonDown("Jump")) {

			//BEST DEBUGGER
			////Debug.Log ("Player has clicked on " + RemCaster.instance.obj_in_sight.name + "; item in hand = " + IsHoldingItem().ToString());

			//Checks if there is an object in sight
			if (RemCaster.instance.obj_in_sight != null) {
				
				GameObject clicked = RemCaster.instance.obj_in_sight;

				switch (clicked.tag) {
					//CASES
					case "ingredient":
					if (IsHoldingItem() == false) {
						PlayerHand.instance.HoldItem (clicked);
					}
					break;

					case "MixerMachine":
					if (IsHoldingItem() == true) {
						PlayerHand.instance.DropItem ();
					}
					break;


					case "trash":
					//Method to throw item into garbage
					if (IsHoldingItem() == true) {
						PlayerHand.instance.TrashItem(RemCaster.instance.obj_in_sight.transform);
					}

					break;


					case "FinishedDish":
					////Debug.Log ("Player has clicked on MixerMachine; Object in hand=" + hasItem.ToString());
					//IF HAS ITEM; PLACE IT ON MACHINE
					if (IsHoldingItem() == false) {
						//Debug.Log ("Clicking on finished dish");
						FinishedDish.instance.CollectDish ();

					}
					break;

					case "startButton":
					if (IsHoldingItem () == false && MixerMachine.instance.canMix) {
						MixerMachine.instance.MixIngredients ();
						ButtonPress.instance.AnimateButton ();
						Debug.Log ("Machine started with button");
					}
					break;


					default:
					break;
				}

			}
		}
	}

	bool IsHoldingItem(){
		if (PlayerHand.instance.held_item == null) {
			return false;	
		} else {
			return true;
		}
	}
}
