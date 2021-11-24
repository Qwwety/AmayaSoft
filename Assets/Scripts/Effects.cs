using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class Effects : MonoBehaviour
{

    [SerializeField] private UnityEvent CorrectAnswerEvent;
    [SerializeField] private Ease Bounce;
    [SerializeField] private Ease Ease;
    private Transform Buttons;
    private CanvasGroup CanvasGroup;


    private void BounceEffect()
    {
        Buttons = GetComponent<Transform>();
        Buttons.DOScale(1, 0);
        Buttons.DOScale(2, 1f).SetEase(Bounce);
    }
    public void FadeInEffect()
    {
      
        CanvasGroup = GetComponent<CanvasGroup>();
        CanvasGroup.DOFade(1, 1);
    }
    public void EaseInEffect()
    {
        float y = Buttons.transform.position.y;
        Buttons.DOMoveY(y, 1)
               .SetEase(Ease)
               .From(Buttons.transform.position=new Vector3(Buttons.transform.position.x, Buttons.transform.position.y-50, Buttons.transform.position.z));
        
    }
    public void OnCorect()
    {
        BounceEffect();
        
        CorrectAnswerEvent.Invoke();
    }


}
