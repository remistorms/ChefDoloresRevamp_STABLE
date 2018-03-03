using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleSheetsToUnity;
using UnityEngine.UI;

public class SheetsManager : MonoBehaviour {

	public bool hasBeenPaid = false;
	SpreadSheetManager spreadSheetManager;
	GS2U_SpreadSheet spreadSheetFromName;
	GS2U_Worksheet worksheetFromName;

	public Text messageText;

	public void GetCellData (){
		StartCoroutine (LoadGoogleSheetData ());
	}

	IEnumerator LoadGoogleSheetData(){

		Debug.Log ("LOADING DATA");
		spreadSheetManager = new SpreadSheetManager ();
		yield return null;
		spreadSheetFromName = spreadSheetManager.LoadSpreadSheet ("Chef Dolores VR");
		worksheetFromName = spreadSheetFromName.LoadWorkSheet ("RemConfig");
		CellData cellData = worksheetFromName.GetCellData ("B", 2);
		Debug.Log (cellData.value.ToString());

		switch (cellData.value) {

		case "1":
			hasBeenPaid = true;
			messageText.text = "Cargando datos...";
			break;

			case "Yes":
			hasBeenPaid = true;
			messageText.text = "Cargando datos...";
			break;

			default:
			hasBeenPaid = false;
			messageText.text = "Error: C0D_05";
			break;
		}
	}


}

