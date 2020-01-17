using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class BuildingDebugRender : MonoBehaviour {
	List<Building> buildings;

    void OnEnable() {
        buildings = JSONDeserialize.DoStuff();
    }

    void Update() {
		for(int i = 0; i < buildings.Count; i++) {
			var points = buildings[i].points;

			for(int p = 0; p < points.Count - 1; p++) {
				int iNext = p + 1;
				if(iNext == points.Count)
					iNext = 0;
				var start = new Vector3(points[p].x, 0, points[p].y)*-4.0f;
				var end = new Vector3(points[iNext].x, 0, points[iNext].y)*-4.0f;
				Debug.DrawLine(start, end, Color.cyan, 0, false);
			}
		}
	}
}
