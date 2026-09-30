using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ColorButtonController : MonoBehaviour
{
    [SerializeField] private Button redButton;
    [SerializeField] private Button blueButton;
    [SerializeField] private Renderer[] targets;
    [SerializeField] private Material redMaterial;
    [SerializeField] private Material blueMaterial;
    [SerializeField] private Image panelImage;
    [SerializeField] private TMP_Text statusText;

    void Awake()
    {
        if (redButton != null)
            redButton.onClick.AddListener(SetRed);
        if (blueButton != null)
            blueButton.onClick.AddListener(SetBlue);
    }

    void OnDestroy()
    {
        if (redButton != null)
            redButton.onClick.RemoveListener(SetRed);
        if (blueButton != null)
            blueButton.onClick.RemoveListener(SetBlue);
    }

    public void SetRed()
    {
        ApplyColor(redMaterial, new Color(1f, 0.2f, 0.2f, 0.6f), "RED selected");
    }

    public void SetBlue()
    {
        ApplyColor(blueMaterial, new Color(0.2f, 0.4f, 1f, 0.6f), "BLUE selected");
    }

    void ApplyColor(Material material, Color panelColor, string message)
    {
        if (material != null && targets != null)
        {
            foreach (var target in targets)
            {
                if (target != null)
                    target.material = material;
            }
        }

        if (panelImage != null)
            panelImage.color = panelColor;

        if (statusText != null)
            statusText.text = message;

        Debug.Log(message);
    }
}
