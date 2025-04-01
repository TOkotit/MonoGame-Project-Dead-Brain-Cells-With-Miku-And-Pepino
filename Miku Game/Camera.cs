using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Miku_Game;

namespace Miku_Game
{
    public class Camera
    {
        public Vector2 Position { get; set; }
        public float Zoom { get; set; }
        public float Rotation { get; set; }

        public int ViewportWidth { get; set; }
        public int ViewportHeight { get; set; }

        public Matrix TransformMatrix => // это работает. Я не знаю как, но спасибо великий интернет и куча добросовестных людей
            Matrix.CreateTranslation(new Vector3(-Position, 0)) *
            Matrix.CreateRotationZ(Rotation) *
            Matrix.CreateScale(Zoom) *
            Matrix.CreateTranslation(new Vector3(ViewportWidth * 0.5f, ViewportHeight * 0.5f, 0));

        public Camera(int viewportWidth, int viewportHeight)
        {
            ViewportWidth = viewportWidth;
            ViewportHeight = viewportHeight;
            Zoom = 1.0f;
            Rotation = 0.0f;
        }

        public void Follow(Vector2 targetPosition, float smoothSpeed = 0.1f)
        {
            Position = Vector2.Lerp(Position, targetPosition, smoothSpeed);
        }


    }
}