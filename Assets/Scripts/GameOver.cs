using System.Collections;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{

    public GameObject screenParent;
    public GameObject scoreParent;
    public GameObject backButton;
    public TextMeshProUGUI loseText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI doneText;

    public UnityEngine.UI.Image[] stars;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        screenParent.SetActive(false);

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowLose()
    {
        screenParent.SetActive(true);
        scoreParent.SetActive(false);
        backButton.SetActive(false);

        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            animator.Play("GameOverShow");
        }
    }

    public void ShowWin(int score, int starCount)
    {
        screenParent.SetActive(true);
        loseText.enabled = false;
        backButton.SetActive(false);

        scoreText.text = score.ToString();
        scoreText.enabled = false;

        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            animator.Play("GameOverShow");
        }


        StartCoroutine(ShowWinCoroutine(starCount));
    }

    private IEnumerator ShowWinCoroutine(int starCount)
    {
        yield return new WaitForSeconds(0.5f);

        if (starCount < stars.Length)
        {
            for (int i = 0; i <= starCount; i++)
            {
                stars[i].enabled = true;

                if (i > 0)
                {
                    stars[i - 1].enabled = false;
                }

                yield return new WaitForSeconds(0.5f);
            }
        }

        scoreText.enabled = true;
    }

    public void OnReplayClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void OnDoneClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("LevelSelect");
    }

    public void ShowBack()
    { 
        screenParent.SetActive(true);
        scoreParent.SetActive(false);
        backButton.SetActive(false);
        loseText.text = "Return to level select";
        doneText.text = "back";

        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            animator.Play("GameOverShow");
        }
    }
}
