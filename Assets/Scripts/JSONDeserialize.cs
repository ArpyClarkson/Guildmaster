using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Coordinate {
    public List<object> coordinate;
}

[System.Serializable]
public class Item {
    public List<Coordinate> coordinates;
}

[System.Serializable]
public class Geometry {
    public string type;
    public List<Item> items;
}

[System.Serializable]
public class Properties {
    public string id;
}

[System.Serializable]
public class Feature {
    public string type;
    public Geometry geometry;
    public Properties properties;
}

[System.Serializable]
public class RootObject {
    public string type;
    public List<Feature> features;
}

public class JSONDeserialize : MonoBehaviour {
    string jsonfile = "ARPICO.JSON";
    RootObject obj = new RootObject();

    // Start is called before the first frame update
    void Start() {
        obj = Deserialize( jsonfile );

        Debug.LogFormat( "JSON Deserialized" );
        foreach (Feature f in obj.features) {
            Debug.LogFormat( "Feature '{0}' loaded with {1} objects", f.properties.id, f.geometry.items.Count );
        }
    }

    // Update is called once per frame
    void Update() {

    }

    public static RootObject Deserialize( string file ) {
        string json = File.ReadAllText( file );

        return JsonUtility.FromJson<RootObject>( json );
    }
}
