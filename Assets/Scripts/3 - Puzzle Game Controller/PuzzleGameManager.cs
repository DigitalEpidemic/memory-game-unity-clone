using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleGameManager : MonoBehaviour {

	private List<Button> puzzleButtons = new List<Button> ();
	private List<Animator> puzzleButtonsAnimators = new List<Animator> ();

	[SerializeField]
	private List<Sprite> gamePuzzleSprites = new List<Sprite> ();

	private int level;
	private string selectedPuzzle;

	public void PickAPuzzle () {
//		Debug.Log ("The selected button is " + UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
		int index = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

		StartCoroutine (TurnPuzzleButtonUp (
			puzzleButtonsAnimators[index],
			puzzleButtons[index],
			gamePuzzleSprites[index]
		));
	}

	IEnumerator TurnPuzzleButtonUp (Animator anim, Button btn, Sprite puzzleImage) {
		anim.Play ("TurnUp");
		yield return new WaitForSeconds (0.4f);
		btn.image.sprite = puzzleImage;
	}

	IEnumerator TurnPuzzleButtonBack (Animator anim, Button btn, Sprite puzzleImage) {
		anim.Play ("TurnBack");
		yield return new WaitForSeconds (0.4f);
		btn.image.sprite = puzzleImage;
	}

	void AddListeners () {
		foreach (Button btn in puzzleButtons) {
			btn.onClick.RemoveAllListeners ();
			btn.onClick.AddListener (() => PickAPuzzle ());
		}
	}

	public void SetupButtonsAndAnimators (List<Button> buttons, List<Animator> animators) {
		this.puzzleButtons = buttons;
		this.puzzleButtonsAnimators = animators;

		AddListeners ();
	}

	public void SetGamePuzzleSprites (List<Sprite> gamePuzzleSprites) {
		this.gamePuzzleSprites = gamePuzzleSprites;
	}

	public void SetLevel (int level) {
		this.level = level;
	}

	public void SetSelectedPuzzle (string selectedPuzzle) {
		this.selectedPuzzle = selectedPuzzle;
	}

} // PuzzleGameManager