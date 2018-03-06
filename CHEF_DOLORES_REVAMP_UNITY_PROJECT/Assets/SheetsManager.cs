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

	public Text messageText, versionText;

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
		CellData versionNumber = worksheetFromName.GetCellData ("B", 3);
		Debug.Log (cellData.value.ToString());

		switch (cellData.value) {

		case "1":
			hasBeenPaid = true;
			messageText.text = "Cargando datos...";
			versionText.text = "Ver. " + versionNumber.value;
			break;

			case "Yes":
			hasBeenPaid = true;
			messageText.text = "Cargando datos...";
			versionText.text = "Ver. " + versionNumber.value;
			break;

			default:
			hasBeenPaid = false;
			messageText.text = "Error: C0D_05";
			versionText.text = "Ver. " + versionNumber.value;
			break;
		}
	}


}

