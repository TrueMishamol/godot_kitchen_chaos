using Godot;

[GlobalClass]
public partial class KitchenObjectResource : Resource {

	[Export] public string _Name;
	[Export(PropertyHint.File, "*.tscn,*.scn")] public string _SceneFilePath;
	[Export] public Texture2D _Sprite;

}
