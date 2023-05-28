using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour {
    private string turn = "player";
    private PlayerTurnState turnState = PlayerTurnState.CHOOSING_ACTION;

    private int selectedIcon = 0;
    private GameObject[] icons = new GameObject[4];

    void Awake() {
        for (int i = 0; i < transform.childCount; i++) {
            icons[i] = transform.GetChild(i).gameObject;
        }
        UpdateColorOfAction();
    }

    void Update() {
        if (turn == "player") {
            handlePlayerTurn();
        }
    }

    private void handlePlayerTurn() {
        if (this.IsTurnState(PlayerTurnState.CHOOSING_ACTION)) {
            chooseAction();
        } 
        else {
            if (Input.GetKeyDown(KeyCode.X)) {
                this.SetTurnState(PlayerTurnState.CHOOSING_ACTION);
                UpdateIconActivetivity();
            }
        }
    }

    private void chooseAction() {
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            selectedIcon = Math.Min(3, selectedIcon + 1);
            UpdateColorOfAction();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            selectedIcon = Math.Max(0, selectedIcon - 1);
            UpdateColorOfAction();
        }
        if (Input.GetKeyDown(KeyCode.Z)) {
            switch (selectedIcon) {
                case 0: SetTurnState(PlayerTurnState.FIGHT_MENU); break;
                case 1: SetTurnState(PlayerTurnState.ACT_MENU); break;
                case 2: SetTurnState(PlayerTurnState.ITEM_MENU); break;
                case 3: FinalizeAction("defend"); break;
            }
            UpdateIconActivetivity();
        }
    }
    private void UpdateIconActivetivity()
    {
        foreach (GameObject icon in icons)
        {
            icon.SetActive(this.IsTurnState(PlayerTurnState.CHOOSING_ACTION));
        }
    }

    private void UpdateColorOfAction()
    {
        foreach (GameObject icon in icons)
        {
            if (icon == icons[selectedIcon])
            {
                icon.GetComponent<SpriteRenderer>().color = new Color32(255, 200, 0, 255);
            }
            else
            {
                icon.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            }
        }
    }
    
    private void FinalizeAction(string action) {
        FinalizeAction(action, null);
    }

    private void FinalizeAction(string action, GameObject playerAction) {

    }

    public bool IsTurnState(PlayerTurnState state) {
        return this.turnState == state;
    }

    public PlayerTurnState GetTurnState() {
        return this.turnState;
    }

    public void SetTurnState(PlayerTurnState turnState) {
        this.turnState = turnState;
    }

    public enum PlayerTurnState {
        CHOOSING_ACTION,
        FIGHT_MENU,
        ACT_MENU,
        ITEM_MENU,
        FINALIZING,
        FINALIZED
    }
}
