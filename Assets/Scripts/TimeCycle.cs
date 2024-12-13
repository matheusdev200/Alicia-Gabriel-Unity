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
    public float dayDuration; //todos os tempos s�o em segundos
    public float nightDuration;
    private bool isDay = true;
    [Header("Curvas")]
    public AnimationCurve dayCurve;
    public AnimationCurve nightCurve;

    //Acessar a luz principal -> Pegar a vari�vel de Intensity -> animar a vari�vel de "dia" pra "noite"
    //Upgrade: realizar o mesmo processo na luz secund�ria,
    //alterar um pouco as cores das luzes conforme anoitece/amanhece

    void Start()
    {
        //inicializa como dia -> e come�a a ficar de noite -> volta a ser dia -> repete
        StartCoroutine(DayCycle());
    }
    IEnumerator DayCycle()
    {
        float currentTime = 0f;
        while (isDay)//enquanto dia for true
        {
            //toda porcentagem -> � uma fra��o
            //toda fra��o (em porcentagem) � a parte / todo
            currentTime += Time.deltaTime;
            mainLight.intensity = Mathf.Lerp(dayIntensity, nightIntensity,
                dayCurve.Evaluate(currentTime / dayDuration));
            //mainLight.color = Color.Lerp();
            //secondaryLight.intensity = Mathf.Lerp(dayIntensity, nightIntensity, currentTime / dayDuration);
            //interpola��o linear
            if (currentTime >= dayDuration)//se passou todo o tempo do dia, acabou o dia
            {
                isDay = false;
                yield return null;
            }
            yield return null;
        }
        if (isDay == false)
        {
            StartCoroutine(NightCycle());
        }
    }
    IEnumerator NightCycle()
    {
        float currentTime = 0f;
        while (!isDay)//enquanto dia for false
        {
            //toda porcentagem -> � uma fra��o
            //toda fra��o (em porcentagem) � a parte / todo
            currentTime += Time.deltaTime;
            mainLight.intensity = Mathf.Lerp(nightIntensity, dayIntensity,
                nightCurve.Evaluate(currentTime / nightDuration));
            //interpola��o linear
            if (currentTime >= nightDuration)//se passou todo o tempo do dia, acabou o dia
            {
                isDay = true;
                yield return null;
            }
            yield return null;
        }
        if (isDay == true)
        {
            StartCoroutine(DayCycle());
        }
    }
}