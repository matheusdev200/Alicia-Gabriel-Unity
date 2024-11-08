using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBehaviour : MonoBehaviour
{
    public ToolScriptable tool;
    void Start()
    {
        Instantiate(tool.toolPrefab, transform);//faz aparecer a arte da minha ferramenta la na cena

        //StartCoroutine(MoveExampleRoutine());
    }
    //IEnumerator MoveExampleRoutine() //Coroutine
    //{
    //    Debug.Log("Preparando pra mover");

    //    yield return new WaitForSeconds(1f);

    //    transform.position += transform.forward * 2f;
    //    Debug.Log("Movendo 1");
    //    yield return new WaitForSeconds(3f);

    //    //-> relógio -> replicar o relógio
    //    Debug.Log("Movendo 2");
    //    transform.position += transform.forward * 2f;
    //}
}