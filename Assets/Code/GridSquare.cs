using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSquare : MonoBehaviour
{
    public Image normalImage;
    public List<Sprite> normalImages;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetImage(bool setFistImages)
    {
        normalImage.GetComponent<Image>().sprite = setFistImages ? normalImages[1] : normalImages[0];
        
    }
}
