using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public static class JSONDeserialize {
    static string jsonFile = "ARPICO.JSON";

	[UnityEditor.MenuItem("Tools/Deserialize")]
	public static void DoStuff() {
		string json = File.ReadAllText( jsonFile );
		


    }
}
