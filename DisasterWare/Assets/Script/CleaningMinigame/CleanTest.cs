using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CleanTest : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Texture2D _dirtMaskBase;
    [SerializeField] private Texture2D _brush;
    [SerializeField] private Material _material;
    [SerializeField] private TextMeshProUGUI uiText;

    private float dirtAmountTotal;
    private float dirtAmount;

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
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                Vector2 textureCoord = hit.textureCoord;

                int pixelX = (int)(textureCoord.x * _templateDirtMask.width);
                int pixelY = (int)(textureCoord.y * _templateDirtMask.height);

                int brushWidth = _brush.width;
                int brushHeight = _brush.height;

                int startX = pixelX - brushWidth / 2;
                int startY = pixelY - brushHeight / 2;

                for (int i = 0; i < brushWidth; i++)
                {
                    for (int j = 0; j < brushHeight; j++)
                    {
                        int targetX = startX + i;
                        int targetY = startY + j;

                        if (targetX >= 0 && targetX < _templateDirtMask.width && targetY >= 0 && targetY < _templateDirtMask.height)
                        {
                            UnityEngine.Color pixelDirt = _brush.GetPixel(i, j);
                            UnityEngine.Color pixelDirtMask = _templateDirtMask.GetPixel(targetX, targetY);

                            float removedAmount = pixelDirtMask.g - (pixelDirtMask.g * pixelDirt.g);
                            dirtAmount -= removedAmount;

                            _templateDirtMask.SetPixel(targetX, targetY,
                                new UnityEngine.Color(0, pixelDirtMask.g * pixelDirt.g, 0));
                        }
                    }
                }

                _templateDirtMask.Apply();
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
