using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanelUI : MonoBehaviour
{
  [Header("UI")]
  [SerializeField] private GameObject root;
  [SerializeField] private TextMeshProUGUI titleText;
  [SerializeField] private Button restartButton;
  [SerializeField] private Button exitButton;

  void Awake()
  {
    root.SetActive(false);

    restartButton.onClick.AddListener(OnRestartClick);

    if (exitButton != null)
      exitButton.onClick.AddListener(OnExitClick);
  }

  public void ShowWin()
  {
    root.SetActive(true);
    titleText.text = "Wins !";
    Time.timeScale = 0f;
  }

  public void ShowFail()
  {
    root.SetActive(true);
    titleText.text = "Loses !";
    Time.timeScale = 0f;
  }

  void OnRestartClick()
  {
    Time.timeScale = 1f;
    UnityEngine.SceneManagement.SceneManager
        .LoadScene(UnityEngine.SceneManagement.SceneManager
        .GetActiveScene().buildIndex);
  }

  void OnExitClick()
  {
    Time.timeScale = 1f;
    Debug.Log("Exit Game");
    // Application.Quit();
  }
}
