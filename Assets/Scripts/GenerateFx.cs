using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateFx : MonoBehaviour {

    Mesh mesh;
    Vector3[] vertices;
    int[] triangles;
    public int xSize, zSize,choice;
    public float inOffset, outOffset,resolution=1,sqMulti;
    void Start () {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh=mesh;
        //renderer = GetComponent<Renderer>();
    }
    public void setInOff(float inOff)
    {
        inOffset = inOff;
    }
    public void setOutOff(float outOff)
    {
        outOffset = outOff;
    }
    public void setres(float res)
    {
        res = res / 10f;
        resolution = res;
    }
    public void setChoice(int inchoice)
    {
        choice = inchoice;
    }
    void Update()
    {
        UpdateMesh();
    }

    public void Wrapper()
    {
        StartCoroutine(CreateShape());
    }

    public IEnumerator CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++, i++)
            {
            float yin = 0;
            if (choice == 0)
            {
                yin = Mathf.Sin(inOffset * x) * outOffset;
            }
            else if (choice == 1)
            {
                yin = Mathf.Cos(inOffset * x) * outOffset;
            }
            else if (choice == 2)
            {
                yin = Mathf.Tan(inOffset * x) * outOffset;
            }
            else if (choice == 3)
            {
                yin = Mathf.Sqrt(x);
            }
            else if (choice == 4)
            {
                yin = x*x*sqMulti;
            }
            else if (choice == 5)
            {
                yin = x * x * x*sqMulti;
            }

            vertices[i] = new Vector3(x*resolution, yin*resolution, z*resolution);

            }
        }

        triangles = new int[xSize * zSize * 12];
        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

            triangles[tris + 6] = vert + 0;
            triangles[tris + 7] = vert + 1;
            triangles[tris + 8] = vert +xSize+ 1;
            triangles[tris + 9] = vert + 1;
            triangles[tris + 10] = vert + xSize + 2;
            triangles[tris +11] = vert + xSize + 1;

            vert++;
                tris += 12;
                yield return new WaitForSeconds(.01f);
            }
            vert++;
         
    }
    }

    public void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        //renderer.material = material;
    }

    private void OnDrawGizmos()
    {
        /*if (vertices == null)
            return;

        for(int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
        */
    }

}
