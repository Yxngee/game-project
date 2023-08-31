using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private Button level1Button;
    private Button level2Button;
    private Button menuButton;
    private Button resumeButton;
    private Button instructionsButton;
    private Button sourceCodeButton;
    private Slider volumeSlider;
    public float volume;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        UIDocument uiDocument = GetComponent<UIDocument>();
        SetupMenu(uiDocument);
    }

    private void SetupMenu(UIDocument uiDocument)
    {
        level1Button = uiDocument.rootVisualElement.Q("Level1Button") as Button;
        level2Button = uiDocument.rootVisualElement.Q("Level2Button") as Button;
        menuButton = uiDocument.rootVisualElement.Q("MenuButton") as Button;
        resumeButton = uiDocument.rootVisualElement.Q("ResumeButton") as Button;
        instructionsButton = uiDocument.rootVisualElement.Q("InstructionsButton") as Button;
        sourceCodeButton = uiDocument.rootVisualElement.Q("SourceButton") as Button;
        volumeSlider = uiDocument.rootVisualElement.Q("VolumeSlider") as Slider;

        if (level1Button != null)
        {
            level1Button.RegisterCallback<ClickEvent, string>(LevelChange, "Level 1");
        }
        if (level2Button != null)
        {
            level2Button.RegisterCallback<ClickEvent, string>(LevelChange, "Level 2");
        }
        if (menuButton != null)
        {
            menuButton.RegisterCallback<ClickEvent, string>(LevelChange, "Level 0");
        }
        if (resumeButton != null)
        {
            resumeButton.RegisterCallback<ClickEvent>(c => { this.enabled = false; });
        }
        if (volumeSlider != null)
        {
            volume = volumeSlider.value;
            volumeSlider.RegisterValueChangedCallback(v => { volume = v.newValue; });
        }
    }

    private void LevelChange(ClickEvent evt, string level)
    {
        SceneManager.LoadScene(level);
    }
}
