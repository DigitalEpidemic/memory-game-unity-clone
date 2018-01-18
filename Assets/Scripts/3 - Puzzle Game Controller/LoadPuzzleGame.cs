using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadPuzzleGame : MonoBehaviour {

	[SerializeField]
	private GameObject puzzleLevelSelectPanel;

	[SerializeField]
	private Animator puzzleLevelSelectAnim;

	[SerializeField]
	private GameObject puzzleGamePanel1, puzzleGamePanel2, puzzleGamePanel3, puzzleGamePanel4, puzzleGamePanel5;

	[SerializeField]
	private Animator puzzleGamePanelAnim1, puzzleGamePanelAnim2, puzzleGamePanelAnim3, puzzleGamePanelAnim4, puzzleGamePanelAnim5;

	public void LoadPuzzle (int level, string puzzle) {
	}

} // LoadPuzzleGame