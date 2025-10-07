using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneLoader : MonoBehaviour
{
    public TextMeshProUGUI sceneUI;

    public TextMeshProUGUI gameManagerCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (!SceneManager.GetSceneByName("PersistentScene").isLoaded)
        {
            Debug.Log("Loading scene to persistent scene");
            SceneManager.LoadScene("PersistentScene", LoadSceneMode.Additive);
            Debug.Log(SceneManager.GetActiveScene());
        }
    }

    // Update is called once per frame
    void Update()
    {
        sceneUI.text = SceneManager.GetActiveScene().name;
        if (GameManager.Instance != null) 
        {
            gameManagerCount.text = $"GM Count: {GameManager.Instance.GetManagerCount().ToString()}";
        }
        
    }
}
