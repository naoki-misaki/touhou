﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace 東方
{
    internal class Shot : ShootingObject
    {
        static Image image = Resource1.shot2;
        static int speed = 20;
        public Vector2 position;
        public float radius = 10;
        public bool enable = true;

        public Shot(Vector2 position)
        {
            this.position = position;
        }

        public void Progress()
        {
            position.Y -= speed;
            if (position.Y < BackGround.position.Y) enable = false;
        }

        public void Draw(Bitmap canvas)
        {
            var graphics = Graphics.FromImage(canvas);
            graphics.DrawImage(image, position.X - image.Width / 2, position.Y - image.Height / 2, image.Width, image.Height);
        }
    }
}
