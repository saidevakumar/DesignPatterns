// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
BasicCameraApp bcamera = new BasicCameraApp();
bcamera.Share();

CameraPlusApp CameraPlus = new CameraPlusApp();
CameraPlus.Share();



//In Strategy Pattern, it favor composition over inheritance.
//Classes should achieve code reuse using composition rather than inheritance from a superclass.

//Base Class
public abstract class PhoneCameraApp
{
		protected IShareStrategy? ShareObj;

		public void take(){}

		public void edit(){}

		public void save(){}

		public void Share(){
            if (ShareObj != null)
            {
                ShareObj.Share();
            }
        }

		public void SetShareBehavior(IShareStrategy ShareObj){

            this.ShareObj = ShareObj;
        }
}

//Derived class BasicCameraApp from PhoneCameraApp
public class BasicCameraApp:PhoneCameraApp
{
		public BasicCameraApp()
		{
            base.ShareObj = new SocialMediaShareBehavior();
		}

}

//Derived class CameraPlusApp from PhoneCameraApp
public class CameraPlusApp:PhoneCameraApp
{

		public CameraPlusApp()
		{
				ShareObj = new TextShareBehavior();
		}

}

