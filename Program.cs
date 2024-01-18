using System;

namespace EvoLvl2._1
{
    internal class Program
    {
        private static LinkedList linkedList = new LinkedList();

        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("***ÖĞRENCİ BİLGİ SİSTEMİNE HOŞGELDİNİZ");
                    Console.WriteLine("1-Öğrenci Bilgisi");
                    Console.WriteLine("2-Okul Bilgisi");
                    Console.WriteLine("3-Ders Bilgisi");
                    Console.WriteLine("4-Not Bilgisi");
                    Console.WriteLine("5-Verileri Göster");
                    Console.WriteLine("6-Çıkış");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            AddStudent();
                            break;

                        case "2":
                            AddSchool();
                            break;

                        case "3":
                            AddCourse();
                            break;

                        case "4":
                            AddGrade();
                            break;

                        case "5":
                            linkedList.PrintList();
                            break;

                        case "6":
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Geçersiz seçenek! Lütfen tekrar deneyin.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Hata oluştu: " + ex.Message);
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void AddStudent()
        {
            Console.WriteLine("Öğrenci Adı:");
            string studentName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(studentName))
            {
                Console.WriteLine("Hata: Öğrenci adı boş olamaz.");
                return;
            }

            Console.WriteLine("Yaşı:");
            if (!int.TryParse(Console.ReadLine(), out int studentAge) || studentAge <= 0)
            {
                Console.WriteLine("Hata: Geçerli bir yaş girin.");
                return;
            }

            Student newStudent = new Student(studentName, studentAge);
            linkedList.Add(newStudent);
        }

        private static void AddSchool()
        {
            Console.WriteLine("Okul Adı:");
            string schoolName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(schoolName))
            {
                Console.WriteLine("Hata: Okul adı boş olamaz.");
                return;
            }

            School newSchool = new School(schoolName);
            linkedList.Add(newSchool);
        }

        private static void AddCourse()
        {
            Console.WriteLine("Ders Adı:");
            string courseName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(courseName))
            {
                Console.WriteLine("Hata: Ders adı boş olamaz.");
                return;
            }

            Course newCourse = new Course(courseName);
            linkedList.Add(newCourse);
        }

        private static void AddGrade()
        {
            Console.WriteLine("Ders Adı:");
            string courseNameForGrade = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(courseNameForGrade))
            {
                Console.WriteLine("Hata: Ders adı boş olamaz.");
                return;
            }

            Console.WriteLine("Not:");
            if (!int.TryParse(Console.ReadLine(), out int grade) || grade < 0 || grade > 100)
            {
                Console.WriteLine("Hata: Geçerli bir not girin (0-100 arasında).");
                return;
            }

            Grade newGrade = new Grade(courseNameForGrade, grade);
            linkedList.Add(newGrade);
        }

        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Student(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public override string ToString()
            {
                return $"{Name}, {Age} yaşında";
            }
        }

        public class School
        {
            public string Name { get; set; }

            public School(string name)
            {
                Name = name;
            }

            public override string ToString()
            {
                return $"Okul Adı: {Name}";
            }
        }

        public class Course
        {
            public string Name { get; set; }

            public Course(string name)
            {
                Name = name;
            }

            public override string ToString()
            {
                return $"Ders Adı: {Name}";
            }
        }

        public class Grade
        {
            public string CourseName { get; set; }
            public int Score { get; set; }

            public Grade(string courseName, int score)
            {
                CourseName = courseName;
                Score = score;
            }

            public override string ToString()
            {
                return $"{CourseName}: {Score}";
            }
        }

        public class Node
        {
            public object Data { get; set; }
            public Node Next { get; set; }

            public Node(object data)
            {
                Data = data;
                Next = null;
            }
        }

        public class LinkedList
        {
            private Node head;

            public void Add(object data)
            {
                Node newNode = new Node(data);
                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    Node current = head;
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }
                    current.Next = newNode;
                }
            }

            public void Remove(object data)
            {
                if (head == null)
                {
                    return;
                }

                if (head.Data.Equals(data))
                {
                    head = head.Next;
                    return;
                }

                Node current = head;
                while (current.Next != null && !current.Next.Data.Equals(data))
                {
                    current = current.Next;
                }

                if (current.Next != null)
                {
                    current.Next = current.Next.Next;
                }
            }

            public void PrintList()
            {
                Node current = head;
                while (current != null)
                {
                    Console.WriteLine(current.Data);
                    current = current.Next;
                }
            }
        }
    }
}
