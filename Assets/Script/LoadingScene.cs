using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{
    public Slider progressBar;
    public static LoadingScene instance;
    private void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
    }
    public void load(int level)
    {
        progressBar.transform.parent.gameObject.SetActive(true);
        StartCoroutine(startLoading(level));
    }

    IEnumerator startLoading(int level)
    {
        yield return new WaitForSeconds(0.5f);

        AsyncOperation asycn = SceneManager.LoadSceneAsync(level);
        while (!asycn.isDone)
        {
            progressBar.value = asycn.progress;

            yield return null;
        }
        progressBar.transform.parent.gameObject.SetActive(false);

    }
    //private const string LOADING_LEVEL_KEY = "Loading Level";

    //private static AsyncOperation operation;

    //public float delayBefore = 0.5f;

    //public float delayAfter = 0.5f;

    //private float currentProgress = 0f;

    //private bool finishing = false;

    //private void Start()
    //{
    //	Invoke("StartLoadScene", delayBefore);
    //}

    //private void StartLoadScene()
    //{
    //	StartCoroutine(LoadScene());
    //}

    //private IEnumerator LoadScene()
    //{
    //	// Finish load scene if there is no level index assigned.
    //	if (!PlayerPrefs.HasKey(LOADING_LEVEL_KEY)) yield break;

    //	// Get level index from player preferences.
    //	int levelIndex = PlayerPrefs.GetInt(LOADING_LEVEL_KEY);

    //	// Remove key. We don't need it anymore.
    //	PlayerPrefs.DeleteKey(LOADING_LEVEL_KEY);

    //	// Start load scene.
    //	operation = Application.LoadLevelAsync(levelIndex);

    //	// Mark that scene should not be activated by itself. We will handle it.
    //	operation.allowSceneActivation = false;

    //	// Update current progress for GUI display.
    //	currentProgress = operation.progress;

    //	yield return operation;
    //}

    //private void Update()
    //{
    //	if (operation == null) return;
    //	if (finishing) return;

    //	if (operation.progress >= 0.9f)
    //	{
    //		currentProgress = 1.0f;
    //		Invoke("ActivateScene", delayAfter);
    //		finishing = true;
    //	}
    //}

    //private void ActivateScene()
    //{
    //	operation.allowSceneActivation = true;
    //}

    //public static void LoadLevel(int index)
    //{
    //	//PlayerPrefs.SetInt(LOADING_LEVEL_INDEX, index);

    //	// Load scene name "Loading" which contains of object with SceneManager componenet.
    //	// SceneManager.Start() will triggered.
    //	Application.LoadLevel("Loading");
    //}

    //// For debug purpose.
    //// OnGUI() could make an error. Please kindly remove this method if it doesn't work.
    //// In Unity 5.x, this method is deprecated.
    //private void OnGUI()
    //{
    //	if (operation == null) return;

    //	Rect position = new Rect(10f, 10f, Screen.width - 20f, 100f);
    //	GUI.Label(position, "Progress: " + currentProgress);
    //}

}
