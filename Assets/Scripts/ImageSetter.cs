using UnityEngine;
using UnityEngine.UI;

public class ImageSetter : MonoBehaviour
{
    public Sprite BackgroundDreamStart;
    public Sprite BackgroundDreamEnd;

    public Image CanvasImage;

    private GameManager.GameStateChange DreamStartCallback;
    private GameManager.GameStateChange DreamEndCallback;
    private GameManager.GameStateChange PlayCallback;

    public void SetImageSprite(Sprite sprite)
    {
        CanvasImage.sprite = sprite;
        CanvasImage.type = Image.Type.Simple;
        CanvasImage.color = Color.white;
    }

    public void ResetImageSprite()
    {
        CanvasImage.sprite = null;
        CanvasImage.color = Color.clear;
    }

    private void Awake()
    {
        CanvasImage = GetComponent<Image>();

        DreamStartCallback = () => SetImageSprite(BackgroundDreamStart);
        DreamEndCallback = () => SetImageSprite(BackgroundDreamEnd);
        PlayCallback = () => ResetImageSprite();

        GameManager.Instance.OnDreamStart += DreamStartCallback;
        GameManager.Instance.OnPlay += PlayCallback;
        GameManager.Instance.OnDreamEnd += DreamEndCallback;
    }
}
