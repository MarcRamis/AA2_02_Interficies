using Firebase.Firestore;
using Firebase.Extensions;
using Code;
using UnityEngine;

public class FirebaseLoginService : IFirebaseLoginService
{
    IEventDispatcherService eventDispatcherService;
    public FirebaseLoginService(IEventDispatcherService _eventDispatcherService)
    {
        eventDispatcherService = _eventDispatcherService;
    }

    public void Init()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task =>
        {
            Debug.Log("Auth");
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                var app = Firebase.FirebaseApp.DefaultInstance;
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format("Could not resolve all Firebase dependencies: {0}", dependencyStatus));
            }
        });

        eventDispatcherService.Dispatch<LogConnectionEvent>(new LogConnectionEvent(Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser != null));
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
        var user = new User("Romera", 4);
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
    {
        return Firebase.Auth.FirebaseAuth.DefaultInstance.CurrentUser.UserId;
    }
}