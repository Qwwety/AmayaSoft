using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    [SerializeField] private UnityEvent FadeEffect;
    [SerializeField] private CanvasGroup CanvasGroup;

    private void Start()
    {
        FadeInEffect();
    }
    public void FadeInEffect()
    {
        FadeEffect.Invoke();
    }
    public void RestartLvL()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
