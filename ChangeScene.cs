using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
  public string sceneName;
  public GameObject loadingScreen;
  public Slider loadingBar;
  public Vector3 teleportValue;
  [HideInInspector]
  public GameObject playerGameObject;

  public void NextScene() => this.StartCoroutine(this.LoadSceneAsynchronously(this.sceneName));

  private IEnumerator LoadSceneAsynchronously(string sceneName)
  {
    AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
    this.loadingScreen.SetActive(true);
    while (!operation.isDone)
    {
      this.loadingBar.value = operation.progress;
      yield return (object) null;
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (!other.CompareTag("Player"))
      return;
    this.playerGameObject = GameObject.FindGameObjectWithTag("Player");
    Object.DontDestroyOnLoad((Object) this.playerGameObject);
    SceneManager.LoadScene(this.sceneName);
    this.playerGameObject.transform.position = this.teleportValue;
  }

  public void ReloadScene() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

  public void RestartGame() => SceneManager.LoadScene(this.sceneName);

  public void QuitGame()
  {
    Application.Quit();
    Debug.Log((object) "byebye:(");
  }
}
