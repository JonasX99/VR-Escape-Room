using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

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
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void HoverEnter(){
        Highlighted = 1;

        Renderer.GetPropertyBlock(Block);
        Block.SetFloat(HighlightActiveID, Highlighted);
        Renderer.SetPropertyBlock(Block);
    }

    public void HoverExit(){
        Highlighted = 0;

        Renderer.GetPropertyBlock(Block);
        Block.SetFloat(HighlightActiveID, Highlighted);
        Renderer.SetPropertyBlock(Block);
    }
}
