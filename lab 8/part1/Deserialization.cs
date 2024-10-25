using System.Xml.Serialization;
using System;
using ClassLibrary2;

namespace CsharpProject2
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //�������� ���� lion.xml � \bin\Debug\net8.0 ����� ���� ������ ������ ��������������
            Console.WriteLine("Deserialization");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Lion));
            using (FileStream fs = new FileStream("lion.xml", FileMode.OpenOrCreate))
            {
                Lion? lion = xmlSerializer.Deserialize(fs) as Lion;
                Console.WriteLine($"Country: {lion?.Country}\nHide from other animals or not: {lion?.HideFromOtherAnimals}\nName: {lion?.Name}\nType of animal: {lion?.WhatAnimal}");
            }
            Console.WriteLine("Deserialization succesful");
        }






    }








}