using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Load_Models : MonoBehaviour {

    public Dropdown dropdown1;
    public Dropdown dropdown2;
    public Material smaterial;
    public Material cmaterial;
    public Material tmaterial;

    List<string> m_DropOptions2 = new List<string> { "...","Cos x+y", "Cosx+Cosy", "Cos x-y", "Cosx-Cosy", "Cos x*y", "Cosx*Cosy", "Cos x/y ", "Cosx/Cosy", "Cos 2x", "2 * Cosx", "Cos x/2", "(Cosx) /2", "Cosx^2", "(Cosx) ^2" };
    List<string> m_DropOptions1 = new List<string> { "...","Sin x+y", "Sinx+Siny", "Sin x-y", "Sinx-Siny", "Sin x*y", "Sinx*Siny", "Sin x/y ", "Sinx/Siny", "Sin 2x", "2 * Sinx", "Sin x/2", "(Sinx) /2", "Sinx^2", "(Sinx) ^2" };
    List<string> m_DropOptions3 = new List<string> {"...", "Tan x+y", "Tanx+Tany", "Tan x-y", "Tanx-Tany", "Tan x*y", "Tanx*Tany", "Tan x/y ", "Tanx/Tany", "Tan 2x", "2 * Tanx", "Tan x/2", "(Tanx) /2", "Tanx^2", "(Tanx) ^2" };
    List<string> drop1Options = new List<string> { "...","Sine", "Cosine", "Tangent" };
    public GameObject[] sineModels;
    public GameObject[] cosModels;
    public GameObject[] tanModels;
    GameObject go;

    public void Start()
    {
        dropdown1.ClearOptions();
        dropdown2.ClearOptions();
        dropdown1.AddOptions(drop1Options);
        sineModels = Resources.LoadAll<GameObject>("Sine");
        cosModels = Resources.LoadAll<GameObject>("Cosine");
        tanModels = Resources.LoadAll<GameObject>("Tangent");
    }

    public void onSetDrop1()
    {
        dropdown2.ClearOptions();
        switch (dropdown1.value)
        {
            case 1: dropdown2.AddOptions(m_DropOptions1); break;
            case 2: dropdown2.AddOptions(m_DropOptions2); break;
            case 3: dropdown2.AddOptions(m_DropOptions3); break;
        }
    }
    public void onSetDrop2()
    {
        switch (dropdown1.value)
        {
            case 1:
                foreach (Transform child in transform){
                    GameObject.Destroy(child.gameObject);
                }
                go=Instantiate(sineModels[dropdown2.value],transform.position,transform.rotation,transform);
                //go.GetComponent<Renderer>().material = smaterial;
                break;
            case 2:
                foreach (Transform child in transform){
                    GameObject.Destroy(child.gameObject);
                }
                go = Instantiate(cosModels[dropdown2.value], transform.position, transform.rotation, transform);
                //go.GetComponent<Renderer>().material = smaterial;
                break;
            case 3:
                foreach (Transform child in transform){
                    GameObject.Destroy(child.gameObject);
                }
                go=Instantiate(tanModels[dropdown2.value], transform.position, transform.rotation, transform);
                //go.GetComponent<Renderer>().material = smaterial;
                break;
        }
    }
}
