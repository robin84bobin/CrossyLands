using UnityEngine;

namespace Installers.Project
{
    [CreateAssetMenu(menuName = "Create ProjectConfig", fileName = "ProjectConfig", order = 0)]
    internal class ProjectConfig :  ScriptableObject
    {
        public string CatalogRoot = "Root";
        
        //TODO try fill in inspector [Application.streamingAssetsPath]/CatalogData.json
        public string CatalogPath => Application.streamingAssetsPath + "/CatalogData.json";
        
        //TODO try fill in inspector [Application.persistentDataPath]/user_0.json
        public string UserRepositoryPath => Application.persistentDataPath + "/user_0.json";
    }
}