using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CheckAnswer : MonoBehaviour// проверяет на правильность выбранной кнопки
{
    [SerializeField] private Image AnswerImage;
    private Button Button;
    [SerializeField] private UnityEvent CorrectAnswerEvent;
    [SerializeField] private UnityEvent BounceEffectEvent;
    [SerializeField] private UnityEvent EaseInEffect;
    [SerializeField] private UnityEvent GameScore;
    [SerializeField] private ParticleSystem StarParticle;

    private void Start()
    {
        Button = this.GetComponent<Button>();
    }
    private void OnEnable()
    {
        BounceEffectEvent.Invoke();
    }
    public void IsAnswerTure()
    {

        if (Button.image.sprite.name == AnswerImage.sprite.name)
        {

            StarParticle.Play();
        }
        else
        {
            EaseInEffect.Invoke();
        }
    }

    private void OnParticleSystemStopped()
    {
        GameScore.Invoke();
        CorrectAnswerEvent.Invoke();
    }
}

