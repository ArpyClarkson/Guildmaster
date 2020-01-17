using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using SimpleJson;

public struct Point {
	public float x, y;
}

public class Building {
	public List<Point> points = new List<Point>();
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
				building.points.Add(new Point{ x = (float)(pointData[0]*100.0), y = (float)(pointData[1]*100.0) });
			}
		}

		return buildings;
    }
}
