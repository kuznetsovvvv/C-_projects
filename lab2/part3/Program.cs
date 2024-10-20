using System;

namespace CsharpProject
{
    public class Program
    {
        public static void Main(string[] args)
        {

            string access1 = "pro";
            string access2 = "exp";
            Console.Write("Введите ваш уровень доступа(simple,pro or exp):");
            string result = Console.ReadLine();
            DocumentWorker worker = new();   

            if (result == access1)
            {
                worker = new ProDocumentWorker();
                
            }
            else if (result == access2)
            {
               worker = new ExpertDocumentWorker();
                
            }
            else
            {
                worker = new DocumentWorker();
               
            }

            worker.OpenDocument();
            worker.EditDocument();
            worker.SaveDocument();







        }
    }



    public class DocumentWorker
    {


        public DocumentWorker() { }

        public virtual void OpenDocument()
        {
            Console.WriteLine("Документ открыт");
        }
        public virtual void EditDocument()
        {
            Console.WriteLine("Редактирование документа доступно в версии pro");
        }
        public virtual void SaveDocument()
        {
            Console.WriteLine("Сохранение документа доступно в версии pro");
        }



    }


    public class ProDocumentWorker : DocumentWorker {

       

        public override void EditDocument()
        {
            Console.WriteLine("Документ отредактирован");
        }


        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в старом формате, сохранение в остальных форматах доступно в версии Expert");
        }



    }



    public class ExpertDocumentWorker : ProDocumentWorker
    {
        public override void SaveDocument()
        {
            Console.WriteLine("Документ сохранен в новом формате");
        }
        


    }



}
