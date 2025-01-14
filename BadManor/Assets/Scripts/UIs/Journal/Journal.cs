﻿using Assets.Scripts;
using Assets.Scripts.UIs;
using UnityEngine;

/// <summary>
/// Journal user interface for recording notes, for prototype only hides/shows and stores the player's notes. Future 
/// plans include showing collected items and pre-wirtten notes.</summary>
public class Journal : Interface
{
    /// <summary>
    /// The parent of the whole interface.</summary>
    public Transform journal;

    private bool isShowing = false;

    public GameObject gameMenuPanel;
    public GameObject inventoryPanel;
    public GameObject profilesPanel;
    public GameObject notesPanel;
    public GameObject achPanel;
    private GameObject currentPanel;

    private Notes notesScript;
    private Achievements achScript;

    /// <summary>
    /// Enum representing the menu items.
    /// </summary>
    public enum MenuPanel
    {
        GameMenu,
        Inventory,
        Profiles,
        Notes
    }

    /// <summary>
    /// When GameMap is loaded the Journal interface is hidden.</summary>
    public void Start()
    {
        //journal.gameObject.SetActive(false);
        currentPanel = gameMenuPanel;
        SwitchPanel(0);
        notesScript = notesPanel.GetComponent<Notes>();
        achScript = achPanel.GetComponent<Achievements>();
    }

    /// <summary>
    /// Opens the journal.
    /// </summary>
    public void OpenJournal()
    {
        journal.gameObject.SetActive(true);

        SwitchPanel(0);
    }

    /// <summary>
    /// Show/hide journal from player.</summary>
    public void CloseJournal()
    {
        journal.gameObject.SetActive(false);
    }

    /// <summary>
    /// Switches to panel ID
    /// </summary>
    /// <param name="panel">Panel ID</param>
    public void SwitchPanel(int panel)
    {
        if (currentPanel != null)
        {
            Debug.Log("good!");
            currentPanel.SetActive(false);
        }

        switch (panel)
        {
            case 0:
                currentPanel = gameMenuPanel;
                break;
            case 1:
                currentPanel = inventoryPanel;
                //Inventory.UpdateItems ();
                break;
            case 2:
                currentPanel = notesPanel;
                currentPanel.SetActive(true);
                notesScript.updateNotes();

                break;
            case 3:
                currentPanel = profilesPanel;
                break;
            case 4:
                currentPanel = achPanel;
                currentPanel.SetActive(true);
                achScript.updateAchs();
                break;
        }
        currentPanel.SetActive(true);
    }

    /// <summary>
    /// Save game button hook
    /// </summary>
    public void save()
    {
        GameLoader.Inst.saveGame();
    }

    /// <summary>
    /// Quit button hook
    /// </summary>
    public void quit()
    {
        GameLoader.Inst.quitGame();
    }
}