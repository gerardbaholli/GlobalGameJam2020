using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPopup : MonoBehaviour
{
    public delegate void ButtonPressedHandler(int buttonIndex);

    public bool IsOpen => gameObject.activeSelf;

    public static UIPopup Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI text;

    [SerializeField] private Button[] buttons;

    private ButtonPressedHandler buttonPressedCallback;

    private bool wereCursorsHidden;

    protected void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    protected void OnEnable()
    {
        if (buttons != null)
        {
            foreach (Button button in buttons)
            {
                if (button != null)
                {
                    button.onClick.AddListener(() => OnButtonPressed(button));
                }
            }
        }
    }

    protected void OnDisable()
    {
        if (buttons != null)
        {
            foreach (Button button in buttons)
            {
                if (button != null)
                {
                    button.onClick.RemoveAllListeners();
                }
            }
        }
    }

    private void OnButtonPressed(Button b)
    {
        if (buttons != null)
        {
            foreach (Button button in buttons)
            {
                button.interactable = false;
            }

            for (int i = 0; i < buttons.Length; i++)
            {
                if (buttons[i].gameObject.Equals(b.gameObject))
                {
                    buttonPressedCallback?.Invoke(i);
                }
            }
        }
    }

    public void Show(string message, ButtonPressedHandler buttonPressedCallback, params string[] buttonTexts)
    {
        if (text != null)
        {
            text.text = message;
        }

        this.buttonPressedCallback = buttonPressedCallback;
        gameObject.SetActive(true);

        if (buttonTexts != null)
        {
            for (int i = 0; i < this.buttons.Length; i++)
            {
                Button button = this.buttons[i];

                if (button != null)
                {
                    if (i < buttonTexts.Length)
                    {
                        button.gameObject.SetActive(true);
                        button.interactable = true;

                        var textComponents = button.GetComponentsInChildren<TextMeshProUGUI>();
                        if (textComponents.Length > 0)
                        {
                            var t = textComponents[0];
                            t.text = buttonTexts[i];
                        }
                    }
                    else
                    {
                        button.gameObject.SetActive(false);
                        var textComponents = button.GetComponentsInChildren<TextMeshProUGUI>();
                        if (textComponents.Length > 0)
                        {
                            var t = textComponents[0];
                            t.text = string.Empty;
                        }
                    }
                }
            }
        }
    }
}