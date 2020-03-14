using System;
using StereoKit;

namespace StereoKit_day00
{
	class Program
	{

		static void Main(string[] args)
		{
			if (!StereoKitApp.Initialize("StereoKit_day00", Runtime.Flatscreen))
				Environment.Exit(1);


			Balloon balloon = new Balloon(1f);
			String txt_format = String.Format("Game Over!\nBallon life was: " + (int)Time.Total + " secs\n Tap again to exit");
			bool gameOver = false;
			//Time.SetTime
			//Time.SetTime(0);
			while (StereoKitApp.Step(() =>
			{
				Hand right_hand = Input.Hand(Handed.Right);
				if (right_hand.IsPinched && !balloon.GetGameStarted())
				{
					Console.WriteLine("GAME STARTED");
					Time.SetTime(0.0f);
				}
				Console.WriteLine(Time.Total);
				if (balloon.balloonAir > 5f)
				{
					if (!gameOver)
					{
						txt_format = String.Format("Game Over!\nBallon life was: " + (int)Time.Total + " secs\n Tap again to exit");
					}
					Text.Add(
						txt_format,
						Matrix.TRS(Vec3.Zero,
						Quat.LookDir(0, 0, 1)));
					gameOver = true;
					if (right_hand.IsJustPinched)
						StereoKitApp.Quit();
				}
				else if(balloon.balloonAir < 0.5f)
				{
					//Matrix
					//Quat
					Text.Add(
						"YOU LOST!\n",
						Matrix.TRS(Vec3.Zero,
						Quat.LookDir(0, 0, 1)));
					if (right_hand.IsJustPinched)
						StereoKitApp.Quit();
					gameOver = true;
				}
				if (!gameOver)
				{
					balloon.DrawBalloon();
					balloon.Steps(right_hand);
				}
			})) ;

			StereoKitApp.Shutdown();
		}
	}
}
