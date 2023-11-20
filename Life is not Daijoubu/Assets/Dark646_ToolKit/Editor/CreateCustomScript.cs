using UnityEditor;

public class CreateCustomScript
{
    private const string path = "Assets/Dark646_Toolkit/ScriptTemplates/";

    #region UI Scripts

    //Pause Menu
    private const string PauseMenu = "PauseMenuTemplate.cs.txt";

    [MenuItem(itemName: "Assets/Create/C# UI Script/Pause Menu", isValidateFunction: false, priority = 50)]
    public static void CreatePauseMenuFromTemplate()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path + PauseMenu, "NewPauseMenu.cs");
    }


    //MainMenu
    private const string MainMenu = "MainMenuTemplate.cs.txt";

    [MenuItem(itemName: "Assets/Create/C# UI Script/Main Menu", isValidateFunction: false, priority = 50)]
    public static void CreateMainMenuFromTemplate()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path + MainMenu, "NewMainMenu.cs");
    }


    //SettingsMenu
    private const string SettingsMenu = "SettingsMenuTemplate.cs.txt";

    [MenuItem(itemName: "Assets/Create/C# UI Script/Settings Menu", isValidateFunction: false, priority = 50)]
    public static void CreateSettingsMenuFromTemplate()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path + SettingsMenu, "NewSettingsMenu.cs");
    }

    #endregion

    #region Logic Script

    //ScriptableObject
    private const string ScriptableObject = "ScriptableObjectTemplate.cs.txt";

    [MenuItem(itemName: "Assets/Create/C# Logic Script/Scriptable Object", isValidateFunction: false, priority = 50)]
    public static void CreateScriptableObjectFromTemplate()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path + ScriptableObject, "NewScriptableObject.cs");
    }


    //Singleton
    private const string Singleton = "SingletonTemplate.cs.txt";

    [MenuItem(itemName: "Assets/Create/C# Logic Script/Singleton", isValidateFunction: false, priority = 50)]
    public static void CreateSingletonFromTemplate()
    {
        ProjectWindowUtil.CreateScriptAssetFromTemplateFile(path + Singleton, "NewSingleton.cs");
    }

    #endregion

}


