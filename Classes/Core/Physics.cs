using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Box2DX.Collision;
using Box2DX.Dynamics;
using Box2DX.Common;
using Box2DX.Collision;


namespace PhsyxLite.Classes.Core
{
    public static class Physics
    {
        public static World world;
        public static float SCALE = 40f;

        public static void Initialize()
        {
            Log.Print("[<green>PHYSICS<white>] Initilized.");

            Vec2 gravity = new(0.0f, 0.0f);
            AABB worldAABB = new();
            worldAABB.LowerBound.Set(-100.0f, -100.0f);
            worldAABB.UpperBound.Set(100.0f, 100.0f);


            world = new World(worldAABB, gravity, true);
        }

        public static Body CreateBody(bool isStatic, float xPos, float yPos, float xScale, float yScale)
        {
            Log.Print($"[<yellow>PHYSICS<white>] Attempting To Create Physics Body: isStatic: {isStatic}, xPos: {xPos}, yPos: {yPos}, xScale: {xScale}, yScale: {yScale}");
            BodyDef bodyDef = new();
            bodyDef.Position.Set(xPos / SCALE, yPos / SCALE);
            bodyDef.FixedRotation = true;

            Body body = world.CreateBody(bodyDef);
            while (body == null)
            {
                body = world.CreateBody(bodyDef);
            }

            PolygonDef shapeDef = new();
            shapeDef.SetAsBox(xScale / 1.5f / SCALE, yScale / 1.8f / SCALE);

            if (!isStatic)
            {
                shapeDef.Density = 1.0f;
                shapeDef.Friction = 1f;
            }
            else
            {
                shapeDef.Density = 0.0f;
                shapeDef.Friction = 0.5f;
            }

            body.CreateShape(shapeDef);

            if (!isStatic)
                body.SetMassFromShapes();
            Log.Print($"[<green>PHYSICS<white>] Successfully Created Physics Body: isStatic: {isStatic}, xPos: {xPos}, yPos: {yPos}, xScale: {xScale}, yScale: {yScale}");
            return body;
        }

        public static void Update()
        {
            world.Step(1.0f / 60.0f, 8, 3);
        }

    }
}
