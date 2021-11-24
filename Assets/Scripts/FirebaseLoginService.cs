using Firebase.Firestore;
using Firebase.Extensions;

public class FirebaseLoginService : IFirebaseLoginService, IFirebaseDatabaseService
{
    public FirebaseLoginService()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                var app = Firebase.FirebaseApp.DefaultInstance;

              
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                //Firebase Unity SDK is not safe to use here.
            }
        });
    }

    public void LoginApp()
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        auth.SignInAnonymouslyAsync().ContinueWith(task =>
        {
            if (task.IsCanceled)
            {
                return;
            }
            if (task.IsFaulted)
            {
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            SetData();
        });
    }

    public void SetData()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        var user = new User("Palazon", 9);
        DocumentReference docRef = db.Collection("users").Document(Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser.UserId);

        docRef.SetAsync(user).ContinueWithOnMainThread(task =>
        {
            if (task.IsCompleted)
            {
                LoadData();
            }
        });
    }

    public void LoadData()
    {
        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;

        CollectionReference usersRef = db.Collection("users");
        usersRef.GetSnapshotAsync().ContinueWithOnMainThread(task =>
        {
            QuerySnapshot snapshot = task.Result;
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                var user = document.ConvertTo<User>();
            }
        });
    }

    public string GetID()
    // Set a flag here to indicate whether Firebase is ready to use by your app.
    {
        //if (Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser != null)
        //{
        //    return Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser.UserId;
        //}
        //else { return null; }

        return Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser.UserId;
    }
}