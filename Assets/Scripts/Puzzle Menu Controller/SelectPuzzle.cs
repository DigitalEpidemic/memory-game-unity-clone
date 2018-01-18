using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPuzzle : MonoBehaviour {

	[SerializeField]
	private GameObject selectPuzzleMenuPanel;

	[SerializeField]
	private Animator selectPuzzleMenuAnim;

	private string selectedPuzzle;

	public void SelectedPuzzle () {
		selectedPuzzle = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

		Debug.Log (selectedPuzzle);
	}

} // SelectPuzzle