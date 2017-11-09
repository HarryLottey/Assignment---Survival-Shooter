using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public Texture2D revolverIcon;
    public Texture2D crossbowIcon;
    public Texture2D qIcon; // Tells the user what key to press to swap guns
    public Texture2D eIcon; // Interactable Objects Prompt
    public Texture2D gradientIcon;
    public Texture2D healthBar;

    // Use this for initialization
    void Start()
    {
        revolverIcon = Resources.Load("/Icons/RevolverIcon") as Texture2D;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;



    }
}
