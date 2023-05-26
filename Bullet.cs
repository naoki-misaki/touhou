using System.Numerics;

namespace 東方
{
    internal class Bullet : ShootingObject
    {
        static Image[] images = new Bitmap[] { Resource1.Bullet0, Resource1.Bullet1, Resource1.Bullet2, Resource1.Bullet3,
                                               Resource1.Bullet4, Resource1.Bullet5, Resource1.Bullet6, Resource1.Bullet7,};
        static float[] radii = new float[] { 4, 2, 3, 13, 3, 3, 2, 2 };
        readonly int imageID = 0;
        readonly int actID = 0;
        bool rotatable = false; //速度の方向に回転するか否か
        Vector2 speed = new();
        public Vector2 position = new();
        public bool enable = true;
        public readonly float redius;

        public Bullet(int ImageID, int actID, bool rotatable, Vector2 position, Vector2 speed)
        {
            this.imageID = ImageID;
            this.actID = actID;
            this.rotatable = rotatable;
            this.position = position;
            this.speed = speed;
            this.redius = radii[ImageID];
        }

        public void Progress()
        {
            if (actID == 1)
            {
                speed = (speed.Length() + 0.03f) * (speed / speed.Length()); //等加速度直線運動
            }
            else if (actID == 2)
            {
                speed.Y += 0.15f;
            }
            position += speed;
            if (position.X < 0 || position.X > 450 || position.Y < 0 || position.Y > 489)
            {
                enable = false;
            }
        }

        public void Draw(Bitmap canvas)
        {
            var graphics = Graphics.FromImage(canvas);
            // 画像の中心がpositionとなるように描画
            var image = images[imageID];
            if (rotatable)
            {
                var angle = -MathF.Atan2(speed.X, speed.Y);
                float x = image.Width / 2, y = image.Height / 2, c = MathF.Cos(angle), s = MathF.Sin(angle);
                var points = new Vector2[] { new(-x * c + y * s, -x * s - y * c), new(x * c + y * s, x * s - y * c), new(-x * c - y * s, -x * s + y * c) };
                graphics.DrawImage(image, points.Select(point => (PointF)(point + position)).ToArray());
            }
            else graphics.DrawImage(image, position.X - image.Width / 2, position.Y - image.Height / 2, image.Width, image.Height);
        }
    }
}
