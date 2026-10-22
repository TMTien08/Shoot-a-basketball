
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private float timePlay = 40f;

    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI TimeText;

    public Button StartButon;
    public Button RestartButton;

    public CountScore countScore;

    public bool isGameActive = false;

    void Start()
    {
        if (countScore == null)
        {
            countScore = GetComponent<CountScore>();
        }

        StartButon.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(false);

        UpdateUI();
    }

    void Update()
    {
        if (!isGameActive) return;

        timePlay -= Time.deltaTime;

        if (timePlay <= 0)
        {
            timePlay = 0;
            isGameActive = false;
            RestartButton.gameObject.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (countScore != null)
        {
            ScoreText.text = $"Score: {countScore.score}";
        }

        TimeText.text = $"Time: {Mathf.CeilToInt(timePlay)}";
    }

    public void Restart()
    {
        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }

    public void StartNew()
    {
        isGameActive = true;
        StartButon.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
