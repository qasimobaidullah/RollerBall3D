using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject levelPausePanel;
    public string NextScene;
    public string PreviousScene;

    [Header("Loading Screen")]
    public Image LoadingBar;
    public Text loading_Text;
    public GameObject loadingPanel;
    public float loadingDelayTime = 2f; 
        public int coinCount = 0;
    public Text coinText;

public GameObject PlayerObject;
public GameObject PlayerStartingPosition;
    public void UpdateCoinUI()
    {
        coinText.text = "Coins: " + coinCount;
    }
    private void Awake() {
                if(instance==null){
            instance=this;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
            Time.timeScale=1f;
        UpdateCoinUI();

            //Levels[PlayerPrefs.GetInt("SelectedLevel")].gameObject.SetActive(true);
            PlayerObject.transform.position=PlayerStartingPosition.transform.position;

    }



    public void PauseGame(){
PlayButtonClickSound();
            Time.timeScale=0;

    levelPausePanel.SetActive(true);

    }
        public void ResumeGame(){
PlayButtonClickSound();
            Time.timeScale=1;

    levelPausePanel.SetActive(false);

    }
    public void RestartGame(){
PlayButtonClickSound();
            Time.timeScale=1;

            StartCoroutine(LoadSceneWithDelay(NextScene));

    }



    public void HomeGame(){
PlayButtonClickSound();
Time.timeScale=1;
            StartCoroutine(LoadSceneWithDelay(PreviousScene));

    }
    public void OpenGithubLink()
    {
PlayButtonClickSound();

        Application.OpenURL("https://github.com/qasimmu/RollerBall3D.git");
    }
    
        public void OpenItchio()
    {
PlayButtonClickSound();

        Application.OpenURL("https://rainbow-flamingo.itch.io/3d-roller-ball");
    }

        void UpdateLoadingUI(float progress)
    {
        if (LoadingBar) LoadingBar.fillAmount = progress;
        if (loading_Text) loading_Text.text = Mathf.RoundToInt(progress * 100) + "%";
    }
    IEnumerator LoadSceneWithDelay(string name)
    {
if(loadingDelayTime>0){
        loadingPanel.SetActive(true);

}
        float timer = 0f;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(name);
        asyncOperation.allowSceneActivation = false;
        while (timer < loadingDelayTime)
        {
            timer += Time.deltaTime;
            float fillAmount = Mathf.Clamp01(timer / loadingDelayTime);
            UpdateLoadingUI(fillAmount);
            yield return null;
        }
        yield return new WaitForSeconds(1f);

        asyncOperation.allowSceneActivation = true;

    }
    public void PlayButtonClickSound()
    {
        if (SoundManager._SoundManager)
        {
            SoundManager._SoundManager.playButtonClickSound();

        }
    }
}
