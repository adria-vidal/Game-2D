using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public Image ImageJump;
    public Image ImageGet;
    public Image ImageTeam;
    private int currentImage = 0;

    public Button buttonSiguiente;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadPlayScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void LoadTutorialScene()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void Exit(){
        Application.Quit();
    }

    public void OnSiguienteButtonPressed()
    {
        // Desactivar la imagen actual
        if (currentImage == 0)
        {
            ImageJump.gameObject.SetActive(false);
            // Cambiar la opacidad de la imagen siguiente
            Color currentColor = ImageGet.color;
            currentColor.a = 0.8f;
            ImageGet.color = currentColor;
            ImageGet.gameObject.SetActive(true);
        }
        else if (currentImage == 1)
        {
            ImageGet.gameObject.SetActive(false);
            // Cambiar la opacidad de la imagen siguiente
            Color currentColor = ImageTeam.color;
            currentColor.a = 0.8f;
            ImageTeam.color = currentColor;
            ImageTeam.gameObject.SetActive(true);
            buttonSiguiente.GetComponentInChildren<TextMeshProUGUI>().text = "Jugar";
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }

        // Incrementar el índice de imagen actual
        currentImage++;
    }

}
