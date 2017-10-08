﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueBoxManager : MonoBehaviour {

	public GameObject dBox;
	public Text dText;

	public void StartConvo() {
		dBox.SetActive (true);
	}

	public void SayLine(string text)
	{
        dText.text = text;
	}

	public void EndConvo() 
	{
		dBox.SetActive (false);
	}
}
