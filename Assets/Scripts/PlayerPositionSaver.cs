using UnityEngine;

public class PlayerPositionSaver
{
    private Transform _transform;

    public PlayerPositionSaver(Transform tr)
    {
        _transform = tr;
    }

    public void SavePlayerData()
    {
        // Сохраняем позицию игрока в PlayerPrefs
        PlayerPrefs.SetFloat("playerPosX", _transform.position.x);
        PlayerPrefs.SetFloat("playerPosY", _transform.position.y);
        PlayerPrefs.SetFloat("playerPosZ", _transform.position.z);
        PlayerPrefs.Save();
    }

    public void LoadPlayerData()
    {
        // Загружаем позицию игрока из PlayerPrefs, если она существует
        if (PlayerPrefs.HasKey("playerPosX") &&
            PlayerPrefs.HasKey("playerPosY") &&
            PlayerPrefs.HasKey("playerPosZ"))
        {
            float x = PlayerPrefs.GetFloat("playerPosX");
            float y = PlayerPrefs.GetFloat("playerPosY");
            float z = PlayerPrefs.GetFloat("playerPosZ");

            _transform.position = new Vector3(x, y, z);
        }
    }
}