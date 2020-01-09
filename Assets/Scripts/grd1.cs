using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Vectrosity;

public class grd1 : MonoBehaviour
{
    public int gridPixels = 1000;
    private VectorLine gridLine;
    public Matrix4x4 mat;

    public Transform tf;
    void Start()
    {
        gridLine = new VectorLine("Grid", new Vector2[0], null, 1.0f);
        gridLine.drawTransform = tf;
        gridLine.rectTransform.anchoredPosition = new Vector2(Screen.width / 2, Screen.height / 2);
        mat=Matrix4x4.identity;
        MakeGrid();
    }

    private void Update()
    {
        TransformGrid();
    }

    private void TransformGrid()
    {
        gridLine.matrix = mat;
        gridLine.Draw();
    }

    void MakeGrid()
    {
        //int numberOfGridPoints = ((Screen.width / gridPixels + 1) + (Screen.height / gridPixels + 1)) * 2;
        int numberOfGridPoints = (1601 + 1601) * 2;
        gridLine.Resize(numberOfGridPoints);
        //gridLine.drawTransform = tf;
        int w = -(Screen.width / 2);
        int index = 0;
        /*
        for (int x = 0; x < Screen.width; x += gridPixels)
        {
            gridLine.points2[index++] = new Vector2(x, 0);
            gridLine.points2[index++] = new Vector2(x, Screen.height - 1);
        }
        */
        for (int x = -800; x < 801; x += gridPixels)
        {
            gridLine.points2[index++] = new Vector2(x, -800f);
            gridLine.points2[index++] = new Vector2(x, 801f);
        }


        int h = -(Screen.height / 2);
        /*for (int y = 0; y < Screen.height; y += gridPixels)
        {
            gridLine.points2[index++] = new Vector2(0, y);
            gridLine.points2[index++] = new Vector2(Screen.width - 1, y);
        }*/
        for (int y = -800; y < 801; y += gridPixels)
        {
            gridLine.points2[index++] = new Vector2(-800f, y);
            gridLine.points2[index++] = new Vector2(801f, y);
        }
        
        gridLine.matrix = mat;
        gridLine.Draw();
    }
    private bool ValidateInput(Vector4[] points)
    {
        return points != null;
    }
    public void ClearGrid()
    {
        VectorLine.Destroy(ref gridLine);
    }
}