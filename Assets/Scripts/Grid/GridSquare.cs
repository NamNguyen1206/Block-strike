using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSquare : MonoBehaviour
{
    public Image hooverImage;
    public Image activeImage;
    public Image normalImage;
    public List<Sprite> normalImages;

    public bool Selected {get;set;}
    public int SquareIndex {get;set;}
    public bool SquareOccupied {get;set;}

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Selected = false;
        SquareOccupied = false;
    }

    //temp function 
    public bool CanWeUseThisSquare()
    {
        return hooverImage.gameObject.activeSelf;
    }

    public void ActivateSquare()
    {
        hooverImage.gameObject.SetActive(false);
        activeImage.gameObject.SetActive(true);
        Selected = true;
        SquareOccupied = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        hooverImage.gameObject.SetActive(true);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        hooverImage.gameObject.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        hooverImage.gameObject.SetActive(false);
    }

    public void SetImage(bool setFistImages)
    {
        normalImage.GetComponent<Image>().sprite = setFistImages ? normalImages[1] : normalImages[0];
        
    }
}
