using System;

namespace ClonUber.Modelo
{
    public class GoogleUser
    {
        public string Name { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public Uri Picture { get; set; }
    }

    /// <summary>
    /// Its purpose is to control file GoogleManager.
    /// </summary>
    public interface IGoogleManager
    {
        void LogIn(Action<GoogleUser, string> OnLoginComplete);
        void LogOut();
    }
}
