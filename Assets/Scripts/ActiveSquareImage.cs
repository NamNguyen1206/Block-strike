using UnityEngine;
using UnityEngine.UI;

public class ActiveSquareImage : MonoBehaviour
{
    public SquareTextureData squareTextureData;
    public bool updateImageOnRechedTreshold = false;

    private void OnEnable()
    {
        UpdateSquareColorBeseOnCurrentPoint();
        if(updateImageOnRechedTreshold)
        {
            GameEvent.UpdateSquareColor += UpdateSquareColor;
        }
    }
    
    private void OnDisable()
    {
        if(updateImageOnRechedTreshold)
        {
            GameEvent.UpdateSquareColor -= UpdateSquareColor;
        }
    }

    private void UpdateSquareColorBeseOnCurrentPoint()
    {
        foreach (var squareTexture in squareTextureData.activeSquareTextures)
        {
            if(squareTextureData.currentColor == squareTexture.squareColor)
            {
                GetComponent<Image>().sprite = squareTexture.texture;
            }
        }
    }

    private void UpdateSquareColor(Config.SquareColor color)
    {
        foreach(var squareTexture in squareTextureData.activeSquareTextures)
        {
            if(color == squareTexture.squareColor)
            {
                GetComponent<Image>().sprite = squareTexture.texture;
            }
        }
    }
}
