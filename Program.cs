using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Write("------Method one------\n");
            var list1 = new List<Student>();
            Student s1 = new Student(1, "Hishigbayr");
            Student s2 = new Student(2, "Natsagtseren");
            list1.Add(s1);
            list1.Add(s2);
            foreach (Student student in list1)
            {
                student.Display();
                System.Console.Write("\n");
            }
            System.Console.Write("\n------Method two------\n");
            var map1 = new Dictionary<string, string>();
            map1.Add("B150910036", "Hishigbayr");
            map1.Add("B150910012", "Amarsanaa");
            map1.Add("B150910011", "Batbayr");
            foreach (var info1 in map1)
            {
                string key = info1.Key;
                string value = info1.Value;
                Console.WriteLine("Code: "+key + "\nName: " + value);
            }
            string result1 = map1["B150910036"];
            System.Console.WriteLine(result1);
            string mapValue;
            if (map1.TryGetValue("B150910012", out mapValue))
            {
                Console.WriteLine(mapValue);
            }
            if (map1.TryGetValue("B150910011", out mapValue))
            {
                Console.WriteLine(mapValue);
            }
            System.Console.Write("\n------Method three------\n");
            Queue<int> number1 = new Queue<int>();
            number1.Enqueue(23);
            number1.Enqueue(2);
            number1.Enqueue(3);
            number1.Enqueue(7);
            number1.Enqueue(16);
            var arr = number1.ToArray();
            for (int i = 0; i < arr.Length; i++)
            {
                System.Console.WriteLine(arr[i]);
            }
            System.Console.WriteLine("Delete element:"+number1.Dequeue());
            var arr1 = number1.ToArray();
            for (int i = 0; i < arr1.Length; i++)
            {
                System.Console.WriteLine(arr1[i]);
            }
        }
    }
    public class Student
    {
        public int StudentID;
        public string StudentName;
        public Student(int id,String name)
        {
            StudentID = id;
            StudentName = name;
        }
        public void Display()
        {
            System.Console.Write("ID="+StudentID+"\nName="+StudentName);
        }
    }
}
