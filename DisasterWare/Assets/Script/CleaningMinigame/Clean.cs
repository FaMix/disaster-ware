using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Clean : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Texture2D _dirtMaskBase;
    [SerializeField] private Texture2D _brush;
    [SerializeField] private Material _material;
    [SerializeField] private TextMeshProUGUI uiText;

    private float dirtAmountTotal;
    private float dirtAmount;
    private int bigBrushX = 0;
    private int bigBrushY = -20;

    private Texture2D _templateDirtMask;

    private void CreateTexture()
    {
        this._templateDirtMask = new Texture2D(_dirtMaskBase.width, _dirtMaskBase.height);
        this._templateDirtMask.SetPixels(_dirtMaskBase.GetPixels());
        this._templateDirtMask.Apply();

        this._material.SetTexture("_MaskTexture", _templateDirtMask);
    }

    // Start is called before the first frame update
    void Start()
    {

        this.CreateTexture();

        dirtAmountTotal = 0f;
        for (int x = 0; x < _dirtMaskBase.width; x++)
        {
            for (int y = 0; y < _dirtMaskBase.height; y++)
            {
                dirtAmountTotal += _dirtMaskBase.GetPixel(x, y).g;
            }
        }
        dirtAmount = dirtAmountTotal;
        //InvokeRepeating("DirtPercent", 0.5f, 3);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(GetDirtAmount());

        if (Input.GetMouseButton(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),out RaycastHit hit))
            {
                Vector2 textureCoord = hit.textureCoord;

                int pixelX = (int)(textureCoord.x * _templateDirtMask.width);
                int pixelY = (int)(textureCoord.y * _templateDirtMask.height);

                for (int i = 0; i < this._brush.width; i++)
                {
                    for (int j = 0; j < this._brush.height; j++)
                    {
                        UnityEngine.Color pixelDirt = this._brush.GetPixel(i, j);
                        UnityEngine.Color pixelDirtMask = this._templateDirtMask.GetPixel(pixelX+i, pixelY+j);

                        float removedAmount = pixelDirtMask.g - (pixelDirtMask.g * pixelDirt.g);
                        dirtAmount -= removedAmount;
                        
                        this._templateDirtMask.SetPixel(pixelX + i, pixelY + j,
                            new UnityEngine.Color(0, pixelDirtMask.g * pixelDirt.g, 0));
                    }
                }

                this._templateDirtMask.Apply();
            }
        }
    }

    public float GetDirtAmount()
    {
        return this.dirtAmount / dirtAmountTotal;
    }

    private void DirtPercent()
    {
        uiText.text = Mathf.RoundToInt(GetDirtAmount() * 100f) + "%";
    }
}
