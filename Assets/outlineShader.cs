using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class outlineShader : MonoBehaviour
{
    public Renderer Renderer;

    float Highlighted = 0.0f;

    MaterialPropertyBlock Block;

    int HighlightActiveID;
    
    // Start is called before the first frame update
    void Start()
    {
        if(Renderer == null) Renderer = GetComponent<Renderer>();
        HighlightActiveID = Shader.PropertyToID("HighlightActive");
        Block = new MaterialPropertyBlock();
        Block.SetFloat(HighlightActiveID, Highlighted);
        Renderer.SetPropertyBlock(Block);


        // get reference to XR component
        XRGrabInteractable grab = GetComponent<XRGrabInteractable>();
        grab.hoverEntered.AddListener(HoverEnter);
        grab.hoverExited.AddListener(HoverExit);
    }
    public void HoverEnter(HoverEnterEventArgs args){
        Highlighted = 1;

        Renderer.GetPropertyBlock(Block);
        Block.SetFloat(HighlightActiveID, Highlighted);
        Renderer.SetPropertyBlock(Block);
    }

    public void HoverExit(HoverExitEventArgs args){
        Highlighted = 0;

        Renderer.GetPropertyBlock(Block);
        Block.SetFloat(HighlightActiveID, Highlighted);
        Renderer.SetPropertyBlock(Block);
    }
}
