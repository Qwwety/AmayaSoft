using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Events;

public class GetObjectsToGame : MonoBehaviour
{
    [System.Serializable]
    public class Images
    {
        public string tag;
        public List<Sprite> Image;
    }
    [SerializeField] private List<Images> ButtonsImages;
    [SerializeField] private Button[] Buttons;
    [SerializeField] private Image AnswerImage;
    [SerializeField] private UnityEvent QuestionEvent;

    private List<Sprite> AnsweredSpriters = new List<Sprite>();
    private int NextDifficulty = 3;
    private int CurrantDifficulty = 0;

    void Start()
    {
        QuestionEvent.Invoke();
        GetObjectsImage();
    }

    public void GetObjectsImage()
    {
        SetObjectsImage(ButtonsImages, Buttons);
    }

    private void SetObjectsImage(List<Images> buttonsImages, Button[] buttons)
    {
        int xcount = Random.Range(0, buttonsImages.Count);
        List<Sprite> GameImage = CopyList(buttonsImages[xcount].Image);
        Button[] ActivatedButtons = new Button[NextDifficulty];
        List<Sprite> CurrentSprites = new List<Sprite>();
        for (CurrantDifficulty = 0; CurrantDifficulty < NextDifficulty; CurrantDifficulty++)
        {
            int RandomImage = Random.Range(0, GameImage.Count);
            buttons[CurrantDifficulty].gameObject.SetActive(true);
            buttons[CurrantDifficulty].image.sprite = GameImage[RandomImage];
            CurrentSprites.Add(GameImage[RandomImage]);
            ActivatedButtons[CurrantDifficulty] = buttons[CurrantDifficulty];
            GameImage.RemoveAt(RandomImage);
        }
        CurrentSprites = GetUnAswered(CurrentSprites);
        int AnswerSpriteNum = Random.Range(0, CurrentSprites.Count);
        AnswerImage.sprite = CurrentSprites[AnswerSpriteNum];
        AnsweredSpriters.Add(AnswerImage.sprite);
        NextDifficulty = GetNewNextDifficulty();
    }


    private List<Sprite> GetUnAswered(List<Sprite> Bibas)
    {
        foreach (var B in Bibas.ToList())
        {
            if (AnsweredSpriters.Contains(B))
            {
                Bibas.Remove(B);
            }
        }
        return Bibas;

    }
    private List<T> CopyList<T>(List<T> ListT)
    {
        List<T> NewListT = new List<T>();
        foreach (var SingleT in ListT)
        {
            NewListT.Add(SingleT);
        }
        return NewListT;
    }
    private int GetNewNextDifficulty()
    {
        switch (NextDifficulty)
        {
            case 3:
                return 6;
            case 6:
                return 9;
        }
        return 9;
    }
}
