using System;
using System.Collections.Generic;
using System.Text;
using StereoKit;

namespace Day00_ex01
{
	class CubeList
	{
		int activeCubes = 0;
		List<Cube> cubes = new List<Cube>();
		float []x_positions = { -0.2f, 0, 0.2f };
		public void Step()
		{
			Random rand = new Random();
			int index = rand.Next(x_positions.Length);
			//Time.SetTime(0);
			// use 0.2f, 0, 0.2f for random x positions
			Console.WriteLine("cubes count is |" + cubes.Count +"|");
			if (cubes.Count < 5 && Time.Total > 2)
			{
				Console.WriteLine("adding cube at x |" + x_positions[index] + "|");
				cubes.Add(new Cube(x_positions[index]));
				Time.SetTime(0);
			}
			if (cubes.Count > 0)
			{
				for (int i = 0; i < cubes.Count;i++)
				{
					cubes[i].Step();
				}
			}
		}

		public void DeleteCube()
		{
			if (cubes.Count > 0)
			{
				for (int i = 0; i < cubes.Count; i++)
				{
					if (cubes[i].getYPos() < -3f)
					{
						cubes.Remove(cubes[i]);
					}
				}
			}

		}

	}
}
