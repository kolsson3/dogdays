using UnityEngine;

//Script for appling shader effect during sniff mode.
public class NightVisionEffect : MonoBehaviour
{
    // Public data
    public Shader shader;
    [Range(0f, 1f)]
    public float luminance = 0.15f;
    [Range(0.5f, 1f)]
    public float lensRadius = 0.814f;
    // Private data
    Material material;

    // Called by Camera to apply image effect
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (shader != null)
        {
            if (!material) material = new Material(shader);
            material.SetVector("_Luminance", new Vector4(luminance, luminance, luminance, luminance));
            material.SetFloat("_LensRadius", lensRadius);
            Graphics.Blit(source, destination, material);
        }
        else Graphics.Blit(source, destination);
    }
}