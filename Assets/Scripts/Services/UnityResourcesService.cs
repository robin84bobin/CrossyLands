using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace Services
{
    public class UnityResourcesService : IResourcesService
    {
        public void LoadScene(string sceneName, LoadSceneMode mode)
        {
            SceneManager.LoadScene(sceneName, mode);
        }

        public string LoadTextFile(string path)
        {
            return LoadTextFileAsync(path).Result;
        }

        private async Task<string> LoadTextFileAsync(string path)
        {
            if (path.Contains("://"))
            {
                var text = await LoadFile(path);
                return text;
            }

            await Task.Run(() =>
            {
                if (!IsFileExist(path))
                    File.CreateText(path).Close();
                var text = File.ReadAllText(path);
                return text;
            });

            return string.Empty;
        }

        private bool IsFileExist(string path_)
        {
            bool exists = File.Exists(path_);
            if (!exists) {
                Debug.LogWarning("FILE NOT FOUND: " + path_);
            }

            return exists;
        }
        
        private async Task<string> LoadFile(string path)
        {
            var request = new UnityWebRequest(path);
            var operation =  request.SendWebRequest();

            while (!operation.isDone) 
                await Task.CompletedTask;
            
            return request.downloadHandler.text;
        } 
    }

    public interface IResourcesService
    {
        void LoadScene(string sceneName, LoadSceneMode mode = LoadSceneMode.Single);
        string LoadTextFile(string path);
    }
}