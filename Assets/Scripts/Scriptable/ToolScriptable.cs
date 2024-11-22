using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Novas Ferramentinhas", menuName = "Dados/Ferramentas")]
public class ToolScriptable : ScriptableObject
{
    public string toolName; //nome da ferramenta pra UI (interfase de usuario)
    public GameObject toolPrefab; // Object 
    public bool toolUseCharges;

    //public virtual void UseTool() { }
}
