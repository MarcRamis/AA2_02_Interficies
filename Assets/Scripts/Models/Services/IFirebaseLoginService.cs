public interface IFirebaseLoginService
{
    void LoginApp();
    string GetID();
    bool IDAppExist();
    void SetData();
    void LoadData();
}