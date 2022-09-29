using UnityEngine;

namespace Transition
{
    public class Teleport : MonoBehaviour
    {
        public string sceneFrom;
        public string sceneToGo;

        public void TeleportToScene()
        {
            TransitionManager.Instance.Transition(sceneFrom, sceneToGo);
        }
    }
}
