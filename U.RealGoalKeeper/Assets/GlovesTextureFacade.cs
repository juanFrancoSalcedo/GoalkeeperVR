using UnityEngine;

public class GlovesTextureFacade : MonoBehaviour
{
    [SerializeField] private Renderer[] renders;
    [SerializeField] private GameObject[] particlesChange;

    private readonly int MainTexId = Shader.PropertyToID("_BaseMap");

    public void SetTextureGloves(Texture2D texture)
    {
        var mpb = new MaterialPropertyBlock();
        if (renders == null)
            return;

        for (int i = 0; i < renders.Length; i++)
        {
            var render = renders[i];
            if (render == null)
                continue;
            render.GetPropertyBlock(mpb);
            mpb.SetTexture(MainTexId, texture);
            render.SetPropertyBlock(mpb);

            if (particlesChange != null && i < particlesChange.Length)
            {
                var p = particlesChange[i];
                if (p != null)
                { 
                    p.SetActive(true);
                    p.transform.position = render.transform.position + Vector3.up*0.1f;
                    p.transform.rotation = Quaternion.identity;
                }
            }
        }
    }
}
