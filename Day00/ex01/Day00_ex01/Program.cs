using System;
using StereoKit;

namespace Day00_ex01
{
	class Program
	{
		static void Main(string[] args)
		{
			if (!StereoKitApp.Initialize("Day00_ex01", Runtime.Flatscreen))
				Environment.Exit(1);

			//Cube cube = new Cube(0);
			//Cube cube1 = new Cube(0.2f);
			//Cube cube2 = new Cube(-0.2f);

			CubeList cubeList = new CubeList();
			Vec3 collision_size = new Vec3(5,2,1);
			Vec3 collision_pos = new Vec3(0,-0.5f,0);

			// Setting transparency, for some reason
			// the cube goes transparent in the area of 
			// the colliding hand

			Material trans = Default.Material;
			trans.Transparency = Transparency.None;

			//creating the collision box

			Model collision_box = Model.FromMesh(
				Mesh.GenerateRoundedCube(collision_size, 0),
				trans);

			while (StereoKitApp.Step(() =>
			{
				//cube.Step();
				//cube1.Step();
				//cube2.Step();
				cubeList.Step();
				collision_box.Draw(Matrix.TS(collision_pos, 0.1f));

				cubeList.DeleteCube();
			})) ;

			StereoKitApp.Shutdown();
		}
	}
}
