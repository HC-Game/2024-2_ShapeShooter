using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    public int targetFPS = 60; // 원하는 프레임 수

    void Start()
    {
        QualitySettings.vSyncCount = 0; // V-Sync 끄기
        Application.targetFrameRate = targetFPS;
       
    }
}