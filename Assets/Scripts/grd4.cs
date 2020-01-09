using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vectrosity;

public class grd4 : MonoBehaviour
{   public Vector3 origin;
    public int gridPixels = 1000;
    private VectorLine gridLine;
    public Matrix4x4 mat;

    public Transform tf;
    public Text det;
    public InputField []matin;
    void Start()
    {
        Resetmat();
        gridLine = new VectorLine("Grid", new Vector2[0], null, 3.0f);
        gridLine.drawTransform = tf;
        gridLine.rectTransform.anchoredPosition = new Vector2(Screen.width / 2, Screen.height / 2);
        mat =Matrix4x4.identity;
        MakeGrid();
        det.text = mat.determinant.ToString();
    }

    private void Update()
    {
        //TransformGrid();
    }

    public void TransformGrid()
    {

        mat.SetRow(0, new Vector4(int.Parse(matin[0].text),int.Parse(matin[1].text), int.Parse(matin[2].text), int.Parse(matin[3].text)));
        mat.SetRow(1, new Vector4(int.Parse(matin[4].text),int.Parse(matin[5].text), int.Parse(matin[6].text), int.Parse(matin[7].text)));
        mat.SetRow(2, new Vector4(int.Parse(matin[8].text),int.Parse(matin[9].text), int.Parse(matin[10].text), int.Parse(matin[11].text)));
        mat.SetRow(3, new Vector4(int.Parse(matin[12].text),int.Parse(matin[13].text), int.Parse(matin[14].text), int.Parse(matin[15].text)));

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
        Resetmat();
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
    public void Resetmat()
    {
        matin[0].text = "1";
        matin[1].text = "0";
        matin[2].text = "0";
        matin[3].text = "0";
        matin[4].text = "0";
        matin[5].text = "1";
        matin[6].text = "0";
        matin[7].text = "0";
        matin[8].text = "0";
        matin[9].text = "0";
        matin[10].text = "1";
        matin[11].text = "0";
        matin[12].text = "0";
        matin[13].text = "0";
        matin[14].text = "0";
        matin[15].text = "1";
    }
}