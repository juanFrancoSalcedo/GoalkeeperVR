using B_Extensions;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTextureSetter : BaseToggleAttendant
{
    [SerializeField] private Texture2D textures;
    [SerializeField] private GlovesTextureFacade textureSetter;
    private Outline outline;

    private void Start()
    {
        toggleComponent.onValueChanged.AddListener(UpdateTexture);
        outline = GetComponent<Outline>();
        UpdateTexture(toggleComponent.isOn);
    }

    public void UpdateTexture(bool active)
    {
        if (textureSetter == null)
            return;
        textureSetter.SetTextureGloves(textures);
        ManagerAudio.Instance.PlaySelectUI();
        outline.enabled = active;
    }
}
