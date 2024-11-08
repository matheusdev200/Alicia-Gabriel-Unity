using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Novas Ferramentinhas", menuName = "Dados/Ferramentas", order = 0)]
public class ToolScriptable : ScriptableObject
{
    public string toolName; //nome da ferramenta pra UI (User Interface)
    public GameObject toolPrefab; //Objeto da ferramenta (que vai ter a logica do objeto)
    public bool toolUseCharges; //se o objeto gasta alguma coisa ou nao

    //public virtual void UseTool() { }
}

//[CreateAssetMenu(fileName = "Novas Plantinha", menuName = "Dados/Platinhas", order = 1)]
//public class PlantScriptable : ScriptableObject
//{
//    public string plantName; //nome da ferramenta pra UI (User Interface)
//    public GameObject smallPlant;
//    public GameObject grownPlant;
//    public GameObject elderWood;
//    public int daysToGrow; //se o objeto gasta alguma coisa ou nao
//    public virtual void PlantAttack() { }
//}