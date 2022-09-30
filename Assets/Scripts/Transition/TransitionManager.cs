using System;
using System.Collections;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;
using EventHandler = Utilities.EventHandler;

namespace Transition
{
    public class TransitionManager : Singleton<TransitionManager>
    {
        public string startScene;
        public CanvasGroup fadeCanvasGroup;
        public float fadeDuration;
        
        private bool isFade;

        private void Start()
        {
            StartCoroutine(TransitionToScene(String.Empty, startScene));
        }

        public void Transition(string from, string to)
        {
            if (!isFade)
                StartCoroutine(TransitionToScene(from, to));
        }

        private IEnumerator TransitionToScene(string from, string to)
        {
            yield return Fade(1);

            if (from != String.Empty)
            {
                EventHandler.CallBeforeSceneUnloadEvent();
                yield return SceneManager.UnloadSceneAsync(from);
            }
            
            yield return SceneManager.LoadSceneAsync(to, LoadSceneMode.Additive);
            Scene newScene = SceneManager.GetSceneAt(SceneManager.sceneCount - 1);
            SceneManager.SetActiveScene(newScene);
            
            EventHandler.CallAfterSceneUnloadEvent();
            yield return Fade(0);
        }

        private IEnumerator Fade(float targetAlpha)
        {
            isFade = true;
            fadeCanvasGroup.blocksRaycasts = true;
            
            float speed = Mathf.Abs(fadeCanvasGroup.alpha - targetAlpha) / fadeDuration;
            while (!Mathf.Approximately(fadeCanvasGroup.alpha, targetAlpha))
            {
                fadeCanvasGroup.alpha = Mathf.MoveTowards(fadeCanvasGroup.alpha, targetAlpha, speed * Time.deltaTime);
                yield return null;
            }

            fadeCanvasGroup.blocksRaycasts = false;
            isFade = false;
        }
    }
}
