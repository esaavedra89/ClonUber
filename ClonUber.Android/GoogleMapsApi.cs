#if DEBUG
using System;
using Android.App;
using Android.Runtime;
using Plugin.CurrentActivity;
using ClonUber.Conexiones;
[Application(Debuggable = true)]
#else
using Android.App;
using Android.Runtime;
using Plugin.CurrentActivity;
using System;
[Application(Debuggable = false]
#endif


[MetaData("com.google.android.maps.v2.API_KEY",
    Value =Constantes.GoogleMapsApiKey)]
public class GoogleMapsApi:Application
{
    // JniHandleOwnership help to transfer the Key to entire app.
    // base, we subscribe to base on main activity.
    public GoogleMapsApi(IntPtr handle, JniHandleOwnership transer)
        : base(handle, transer)
	{

	}

    public override void OnCreate()
    {
        base.OnCreate();
        CrossCurrentActivity.Current.Init(this);
    }
}
