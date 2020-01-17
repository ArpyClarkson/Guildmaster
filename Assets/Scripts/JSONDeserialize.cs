using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Building {
	public List<Vector2> points = new List<Vector2>();
}

public static class JSONDeserialize {
    static string jsonFile = "ARPICO.JSON";

	[UnityEditor.MenuItem("Tools/Deserialize")]
	public static List<Building> DoStuff() {
		string json = File.ReadAllText( jsonFile );

		dynamic root = SimpleJson.SimpleJson.DeserializeObject(json);
		var buildings = new List<Building>();

		foreach(var buildingData in root["features"][4]["geometry"]["coordinates"]) {
			var building = new Building();
			buildings.Add(building);

			foreach(var pointData in buildingData[0]) {
				building.points.Add(new Vector2{ x = (float)(pointData[0]*10000.0), y = (float)(pointData[1]*10000.0) });
			}
		}

		return buildings;
    }
}
