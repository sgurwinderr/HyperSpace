using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vectrosity;

public class grd2 : MonoBehaviour
{   public Vector3 origin;
    public int gridPixels = 1000;
    private VectorLine gridLine;
    public Matrix4x4 mat;

    public Transform tf;
    public Text det;
    public InputField i1, i2, i3, i4;
    void Start()
    {
        i1.text = "1";
        i2.text = "0";
        i3.text = "0";
        i4.text = "1";
        gridLine = new VectorLine("Grid", new Vector2[0], null, 3.0f);
        gridLine.drawTransform = tf;
        gridLine.rectTransform.anchoredPosition = new Vector2(Screen.width / 2, Screen.height / 2);
        mat =Matrix4x4.identity;
        det.text = mat.determinant.ToString();
        MakeGrid();
    }

    private void Update()
    {
        //TransformGrid();
    }

    public void TransformGrid()
    {

        mat.SetRow(0, new Vector4(int.Parse(i1.text),int.Parse(i2.text),0,0));
        mat.SetRow(1, new Vector4(int.Parse(i3.text), int.Parse(i4.text), 0, 0));
        gridLine.matrix = mat;
        gridLine.Draw();
        det.text = mat.determinant.ToString();
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
        gridLine.SetColor(Color.green);
        gridLine.matrix = mat;
        gridLine.Draw();
        
    }
    public void ResetG()
    {
        i1.text = "1";
        i2.text = "0";
        i3.text = "0";
        i4.text = "1";
        mat.SetRow(0, new Vector4(1, 0, 0, 0));
        mat.SetRow(1, new Vector4(0, 1, 0, 0));
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