using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class obtionButton : MonoBehaviour {

    private Text m_text = null;
    private Button m_button = null;
    private Image m_imagen = null;
    private Color m_originalColor = Color.black;

    public Option Option { get; set; }

    private void Awake()
    {
        m_button = GetComponent<Button>();
        m_imagen = GetComponent<Image>();
        m_text = transform.GetChild(0).GetComponent<Text>();

        m_originalColor = m_imagen.color;
    }
    public void Construct(Option option, Action<obtionButton> callback)
    {
        m_text.text = option.text;
        m_button.onClick.RemoveAllListeners();
        m_button.enabled = true;
        m_imagen.color = m_originalColor;
        Option = option;
        m_button.onClick.AddListener(delegate
        {
            callback(this);
        });
    }

    public void SetColor(Color e)
    {
        m_button.enabled = false;
        m_imagen.color = e;
    }
}
