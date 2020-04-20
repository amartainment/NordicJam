using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject SettingsMenu;

    public Slider sensitivitySlider;

    public Animator blackFadeCanvasAnim;

    private void Start()
    {
        // Fade in the main menu

        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);

        blackFadeCanvasAnim.SetTrigger("FadeIn");

        // Maybe disable the cursor and the Capsule gameobject
    }

    public void StartGame()
    {
        // Fade out the menu and start game
        StartCoroutine(FadeStartGame());
    }

    public void OpenSettings()
    {
        // Fade out main menu and fade in the settings page
        StartCoroutine(FadeOpenSettings());
    }

    public void QuitApplication()
    {
        Application.Quit();
    }
    
    public void SetQuality(int i)
    {
        // 0 = lowest, 1 = medium, 2 = highest
        QualitySettings.SetQualityLevel(i, true);
    }

    public void BackToMenu()
    {
        // Fade out from settings and fade in main menu
        StartCoroutine(FadeCloseSettings());
    }

    public void ChangeSensitivity()
    {
        // set MouseCamLook's sensitivity to x * sensitivitySlider.value
        // (have a reference to its parent "Capsule" and access to it with GetComponent<>())
    }

    IEnumerator FadeOpenSettings()
    {
        blackFadeCanvasAnim.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1);

        blackFadeCanvasAnim.SetTrigger("FadeIn");

        MainMenu.SetActive(false);
        SettingsMenu.SetActive(true);
    }

    IEnumerator FadeCloseSettings()
    {
        blackFadeCanvasAnim.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1);

        blackFadeCanvasAnim.SetTrigger("FadeIn");

        MainMenu.SetActive(true);
        SettingsMenu.SetActive(false);
    }

    IEnumerator FadeStartGame()
    {
        blackFadeCanvasAnim.SetTrigger("FadeOut");

        yield return new WaitForSeconds(1);

        blackFadeCanvasAnim.SetTrigger("FadeIn");

        MainMenu.SetActive(false);

        // if cursor and capsule are disabled, enable them
    }
}
