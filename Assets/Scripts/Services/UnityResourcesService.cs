using System;
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

        public async Task<string> LoadTextFile(string path)
        {
            string text = string.Empty;
            if (path.Contains("://"))
            {
                text = await LoadUrl(path);
                return text;
            }

            await Task.Run(() =>
            {
                if (!IsFileExist(path))
                    File.CreateText(path).Close();
                text = File.ReadAllText(path);
            });

            return text;
        }

        public Task<T> LoadComponentFromPrefab<T>(string path) where T:UnityEngine.Object
        {
            throw new NotImplementedException();
        }


        private bool IsFileExist(string path_)
        {
            bool exists = File.Exists(path_);
            if (!exists) {
                Debug.LogWarning("FILE NOT FOUND: " + path_);
            }

            return exists;
        }
        
        private async Task<string> LoadUrl(string path)
        {
            var request = new UnityWebRequest(path);
            var operation =  request.SendWebRequest();

            while (!operation.isDone) 
                await Task.CompletedTask;
            
            return request.downloadHandler.text;
        } 
    }
}