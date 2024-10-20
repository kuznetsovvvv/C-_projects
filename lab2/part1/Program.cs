using System;
using System.Drawing;

namespace CsharpProject{


    public class Program
    {
        public static void Main(string[] args)
        {

          

            Pupil student = new Pupil();

            ExcelentPupil student1= new ExcelentPupil();
            student1.Info();
            GoodPupil student2= new GoodPupil();    
            student2.Info();
            BadPupil student3= new BadPupil();
            student3.Info();

            ClassRoom classroom = new ClassRoom(student,student1,student2,student3);
            Console.WriteLine("");
            classroom.info();


        }


    }


    public class ClassRoom
    {
        private List<Pupil> pupils;

        public void info()
        {
            Console.WriteLine("В классе учится {0} человек", pupils.Count);
        }


        public ClassRoom(params Pupil[] pupils)
        {
            this.pupils = new List<Pupil>(pupils);
        }


    }


    public class Pupil
    {
       public void Info()
        {
            Study();
            Read();
            Write();
            Relax();
        }
        protected virtual void Study()
        {
            Console.WriteLine("Я могу учиться!");
        }

        protected virtual void Read()
        {
            Console.WriteLine("Я читаю книги!");
        }
        protected virtual void Write()
        {
            Console.WriteLine("Я умею писать на русском!");
        }
        protected virtual void Relax()
        {
            Console.WriteLine("Я люблю отдыхать в свободное время!");
        }
    }




    public class ExcelentPupil : Pupil {

        protected override void Study()
        {
            Console.WriteLine("Я учусь на оценки отлично!");
        }


        protected override void Read()
        {
            Console.WriteLine("Я читаю научные статьи!");
        }

        protected override void Relax()
        {
            Console.WriteLine("Я предпочитаю активный отдых!");
        }

        protected override void Write()
        {
            Console.WriteLine("Я люблю писать стихи!");
        }



    }

    public class GoodPupil : Pupil
    {
       

        protected override void Study()
        {
            Console.WriteLine("Я учусь на оценки хорошо!");
        }

        protected override void Read()
        {
            Console.WriteLine("Я читаю только учебные статьи!");
        }

        protected override void Relax()
        {
            Console.WriteLine("Я предпочитаю развлекаться в своодное время!");
        }

        protected override void Write()
        {
            Console.WriteLine("Я люблю быстро сделать дз !");
        }
    }


    public class BadPupil : Pupil
    {
       

        protected override void Study()
        {
            Console.WriteLine("Я учусь на оценки плохо!");
        }

        protected override void Read()
        {
            Console.WriteLine("Я не читаю статьи!");
        }

        protected override void Relax()
        {
            Console.WriteLine("Я предпочитаю пассивный отдых!");
        }

        protected override void Write()
        {
            Console.WriteLine("Я люблю списать дз!");
        }
    }
}