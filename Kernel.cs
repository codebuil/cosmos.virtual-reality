using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Drawing;
using Cosmos.System.Graphics;
using Cosmos.Debug.Kernel;
using Point = Cosmos.System.Graphics.Point;
using Cosmos.System.Graphics.Fonts;
using System.Threading;
using System.Diagnostics;


namespace Cosmos_Graphic_Subsytem
{
    public class VirtualReality
    {
        public int maxx = 320;
        public int maxy = 200;
        public int x = 320 / 2;
        public int y = 0;
        public int moves = 10;
        public Color backs = Color.Green;
        public Pen fore = new Pen(Color.Black);
        public int Tag = 1000;
        public VirtualReality()
        {

        }
        public void draw(Canvas c)
        {
            c.Clear(backs);
            c.DrawLine(fore, x - maxx / 2, maxy - 1, x, y);
            c.DrawLine(fore, x + maxx / 2, maxy - 1, x, y);


            c.Display();
        }
        public void MoveNext(Canvas c)
        {

            while (true)
            {

                x = x + moves;
                if (x < 0 || x > maxx - 1)
                {
                    moves = -moves;
                    x = x + moves;
                   

                }
                draw(c);
                Thread.Sleep(Tag);
            }


        }
    }
    public class Kernel : Sys.Kernel
    {

        

        private Canvas canvas;
        private Bitmap bitmap;

        protected override void BeforeRun()
        {
            
            Mode start = new Mode(320, 200, ColorDepth.ColorDepth32);

  
           
            
            canvas = FullScreenCanvas.GetFullScreenCanvas(start); 

           
            canvas.Clear(Color.Green);
        }

        protected override void Run()
        {
            try
            {
               
                VirtualReality vr = new VirtualReality();

                while (true)
                {
                    vr.MoveNext(canvas);
                    
                }



                Console.ReadKey();

               
                Console.ReadKey(true);


                Sys.Power.Shutdown();
            }
            catch (Exception e)
            {
                
                
            }
        }
    }
}
