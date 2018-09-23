using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class identifyCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Canvas[] lcCanvases = gameObject.GetComponents<Canvas>();
		Canvas lcCanvas = lcCanvases [0];
		string lcName = lcCanvas.name;

		// Do we ned to check if we already have this name?
		if (GameManager.instance != null) {
            if (GameManager.instance.Canvases.ContainsKey(lcName) == false)
            {
                GameManager.instance.Canvases.Add(lcName, lcCanvas);
                Debug.Log("I added a canvas " + lcName);
            }
			
		} else {
			Debug.Log ("Canvas " + lcName + " not added");
		}
	}

}
