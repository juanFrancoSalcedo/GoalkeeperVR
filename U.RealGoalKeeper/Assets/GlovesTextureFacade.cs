using UnityEngine;

public class GlovesTextureFacade : MonoBehaviour
{
    [SerializeField] private Renderer[] renders;

    private readonly int MainTexId = Shader.PropertyToID("_BaseMap");

    public void SetTextureGloves(Texture2D texture)
    {
        var mpb = new MaterialPropertyBlock();
        foreach (var render in renders)
        {
            if (render == null)
                continue;
            // Get existing properties (to preserve other property block values)
            render.GetPropertyBlock(mpb);
            // Set or clear the main texture
            mpb.SetTexture(MainTexId, texture);
            // Apply the property block to the renderer
            render.SetPropertyBlock(mpb);
        }
    }
}
