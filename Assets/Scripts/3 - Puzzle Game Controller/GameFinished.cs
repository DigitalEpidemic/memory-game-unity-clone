using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinished : MonoBehaviour {

	[SerializeField]
	private GameObject gameFinishedPanel;

	[SerializeField]
	private Animator gameFinishedAnim, star1Anim, star2Anim, star3Anim, textAnim;

	public void ShowGameFinishedPanel (int stars) {
		StartCoroutine (ShowPanel (stars));
	}

	public void HideGameFinishedPanel (int stars) {
		if (gameFinishedPanel.activeInHierarchy) {
			StartCoroutine (HidePanel (stars));
		}
	}

	IEnumerator ShowPanel (int stars) {
		gameFinishedPanel.SetActive (true);
		gameFinishedAnim.Play ("FadeIn");

		yield return new WaitForSeconds (1.7f);

		switch (stars) {
		case 1:
			star1Anim.Play ("FadeIn");
			yield return new WaitForSeconds (0.1f);
			textAnim.Play ("FadeIn");
			break;

		case 2:
			star1Anim.Play ("FadeIn");
			yield return new WaitForSeconds (0.25f);

			star2Anim.Play ("FadeIn");
			yield return new WaitForSeconds (0.1f);

			textAnim.Play ("FadeIn");
			break;

		case 3:
			star1Anim.Play ("FadeIn");
			yield return new WaitForSeconds (0.25f);

			star2Anim.Play ("FadeIn");
			yield return new WaitForSeconds (0.25f);

			star3Anim.Play ("FadeIn");
			yield return new WaitForSeconds (0.1f);

			textAnim.Play ("FadeIn");
			break;
		}
	}

	IEnumerator HidePanel (int stars) {
		gameFinishedAnim.Play ("FadeOut");
		textAnim.Play ("FadeOut");

		switch (stars) {
		case 1:
			star1Anim.Play ("FadeOut");
			break;
		case 2:
			star1Anim.Play ("FadeOut");
			star2Anim.Play ("FadeOut");
			break;
		case 3:
			star1Anim.Play ("FadeOut");
			star2Anim.Play ("FadeOut");
			star3Anim.Play ("FadeOut");
			break;
		}

		yield return new WaitForSeconds (1.5f);
		gameFinishedPanel.SetActive (false);
	}

} // GameFinished