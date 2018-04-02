using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnsGrindar
{
    public struct CChar
    {
        public char lc, rc;
        public ConsoleColor foreground, background;

        public CChar(char lc, char rc, ConsoleColor foreground, ConsoleColor background)
        {
            this.lc = lc;
            this.rc = rc;
            this.foreground = foreground;
            this.background = background;
        }
    }

    public class Buffer
    {
        CChar[] data;
        public readonly int Width;
        public readonly int Height;

        Queue<int> UpdateQueue;

        public Buffer(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            this.data = new CChar[width * height];
            UpdateQueue = new Queue<int>();

            for(int i = 0; i < data.Length; i++)
            {
                this.data[i] = new CChar('[', ']', ConsoleColor.Black, ConsoleColor.Green);
                UpdateQueue.Enqueue(i);
            }
        }

        public void DrawBuffer()
        {
            if(Console.BufferWidth < Width || Console.BufferHeight < Height)
            {
                Console.SetBufferSize(Console.BufferWidth < Width * 2 ? Width * 2 : Console.BufferWidth,
                                      Console.BufferHeight < Height ? Height : Console.BufferHeight);
            }

            while(UpdateQueue.Count > 0)
            {
                int i = UpdateQueue.Dequeue();

                Console.SetCursorPosition((i % Width) * 2, i / Width);
                Console.ForegroundColor = data[i].foreground;
                Console.BackgroundColor = data[i].background;
                Console.Write(data[i].lc);
                Console.Write(data[i].rc);
            }
        }

        public void SetCharacter(int x, int y, CChar character)
        {
            int index = x + y * Width;

            if (character.background != data[index].background &&
                character.foreground != data[index].foreground &&
                character.lc != data[index].lc &&
                character.rc != data[index].rc)
            {
                data[index] = character;
                UpdateQueue.Enqueue(index);
            }
        }
    }
}
