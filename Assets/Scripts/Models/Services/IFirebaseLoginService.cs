public interface IFirebaseLoginService
{
    void Init();
    void LoginApp();
    string GetID();
    bool IDAppExist();
    void SetData();
    void LoadData();
}