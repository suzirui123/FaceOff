using UIKit;

using Xamarin;

namespace FaceOff.iOS
{
	public class Application
	{
		// This is the main entry point of the application.
		static void Main(string[] args)
		{
			#if __AppStore__


			#else
			Insights.Initialize(InsightsConstants.InsightsApiKey);

			Insights.HasPendingCrashReport += (sender, isStartupCrash) =>
			{
				if (isStartupCrash)
				{
					Insights.PurgePendingCrashReports().Wait();
				}
			};
			#endif

			UIApplication.Main(args, null, "AppDelegate");
		}
	}
}

