﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuDeCarte_Console.Models
{
    public class Window
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Window(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }
}
