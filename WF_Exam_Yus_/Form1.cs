using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Exam_Yus_
{
    public partial class Form1 : Form
    {
        int timeLim = 16;
        int timer_1;
        int sec;
        int min;
        int horizont;
        

        byte mapSize = 10;
        byte cellSize = 30;
        string alph = "АБВГДЕЖЗИК";
                
        List<Point> StackForEnemyShoots;

        //byte[,] enemyMap;

        Button[,] myButtons;
        Button[,] enemyButtons;


        LinkedList<Ship> myShips;
        LinkedList<Ship> myShipsForReset;
        List<Ship> enemyShips;

        Color clrSkyBlue = new Color();
        Color clrNearlySkyBlue = new Color();
        Color clrBlue = Color.Blue;

        public Form1()
        {
            InitializeComponent();
            
            comboBox_level.Items.AddRange(new object[] { "Легко", "Средне", "Трудно" });
            comboBox_orientation.Items.AddRange(new object[] { "Смешанная", "Горизонталь", "Вертикальн" });
            Ini();
        }
        public void Ini()
        {
            Text = "Игра - Морской бой";            
            label_time_limit.Text = "00";
            labe_total_time.Text = "00:00";
            sec = min = 0;
            progressBar1.Maximum = progressBar2.Maximum = 20;
            timer1.Interval = 1000;
            timer2.Interval = 1000;            

            progressBar1.Value = 0;
            progressBar2.Value = 0;            
            comboBox_orientation.SelectedIndex = 0;            
            comboBox_level.SelectedIndex = 0;

            enemyShips = null;
            myShips = null;

            button_create.Enabled = true;
            button_check.Enabled = false;
            button_start.Enabled = false;

            if (myShipsForReset == null)
            {
                button_replay.Enabled = false;
                label_status.Text = "Нажмите \"Создать\"";
            }
            else
            {
                button_replay.Enabled = true;
                label_status.Text = "Создать / Повторить";
            }
                       
            CreateMyMap();
            CreateEnemyMap();
            HeadMassives();
            //GenerationEnemyFleet();
            //DrowingEnemyFleet();
            CreatingShootList();
            
            
        }

        // наполнение списка вероятными выстрелами
        public void CreatingShootList()
        {
            Point tmp_point;
            StackForEnemyShoots = new List<Point>();
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    tmp_point = new Point(i, j);
                    StackForEnemyShoots.Add(tmp_point);
                }
            }
        }

        // массив букв заголовка
        public void HeadMassives()
        {
            for (int i = 0; i < mapSize; i++)
            {
                Label lb = new Label();
                lb.Location = new Point(0, cellSize + i * cellSize);
                lb.Size = new Size(cellSize, cellSize);
                lb.Text = alph[i].ToString();
                lb.BorderStyle = BorderStyle.FixedSingle;
                lb.TextAlign = ContentAlignment.MiddleCenter;
                lb.BackColor = Color.Aquamarine;
                panel_fields.Controls.Add(lb);

                Label lb_ = new Label();
                lb_.Location = new Point(cellSize + i * cellSize, 0);
                lb_.Size = new Size(cellSize, cellSize);
                lb_.Text = (i + 1).ToString();
                lb_.BorderStyle = BorderStyle.FixedSingle;
                lb_.TextAlign = ContentAlignment.MiddleCenter;
                panel_fields.Controls.Add(lb_);

                Label lb_1 = new Label();
                lb_1.Location = new Point(12 * cellSize + 3 + i * cellSize, 0);//3 - зазор
                lb_1.Size = new Size(cellSize, cellSize);
                lb_1.Text = (i + 1).ToString();
                lb_1.BorderStyle = BorderStyle.FixedSingle;
                lb_1.TextAlign = ContentAlignment.MiddleCenter;
                panel_fields.Controls.Add(lb_1);

                Label lb_2 = new Label();
                lb_2.Location = new Point(11 * cellSize + 3, cellSize + i * cellSize);//3 - зазор
                lb_2.Size = new Size(cellSize, cellSize);
                lb_2.Text = alph[i].ToString();
                lb_2.BorderStyle = BorderStyle.FixedSingle;
                lb_2.TextAlign = ContentAlignment.MiddleCenter;
                panel_fields.Controls.Add(lb_2);
            }
        }
         
        public void CreateMyMap()
        {
            clrSkyBlue = Color.FromArgb(117, 187, 253);            
            
            myButtons = new Button[mapSize, mapSize];

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Button bt = new Button();
                    bt.Location = new Point(cellSize + i * cellSize, cellSize + j * cellSize);
                    bt.Size = new Size(cellSize, cellSize);
                    bt.BackColor = clrSkyBlue;
                    bt.Enabled = false;
                    bt.Click += new EventHandler(ConfigShips);
                    myButtons[i, j] = bt;
                    panel_fields.Controls.Add(bt);
                }
            }

        }

        public void CreateEnemyMap()
        {
            // шифр цвета: небесно-голубой - пусто, синий - палуба
            Color clr = new Color();
            clr = Color.FromArgb(117, 187, 253);
            enemyButtons = new Button[mapSize, mapSize];
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Button bt = new Button();
                    bt.Location = new Point((12 * cellSize + i * cellSize) + 3, (cellSize + j * cellSize));// 3 - зазор полей
                    bt.Size = new Size(cellSize, cellSize);
                    bt.BackColor = clr;
                    bt.Enabled = false;
                    //bt.Click += new EventHandler(ConfigShips);
                    enemyButtons[i, j] = bt;
                    panel_fields.Controls.Add(bt);
                }
            }            
        }

        public void ConfigShips(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            if (pressedButton.BackColor == clrSkyBlue)
            {
                pressedButton.BackColor = Color.Blue;
            }
            else
            {
                pressedButton.BackColor = clrSkyBlue;
            }
        }

        public bool CheckShips(Button[,] array)
        {
            Point pointForLooking = new Point(0, 0);
            Point lastPoint = new Point(9, 9);
            int countShips = 0; // инкремент числа в цикле вайл
            int length;
            Ship ship;
            myShips = new LinkedList<Ship>();

            while (true)
            {
                //идем до первого признака корабля
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        pointForLooking = new Point(i, j);

                        if (array[i, j].BackColor == Color.Blue && LookingForException(pointForLooking))
                        {

                            length = Math.Max(HorizontLength(array, pointForLooking), VerticalLength(array, pointForLooking));
                            ship = new Ship(pointForLooking, length, HorizontLength(array, pointForLooking) >
                                VerticalLength(array, pointForLooking));

                            myShips.AddLast(ship);
                            countShips++;

                        }
                    }
                }

                if (Math.Equals(lastPoint, pointForLooking) && myShips.Count == 10 && CheckingSpecZoneByColor())
                {
                    return true;
                }
                if (Math.Equals(lastPoint, pointForLooking))
                {
                    return false;
                }
            }
            //return false;
        }

        public int VerticalLength(Button[,] array, Point point)
        {
            int count = 0;
            for (int j = point.Y; j < mapSize; j++)
            {
                if (array[point.X, j].BackColor == Color.Blue)
                {
                    count++;
                }
                if (array[point.X, j].BackColor != Color.Blue)
                {
                    return count;
                }
            }
            return count;
        }
        public int HorizontLength(Button[,] array, Point point)
        {
            int count = 0;
            for (int i = point.X; i < mapSize; i++)
            {
                if (array[i, point.Y].BackColor == Color.Blue)
                {
                    count++;
                }
                if (array[i, point.Y].BackColor != Color.Blue)
                {
                    return count;
                }
            }
            return count;
        }

        // поиск точки (i,j) на принадлежность кораблям и на принадлежность спецзон.
        // если нет соответствия, то метод возвращает истину, как разрешение на регистрацию нового корабля
        public bool LookingForException(Point point)
        {
            foreach (var v in myShips) // v - каждый кораблик
            {
                foreach (var v2 in v.body) // v2 - точка в массиве тел 
                {
                    if (Math.Equals(v2, point)) // совпадение с телами - фолс
                    {
                        return false;
                    }
                }
                foreach (var v3 in v.body) // v3 - точка в массиве спецзон 
                {
                    if (Math.Equals(v3, point)) // совпадение со спецзонами - фолс
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool CheckingSpecZoneByColor()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    // если кнопка помечена как тело корабля, то проверяем не находится ли она в спецзоне любого из всех
                    if (myButtons[i, j].BackColor == Color.Blue)
                    {
                        // перебор каждого корабля
                        foreach (var v in myShips)
                        {
                            // перебор точек спецзоны конкретного корабля
                            foreach (var v2 in v.specZone)
                            {
                                if (v2.X == i && v2.Y == j)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void ClearEnemyField()
        {
            foreach(var v in enemyButtons)
            {
                panel_fields.Controls.Remove(v);
            }
        }
           

        private void button_create_Click(object sender, EventArgs e)
        {   
            label_status.Text = "Нажмите \"Готово\"";
            button_create.Enabled = false;
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    myButtons[i, j].Enabled = true;
                }
            }
            button_check.Enabled = true;
        }

        private void button_check_Click(object sender, EventArgs e)
        {            
            if (CheckShips(myButtons) && CheckMyShipConditions())
            {
                // выбор ориентации заморожен
                comboBox_orientation.Enabled = false;

                MessageBox.Show("Порядок !");
                button_create.Enabled = false;
                button_check.Enabled = false;
                button_start.Enabled = true;
                for (int i = 0; i < mapSize; i++)
                {
                    for (int j = 0; j < mapSize; j++)
                    {
                        myButtons[i, j].Enabled = false;
                    }
                }
                label_status.Text = "Нажмите \"Начать\"";
            }
            else
            {
                MessageBox.Show("Ваша карта не отвечает требованиям правил");
                label_status.Text = "Исправьте карту";
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            SelectLevelTimer();
            SelectCondition();
            GenerationEnemyFleet();
            ClearEnemyField();
            DrowingEnemyFleet();
            comboBox_level.Enabled = comboBox_orientation.Enabled = button_start.Enabled = false;
            timer1.Enabled = timer2.Enabled = true;

            myShipsForReset = myShips;
            button_replay.Enabled = true;

            label_status.Text = "Удачи в бою!";
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    enemyButtons[i, j].Enabled = true;
                }
            }
        }

        private void GenerationEnemyFleet()
        {
            Point p = new Point();
            Ship s = new Ship(p, 1, true);
            int count = 1;
            int size;
            Random r = new Random();
            Random f = new Random();
            enemyShips = new List<Ship>();
            bool b = true;

            while (count <= 10)
            {

                while (true)
                {
                    p = new Point(r.Next(0, 9), r.Next(0, 9));
                    if (ValidRandomPoint(p))
                    {
                        break;
                    }
                }

                switch (comboBox_orientation.SelectedIndex)
                {
                    case 0:
                        if (f.Next(0, 9) >= 5)
                        {
                            b = false;
                        }
                        else
                        {
                            b = true;
                        }
                        break;
                    case 1: b = true;
                        break;
                    case 2: b = false;
                        break;
                }
                

                if (count == 1)
                {
                    size = 4;
                    s = new Ship(p, size, b);
                }
                if (count == 2 || count == 3)
                {
                    size = 3;
                    s = new Ship(p, size, b);
                }
                if (count >= 4 && count <= 6)
                {
                    size = 2;
                    s = new Ship(p, size, b);
                }
                if (count >= 7 && count <= 10)
                {
                    size = 1;
                    s = new Ship(p, size, b);
                }
                if (ValidRandomShip(s))
                {
                    enemyShips.Add(s);
                    count++;
                }
            }
            //MessageBox.Show($"massiv {enemyShips.Count} points");
            //MessageBox.Show($" {enemyShips[0].head.ToString()}\n {enemyShips[1].head.ToString()}\n");
        }

        private bool ValidRandomPoint(Point point)
        {
            // если нет кораблей то точка годится
            if (enemyShips.Count == 0)
            {
                return true;
            }

            // если попадает в любой корабль - выход
            foreach (var v in enemyShips)
            {
                foreach (var v_2 in v.body)
                {
                    if (Math.Equals(point, v_2))
                    {
                        return false;
                    }
                }
            }

            // если попадает в любую спецзону - выход
            foreach (var v in enemyShips)
            {
                foreach (var v_2 in v.body)
                {
                    if (Math.Equals(point, v_2))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool ValidRandomShip(Ship ship)
        {
            // если выход за пределы поля - выход
            foreach (var v in ship.body)
            {
                if (v.X > 9 || v.Y > 9)
                {
                    return false;
                }
            }

            // если интерференция кораблей - выход
            foreach (var v in enemyShips)
            {
                foreach (var v_2 in v.body)
                {
                    foreach (var v_3 in ship.body)
                        if (v_3 == v_2)
                        {
                            return false;
                        }
                }
            }

            // если попадание в любую спецзону - выход
            foreach (var v in enemyShips)
            {
                foreach (var v_2 in v.specZone)
                {
                    foreach (var v_3 in ship.body)
                        if (v_3 == v_2)
                        {
                            return false;
                        }
                }
            }
            return true;
        }

        // визуалка массива соперника по сути
        private bool DrowingEnemyFleet()
        {
            // создаем массив кнопок врага согласно сгенеренному массиву кораблей
            Button[,] tmp_buttons = new Button[mapSize, mapSize];
            Button tmp;
            clrNearlySkyBlue = Color.FromArgb(116, 187, 253);

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    tmp = new Button();
                    tmp.Location = new Point((12 * cellSize + i * cellSize) + 3, (cellSize + j * cellSize));// 3 - зазор полей
                    tmp.Size = new Size(cellSize, cellSize);
                    tmp.Enabled = false;
                    tmp.BackColor = clrSkyBlue;
                    tmp.Cursor = Cursors.Cross;
                    tmp.Click += new EventHandler(MyShoot);
                    tmp_buttons[i, j] = tmp;
                    panel_fields.Controls.Add(tmp);
                }
            }
            foreach (var v in enemyShips)
            {
                foreach (var v_2 in v.body)
                {
                    // заменить в последний момент на clrNearlySkyBlue
                    tmp_buttons[v_2.X, v_2.Y].BackColor = clrNearlySkyBlue;
                }
            }
            enemyButtons = tmp_buttons;
            return true;
        }

        public void MyShoot(object sender, EventArgs e)
        {
            Button pressedButton = sender as Button;
            // точка становится неактивной
            pressedButton.Enabled = false;
            timer1.Enabled = false;
            SelectLevelTimer();
            bool hit = false;
            //label_status.Text = $"Мой ход № {countMyShoots}";

            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    // если эта кнопка нажата и окрашена в корабль, красится в цвет поражения или убитого
                    // если эта кнопка нажата и не окрашена в корабль, помечается + (заменить clrNearlySkyBlue)
                    if (enemyButtons[i, j] == pressedButton && (pressedButton.BackColor == clrNearlySkyBlue
                        || pressedButton.BackColor == clrBlue))
                    {
                        foreach (var v in enemyShips)
                        {
                            foreach (var v_2 in v.body)
                            {
                                // если эта точка принадлежит кораблику то:
                                if (v_2.X == i && v_2.Y == j)
                                {
                                    hit = true;
                                    timer1.Enabled = true;
                                    SelectLevelTimer();
                                    // добавка битых точек объекту
                                    v.killedSize++;
                                    // покраска в красный если все точки битые
                                    if (v.size == v.killedSize)
                                    {
                                        v.isKilled = true;
                                        foreach (var v_3 in v.body)
                                        {
                                            // покраска всех точек данного корабля
                                            enemyButtons[v_3.X, v_3.Y].BackColor = Color.Red;                                            
                                        }
                                    }
                                    // покраска в желтый "несмертельного ранения"
                                    else
                                    {
                                        pressedButton.BackColor = Color.Yellow;
                                    }

                                }
                            }
                        }
                        progressBar1.Value++;
                    }
                    else
                    {
                        pressedButton.Text = "+";
                    }
                }
            }
            // если выстрел удачный то повтор выстрела
            if (hit)
            {
                label_status.Text = "Стреляйте еще ...";
                IsEnd();                
            }
            else
            {
                EnemyShoot();
            }
        }
        
        async public void EnemyShoot()
        {
            Random r = new Random();
            Point shoot;
            // переменная для настройки программы
            int i;
            bool hit = false;
            timer1.Enabled = true;

            // игроку заблокирована возможность выстрела
            //BlockEnemyButtons();

            // ключ для сохранения выстрела. если истина - годится ход
            bool key = true;
            while (key)
            {
                await Task.Delay(1000);
                // вариант                
                i = (StackForEnemyShoots.Count) - 1;
                if (i == -1)
                {
                    MessageBox.Show("проверить возможные ходы врага");
                }
                shoot = StackForEnemyShoots[r.Next(0, i)];
                
                if (key)
                {
                    // уменьшаем список выстрелов
                    StackForEnemyShoots.RemoveAt(StackForEnemyShoots.IndexOf(shoot));                                      
                    
                    if (myButtons[shoot.X, shoot.Y].BackColor == Color.Blue)
                    {
                        // цикл для поиска и добавки битой клетки                        
                        foreach (var v in myShips)
                        {
                            foreach (var v_2 in v.body)
                            {
                                if (v_2.X == shoot.X && v_2.Y == shoot.Y)
                                {
                                    // обозначение удачного выстрела
                                    hit = true;
                                    
                                    // добавка битых точек объекту
                                    v.killedSize++;
                                    // покраска в красный если все точки битые
                                    if (v.size == v.killedSize)
                                    {
                                        v.isKilled = true;
                                        foreach (var v_3 in v.body)
                                        {
                                            // покраска всех точек данного корабля
                                            myButtons[v_3.X, v_3.Y].BackColor = Color.Red;
                                        }

                                        // удаление клеток спецзоны из стека потенциальных выстрелов
                                        foreach (var v_3 in v.specZone)
                                        {                                            
                                            i = StackForEnemyShoots.IndexOf(v_3);
                                            if (i != -1)
                                            {
                                                StackForEnemyShoots.RemoveAt(i);
                                            }
                                        }                                        
                                    }
                                    // покраска в желтый "несмертельного ранения"
                                    else
                                    {
                                        myButtons[shoot.X, shoot.Y].BackColor = Color.Yellow;                                        
                                    }
                                }
                            }
                        }
                        //return true;
                        progressBar2.Value++;
                        //progressBar2.SendToBack;
                    }
                    else
                    {
                        myButtons[shoot.X, shoot.Y].Text = "+";
                        label_status.Text = $"Ход врага: {alph[shoot.Y].ToString()}-{shoot.X + 1}";
                        //return false;
                    }
                }
                if (hit)
                {
                    key = true;
                    hit = false;
                    IsEnd();
                }
                else
                {
                    key = false;
                }
            }
        }
             

        public void SelectLevelTimer()
        {
            switch (comboBox_level.SelectedIndex)
            {
                case 0:
                    timer_1 = timeLim;
                    break;
                case 1:
                    timer_1 = timeLim - 5;
                    break;
                case 2:
                    timer_1 = timeLim - 10;
                    break;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {            
            timer_1--;
            if (timer_1 < 10)
            {
                if(timer_1 < 0)
                {
                    label_time_limit.Text = "00";
                    timer1.Enabled = false;
                    MessageBox.Show("Поражение !");
                    Quit();
                }
                else
                label_time_limit.Text = "0" + timer_1.ToString();
            }
            else
            {
                label_time_limit.Text = timer_1.ToString();
            }
            
            
        }
        private void timer2_Tick(object sender, EventArgs e)
        {            
            if (sec < 10)
            {
                labe_total_time.Text = $"0{min}:0{sec}";                
            }
            if (sec <= 59 && sec >= 10)
            {
                labe_total_time.Text = $"0{min}:{sec}";
                
            }
            if(sec == 60)
            {
                sec = 0;
                min++;
                labe_total_time.Text = $"0{min}:0{sec}";
            }
            sec++;
        }

        private void IsEnd()
        {
            
            // если враг сделал выстрел и мой флот цел, то мне дается время на ответ
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Enabled = timer2.Enabled = false;
                label_status.Text = "Конец игры";                
                MessageBox.Show("Це перемога !!!");                
                Quit();
            }
            if (progressBar2.Value == progressBar2.Maximum)
            {
                timer1.Enabled = timer2.Enabled = false;
                label_status.Text = "Конец игры";                
                MessageBox.Show("Це зрада ...");                
                Quit();
            }            
        }

        public void Quit()
        {
            timer1.Enabled = timer2.Enabled = false;
            comboBox_level.Enabled = comboBox_orientation.Enabled = true;

            panel_fields.Controls.Clear();            
            Ini();
            
            /*
            DialogResult result = MessageBox.Show("Новый клиент?", "Время сессии истекло...",
                    MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {

            }
            */
        }

        public void SelectCondition()
        {
            horizont = comboBox_orientation.SelectedIndex;            
        }

        // проверка моей карты на условие расположения кораблей. Flag1 - критерий горизонтальности.
        // Flag2 - критерий вертикальности.
        public bool CheckMyShipConditions()
        {
            SelectCondition();
            
            bool flag1 = true;
            bool flag2 = true;
            foreach (var v in myShips)
            {
                if(v.size > 1 && v.horizontal == false)
                {
                    flag1 = false;
                    break;
                }
            }
            foreach (var v in myShips)
            {
                if (v.size > 1 && v.horizontal == true)
                {
                    flag2 = false;
                    break;
                }
            }

            if ((flag1 == true && horizont == 1) || (flag2 == true && horizont == 2))
            {
                return true;
            }
            if(horizont == 0)
            {
                return true;
            }
            else
            return false;
        }

        private void button_new_game_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void button_replay_Click(object sender, EventArgs e)
        {            
            int tmp = comboBox_orientation.SelectedIndex;
            Quit();
            myShips = myShipsForReset;
            comboBox_orientation.SelectedIndex = tmp;
            label_status.Text = "Нажмите \"Начать\"";

            foreach (var v in myShips)
            {
                foreach (var v_2 in v.body)
                {                    
                    myButtons[v_2.X, v_2.Y].BackColor = clrBlue;
                }
            }
            // кнопка создать невидимая
            button_create.Enabled = false;
            // ориентация невидимая
            comboBox_orientation.Enabled = false;
            // начать видимая
            button_start.Enabled = true;
            // уровень невидимая
            comboBox_level.Enabled = true;
        }
    }


}

