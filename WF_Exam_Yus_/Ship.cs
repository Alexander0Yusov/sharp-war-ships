using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Exam_Yus_
{
    public class Ship
    {
        public int size;
        public int killedSize = 0;

        public bool horizontal;
        public bool isKilled = false;
        
        public Point head;        
        
        public LinkedList<Point> body;
        public LinkedList<Point> specZone;

        public Ship(Point head, int size, bool horizontal)
        {
            this.size = size;
            this.horizontal = horizontal;
            this.head = head;
            CreateBody();
            CreateSpecZone();
            ClearSpecZone();
        }

        public void CreateBody()
        {
            LinkedList<Point> body_ = new LinkedList<Point>();
            body_.AddLast(head);
            Point tmp;
            if (horizontal)
            {                
                for(int i = head.X + 1; i < head.X + size; i++)
                {
                    tmp = new Point(i, head.Y);
                    body_.AddLast(tmp);                    
                }                
            }
            if (!horizontal)
            {
                for (int j = head.Y + 1; j < head.Y + size; j++)
                {
                    tmp = new Point(head.X, j);
                    body_.AddLast(tmp);
                }
            }
            body = body_;
        }

        public void CreateSpecZone()
        {
            Point tmp;
            specZone = new LinkedList<Point>();
            if (horizontal)
            {
                // точка перед левым торцем
                tmp = new Point(head.X - 1, head.Y);
                specZone.AddLast(tmp);
                // точка за правым торцем
                tmp = new Point(body.Last().X + 1, head.Y);
                specZone.AddLast(tmp);

                // наполнение верхней линии
                for (int i = head.X - 1; i < head.X + size + 1; i++)
                {
                    tmp = new Point(i, head.Y - 1);
                    specZone.AddLast(tmp);
                }
                // наполнение нижней линии
                for (int i = head.X - 1; i < head.X + size + 1; i++)
                {
                    tmp = new Point(i, head.Y + 1);
                    specZone.AddLast(tmp);
                }
            }
            if (!horizontal)
            {
                // точка над верхним торцем
                tmp = new Point(head.X, head.Y - 1);
                specZone.AddLast(tmp);
                // точка под нижним торцем
                tmp = new Point(head.X, body.Last().Y + 1);
                specZone.AddLast(tmp);

                // наполнение левой линии
                for (int j = head.Y - 1; j < head.Y + size + 1; j++)
                {
                    tmp = new Point(head.X - 1, j);
                    specZone.AddLast(tmp);
                }
                // наполнение правой линии
                for (int j = head.Y - 1; j < head.Y + size + 1; j++)
                {
                    tmp = new Point(head.X + 1, j);
                    specZone.AddLast(tmp);
                }
            }



        }

        public void ClearSpecZone()
        {
            LinkedList<Point> tmp = new LinkedList<Point>();
            foreach (var v in specZone)
            {
                if(v.X >= 0 && v.X <= 9 && v.Y >= 0 && v.Y <= 9)
                {
                    tmp.AddLast(v);
                }
            }
            specZone = tmp;
        }
    }
}
