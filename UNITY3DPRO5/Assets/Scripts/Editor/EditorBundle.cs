using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class EditorBundle : MonoBehaviour {

    [MenuItem("Bundle/Build")]
    static void Build()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.None, BuildTarget.Android);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
