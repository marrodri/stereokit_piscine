using System;
using System.Collections.Generic;
using System.Text;
using StereoKit;

namespace Day00_ex01
{
	class Cube
	{
		Model cube = Model.FromMesh(
			Mesh.GenerateRoundedCube(Vec3.One, 0.2f),
			Default.Material);
		Vec3 cube_pos = Vec3.Zero;

		public Cube(float x)
		{
			cube_pos.y = 5;
			cube_pos.x = x;
		}

		public float getYPos()
		{
			return cube_pos.y;
		}
		public void Step()
		{
			DrawCube();
			cube_pos.y -= 0.01f;
			//if (cube_pos.y < -3)
			//{
			//	cube_pos.y = 5;
			//}
		}

		public void DrawCube()
		{

			cube.Draw(Matrix.TS(cube_pos, 0.1f));
		}
	}
}
