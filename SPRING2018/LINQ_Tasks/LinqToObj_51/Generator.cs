﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToObj_51
{
    public class Student
    {
        public string Surname { get; set; }
        public string Initials { get; set; }
        public int[] Points { get; set; }
        public int School { get; set; }

        public Student(string source)
        {
            var array = source.Split(' ');
            Surname = array[0];
            Initials = array[1];
            Points = new int[3];
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i] = int.Parse(array[2 + i]);
            }
            School = int.Parse(array[5]);

        }

        public override string ToString()
        {
            return $"{Surname} {Initials}\t{School}\t\t{Points[0]}\t{Points[1]}\t{Points[2]}";
        }
    }

    public class Generator
    {

        public static string[] Surnames { get; }

        public static string[] Initials { get; }


        static Generator()
        {
            Surnames = new[]
            {
                "Attwood", "Becker", "Carter", "Faber", "Haig", "Hodges", "Lewin",
                "Oliver", "Ramacey", "Turner", "Wayne", "Harrison", "Youmans", "Russel", "Otis"
            };
            Initials = new[]
            {
                "A.A", "A.B", "A.C", "A.D", "F.C", "D.C", "R.D", "H.D", "R.O", "K.Z",
                "H.Y", "E.Q", "V.D", "P.A"
            };
        }

        public static void Generate(int size)
        {
            var random = new Random();
            var directory = @"C:\Users\petru\Desktop\Data";

            using (StreamWriter sw = new StreamWriter($"{directory}\\LinqToObj_51.txt"))
            {
                for (int j = 0; j < size; j++)
                {
                    sw.WriteLine($"{Surnames[random.Next(0, Surnames.Length)]} {Initials[random.Next(0, Initials.Length)]} {random.Next(0, 101)} {random.Next(0, 101)} {random.Next(0, 101)} {random.Next(10, 50)}");
                }
            }
        }

        public static List<Student> GetStudents(int size)
        {
            Generate(size);
            var directory = @"C:\Users\petru\Desktop\Data";

            var list = new List<string>();

            var students = new List<Student>();

            using (StreamReader sr = new StreamReader($"{directory}\\LinqToObj_51.txt"))
                while (!sr.EndOfStream)
                    list.Add(sr.ReadLine());

            foreach (var student in list)
            {
                students.Add(new Student(student));
            }

            return students;
        }
    }
}
