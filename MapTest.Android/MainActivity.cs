using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MapTest.Droid
{
    [Activity(Label = "MapTest", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        Bundle bundle;
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);

            if(!AllowedLocationPermission()){
                string[] req_permissions = new string[] { Android.Manifest.Permission.AccessFineLocation };
                RequestPermissions(req_permissions, 0);//FineLocationの許可をとる
            }else{
                Xamarin.FormsMaps.Init(this, bundle);
                LoadApplication(new App());
            }
            this.bundle = bundle;
        }
        public void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            if (AllowedLocationPermission())
            {
                Xamarin.FormsMaps.Init(this, this.bundle);
                LoadApplication(new App());
            }else{
                System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
            }
        }
        private bool AllowedLocationPermission(){
            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                if (Android.App.Application.Context.CheckSelfPermission(Android.Manifest.Permission.AccessFineLocation) == Permission.Granted)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            return false;
        }
    }
}

