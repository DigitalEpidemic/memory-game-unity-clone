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

	private Sprite puzzleBackgroundImage;

	private bool firstGuess, secondGuess;
	private int firstGuessIndex, secondGuessIndex;
	private string firstGuessPuzzle, secondGuessPuzzle;

	private int countTryGuesses;
	private int countCorrectGuesses;
	private int gameGuesses;

	public void PickAPuzzle () {

		if (!firstGuess) {
			firstGuess = true;

			firstGuessIndex = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

			firstGuessPuzzle = gamePuzzleSprites [firstGuessIndex].name;

			StartCoroutine (TurnPuzzleButtonUp (puzzleButtonsAnimators [firstGuessIndex],
				puzzleButtons [firstGuessIndex],
				gamePuzzleSprites [firstGuessIndex]));

		} else if (!secondGuess) {
			secondGuess = true;

			secondGuessIndex = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

			secondGuessPuzzle = gamePuzzleSprites [secondGuessIndex].name;

			StartCoroutine (TurnPuzzleButtonUp (puzzleButtonsAnimators [secondGuessIndex],
				puzzleButtons [secondGuessIndex],
				gamePuzzleSprites [secondGuessIndex]));

			StartCoroutine (CheckIfThePuzzlesMatch (puzzleBackgroundImage));

			countTryGuesses++;
		}

	}

	IEnumerator CheckIfThePuzzlesMatch (Sprite puzzleBackgroundImage) {
		yield return new WaitForSeconds (1.7f);

		if (firstGuessPuzzle == secondGuessPuzzle) {
			puzzleButtonsAnimators [firstGuessIndex].Play ("FadeOut");
			puzzleButtonsAnimators [secondGuessIndex].Play ("FadeOut");

			CheckIfTheGameIsFinished ();

		} else {
			StartCoroutine (TurnPuzzleButtonBack (puzzleButtonsAnimators [firstGuessIndex],
				puzzleButtons [firstGuessIndex],
				puzzleBackgroundImage));

			StartCoroutine (TurnPuzzleButtonBack (puzzleButtonsAnimators [secondGuessIndex],
				puzzleButtons [secondGuessIndex],
				puzzleBackgroundImage));
		}

		yield return new WaitForSeconds (0.7f);
		firstGuess = secondGuess = false;
	}

	void CheckIfTheGameIsFinished () {
		countCorrectGuesses++;

		if (countCorrectGuesses == gameGuesses) {
			Debug.Log ("Game Ended. No more puzzles! :D");
		}
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

		gameGuesses = puzzleButtons.Count / 2;

		puzzleBackgroundImage = puzzleButtons [0].image.sprite;

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