using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCycle : MonoBehaviour
{
    [Header("Objeto de Luz")]
    public Light mainLight;
    [Header("Intensidades da Luz")]
    public float dayIntensity = 3f;
    public float nightIntensity = 0.6f;
    [Header("Dura��o Dia/Noite")]
    public float dayDuration;
    public float nightDuration;
    bool day = true;

    //Acessar a luz principal -> Pegar a vari�vel de Intensity -> animar a vari�vel de "dia" pra "noite"
    //Upgrade: realizar o mesmo processo na luz secund�ria

    void Start()
    {
        //inicializa como dia -> e come�a a ficar de noite -> volta a ser dia -> repete
    }
    void Update()
    {

    }
    
}