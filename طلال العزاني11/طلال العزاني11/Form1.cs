using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace المحاضرة_الحاديه_عشر
{
    public partial class Form1 : Form
    {
        Button b;
        Label l;
        TextBox t;
        ListBox lst;
        //............

        Button clear;
        //............
        Button b2;
        //............
        Panel p;

        //OpenFileDialog op =new OpenFileDialog()استخدام غير سليم 

        Timer timer;

        public Form1()
        {
            //InitializeComponent();لانحتاجها حيث انها تقوم بتعريف وتهيئة الادوات واضافتها مرئيا

         // ثاني خطوة تهيئة الاحداث
            b=new Button();
            l=new Label();
            t=new TextBox();
            lst=new ListBox();

            clear=new Button();
            b2=new Button();
            p=new Panel();
            timer=new Timer();
            //ثالثا ضب الخصائص والاحداث ان وجدت
            this.Width = 250;
            this.Height = 280;
            b.Text = "Add";
            b.Click += bclick;
            l.Text = "insert";
            //................
            clear.Text = "Clear";
            p.Width = 200;
            p.Height= 200;
            p.BackColor = Color.Gray;
            //..............................
            b2.Text = "openFile";
            b2.Click += openfile;
            //.......ربط اكثر من حدث بداله واحدة.......
            b.Click += all;
            clear.Click += all;
            l.Click += all;
            //Timer==
            timer.Tick += tick;
            //timer.Tick=all;//ربط حدث التايمر تك ولاحظ الفرق
            timer.Interval= 1000;
            timer.Enabled = true;
            //-------------------
            //رابعا تصميم الادوات من حيث المواقع والاحجام
            disgin();
            //اخيرا اضافتها مرئيا
            visual();


        }
        public void disgin()
        {
            b.Top = 30;b.Left = 12;lst.Top = 60;
            t.Top = 10;l.Left = 110;l.Top = 10;
            t.Left = lst.Left = 10;
            t.Width = 80;t.Height = 30;
            //----------------------------
            clear.Top = 170;
            //--------
            p.Left = 10;
            p.Top = 10;
            //-----------
            b2.Top = 210;
            //يفضل الاعتماد على مواقع واحجام الادوات الفعليه التي على الفورم
            //لاعطاء مواقع واحجام للادوات الاخرى

        }
        public void visual()
        {
            //في حال كانت الادوات تابعة للفورم مباشرة 
            //this.Controls.Add(b);
            //  this.Controls.Add(l);
            // this.Controls.Add(t);
            // this.Controls.Add(clear);
            // this.Controls.Add(lst);
            //----------------------
            //في حال كانت الادوات تابعة للحاوية بانل
            p.Controls.Add(b);
            p.Controls.Add(clear);
            p.Controls.Add(l);
            p.Controls.Add(t);
            p.Controls.Add(lst);

            //2
            //  Control[] mytool = { b, l, t, lst, clear }; 
            //  p.Controls.AddRange(mytool);
            //3
           // p.Controls.AddRange(new Control[] { b, l, t, lst, clear });
           //اخيرا نظيف الادوات للفورم
            this.Controls.Add(p);
            this.Controls.Add(b2);
        }
        public void bclick(object s, EventArgs e)
        {
            lst.Items.Add(t.Text);
        }
        void Clean(object s,EventArgs e)
        {
            //كيفية التعامل مع الت من نوع محدد 
            List<string> student = new List<string>();
            student.Add("Ali");
            student.Add("ahmed");
            student.Add("retal");
            student.Add("kalid");
            for(int i=0;i<student.Count;i++) 
            {
                //student[i];
            }
            foreach(string item in student)
            {
                //item;
            }
            //student.RemoveAt(0);
            //student.RemoveAt("Ali");
            student.Clear();
            List<int>id=new List<int>();
            id.Add(111);
            id.Add(222);
            id.Add(333);
            id.Add(444);
            id.RemoveAt(1);
            id.RemoveAt(111);
            id.Clear();

            //--------------------

          //  Controls.Clear();//حذف جميع الادوات من الفورم ولاكن تبقى في الذاكرة ويمكن التعامل معها بدون تهيئتها مجداا
          //object x=new Button();يعتبر الكلاس الاب يمكنه التاشير على اي نوع

            foreach(Control obj in Controls)
            {
                obj.Dispose();
            }

            foreach (Control obj in Controls)
            {
                if(obj is ListBox)
                {
                    ((ListBox)obj).Items.Clear();


                }
                if(obj is Button) {


                    obj.Left = 100;

                }
                
            }
            //الوصول لجميع الادوات 2
            foreach (Control obj in Controls)
            {
               if(obj is ListBox) 
                {
                    ((ListBox)obj).Items.Clear();
                

                }
                if (obj is Button)
                {


                    obj.Left = 100;

                }
            }
            foreach(Button obj in Controls.OfType<Button>())
            {
                obj.BackColor= Color.Red;
                obj.Left += 100;
            }
            //المرور فقط على جميع صناديق الادخال التي على الفورم
            foreach(TextBox obj in Controls.OfType<TextBox>())
            {
                obj.Clear();
                obj.Left += 100;

            }
            foreach(Control obj in this.Controls)
            {
                if(obj is Panel||obj is GroupBox)
                {
                    foreach(Control objchiled in obj.Controls)
                    {
                        objchiled.Left += 100;
                        //objchiled.Dispose();

                    }
                }
                if(obj is Button)
                {
                    obj.Left += 100;
                }
            }
        }
        void openfile(object ddd,EventArgs dde)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.ShowDialog();
            op.Dispose();
        }
        void all(object sender, EventArgs e)
        {
            //Button myb = ((Button)sender);
            Control myb=((Control)sender);
            if(sender is Label)
            {
                MessageBox.Show("you click on lable");
            }
            if(sender is Button)
            {
                if(myb.Text=="Add")
                {
                    lst.Items.Add(t.Text);
                }
                else if(myb==b2)
                {
                    OpenFileDialog op=new OpenFileDialog();
                    op.ShowDialog();
                    op.Dispose();
                }
                else if(myb==clear)
                {
                    lst.Items.Clear();
                }
            }
        }
        void all2(object sender, EventArgs e)
        {
            //يمكن اتسخدام مبدا التعاون او التضعيف بين الدوال هاكذا
            //all(null, null);
            //all(sender, e);

        }
        int c = 0;
        void tick(object ddd, EventArgs dde)
        {
            l.Text=1.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
