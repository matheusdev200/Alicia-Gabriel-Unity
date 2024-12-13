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
    [Header("Duração Dia/Noite")]
    public float dayDuration;
    public float nightDuration;
    bool day = true;

    //Acessar a luz principal -> Pegar a variável de Intensity -> animar a variável de "dia" pra "noite"
    //Upgrade: realizar o mesmo processo na luz secundária

    void Start()
    {
        //inicializa como dia -> e começa a ficar de noite -> volta a ser dia -> repete
    }
    void Update()
    {

    }
    
}