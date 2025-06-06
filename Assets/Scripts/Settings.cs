using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] Image Image1;
    [SerializeField] Image Image2;
    [SerializeField] Image Image3;
    [SerializeField] Image Image4;
    [SerializeField] Image Image5;
    [SerializeField] Button button;
    [SerializeField] Button button1;
    [SerializeField] Button button2;
    [SerializeField] private float initialEnergy = 4f;
    [SerializeField] Image Current_Energy;

    private float currentEnergy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jugar()
    {
        currentEnergy = initialEnergy;
    }

    public void Cards()
    {
        Image1.gameObject.SetActive(true);
        Image2.gameObject.SetActive(true);
        Image3.gameObject.SetActive(true);
        Image4.gameObject.SetActive(true);
        Image5.gameObject.SetActive(true);
        button2.gameObject.SetActive(true);
        button1.gameObject.SetActive(false);
        button.gameObject.SetActive(false);
    }

    public void Close_Cards()
    {
        Image1.gameObject.SetActive(false);
        Image2.gameObject.SetActive(false);
        Image3.gameObject.SetActive(false);
        Image4.gameObject.SetActive(false);
        Image5.gameObject.SetActive(false);
        button2.gameObject.SetActive(false);
        button1.gameObject.SetActive(true);
        button.gameObject.SetActive(true);
    }

    public void Energy()
    {
        currentEnergy -= 1f;
        var energyRatio = currentEnergy / initialEnergy;
        Debug.Log(energyRatio);
        Current_Energy.fillAmount = energyRatio;
    }

    public void ReturnMap()
    {
        SceneManager.LoadScene(1);
    }
}
