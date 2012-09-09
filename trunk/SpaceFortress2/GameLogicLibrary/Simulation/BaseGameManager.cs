using EngineGameLibrary.Simulation;
using Jitter;
using Jitter.Collision;
using Jitter.Collision.Shapes;
using Jitter.LinearMath;
using Microsoft.Xna.Framework;
using ThreeDWindowsGameLibrary.Simulation;

namespace GameLogicLibrary.Simulation
{
	public class BaseGameManager : GameManager
	{
		CollisionSystem collision;
		World world;
		GameEntityManager entityManager;



		public GameEntityManager EntityManager
		{
			get
			{
				return entityManager;
			}
		}
		public World World
		{
			get
			{
				return world;
			}
		}

		public BaseGameManager()
		{
			collision = new CollisionSystemSAP();
			world = new World(collision);
			entityManager = new GameEntityManager();
		}

		public override void Update(GameTime gameTime)
		{
			//Update jitter world
			float step = (float)gameTime.ElapsedGameTime.TotalSeconds;
			//if (step > 1.0f / 100.0f) step = 1.0f / 100.0f;
			World.Step(step, true);
		}




		public override void StartGame()
		{
			////Set up some entities
			PhysicsGameEntity ground = new PhysicsGameEntity("ground", new Vector3(0f, -1f, 0f), VectorHelper.CreateOrientationMatrix(Vector3.Zero), Vector3.One * 0.05f, new BoxShape(new JVector(1000, 1, 1000)));
			ground.Body.IsStatic = true;
			ground.Body.Material.KineticFriction = 0.5f;
			ground.Body.EnableDebugDraw = false;

			EntityManager.AddEntity(ground);


			for (int i = 0; i < 10; i++)
			{
				for (int y = 0; y < 10; y++)
				{
					float offset;
					if (y % 2 == 1)
						offset = 0f;
					else
						offset = 5f;


					PhysicsGameEntity ship = new PhysicsGameEntity("ship", new Vector3((i * 15), 100f + (y * 15f), offset), VectorHelper.CreateOrientationMatrix(Vector3.Zero), Vector3.One * 0.005f, new BoxShape(new JVector(10, 5, 10)));
					ship.Body.Material.Restitution = 0.999999f;
					ship.Body.Mass = 2500f;
					ship.Body.EnableDebugDraw = false;
					EntityManager.AddEntity(ship);
				}

			}

			////Actors.Add(new BasicActor(Models["teapot"], new Vector3(0f, 0f, 0f), Vector3.Zero, Vector3.One * 10, graphics));
			////Actors.Add(new BasicActor(Models["teapot"], new Vector3(250f, 0f, 0f), Vector3.Zero, Vector3.One * 10, graphics));
			////Actors.Add(new BasicActor(Models["ship"], , Vector3.Zero, Vector3.One, graphics));
		}

		public override void EndGame()
		{
			world.Clear();
			EntityManager.Entities.Clear();
		}

	}
}
