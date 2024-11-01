using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    public int targetFPS = 240; // ���ϴ� ������ ��

    void Start()
    {
        QualitySettings.vSyncCount = 0; // V-Sync ����
        Application.targetFrameRate = targetFPS;
       
    }
}