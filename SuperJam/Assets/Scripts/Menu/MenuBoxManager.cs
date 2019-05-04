﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBoxManager : MonoBehaviour
{
    #region Public
    public BoxColor color = BoxColor.RED;
    #endregion

    #region Private
    BoxState _currentState = BoxState.NOTPICKED;
    MenuManager _gm;
    int numberOfTimes = 0;
    #endregion

    #region MonoBehaviour
    void Update()
    {
        Control();
    }

    void Start()
    {
        StartCoroutine("DeleteTime");
        GameObject g = GameObject.FindWithTag("GameManager");
        _gm = g.GetComponent<MenuManager>();
        SetColor(_gm.RandomBoxColor());
    }
    #endregion

    #region Methods
    void Control()
    {
        switch (_currentState)
        {
            case BoxState.NOTPICKED:
                
                break;
            case BoxState.PICKED:
                StopAllCoroutines();
                break;
            default:
                Debug.LogWarning("This state does not exist for BoxManager!");
                break;
        }
    }

    /// <summary>
    /// Gets the state.
    /// </summary>
    /// <returns>The state.</returns>
    public BoxState GetState()
    {
        return _currentState;
    }

    public void SetPicked()
    {
        _currentState = BoxState.PICKED;
    }

    public void SetColor(BoxColor c)
    {
        color = c;
        GetComponent<MeshRenderer>().materials[0].color = _gm.colors[(int)c];
    }
    
    IEnumerator DeleteTime()
    {
        while(true)
        {
            Debug.Log("??");
            if (numberOfTimes <= 0)
            {
                numberOfTimes++;
            }
            else
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(20.0f);
        }
    }
    #endregion
}