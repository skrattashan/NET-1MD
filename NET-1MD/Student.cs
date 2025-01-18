﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET_1MD
{
    //3 UZD 
    public class Student : Person // izmantoju https://www.w3schools.com/cs/cs_constructors.php
    {
        public string StudentIdNumber { get; set; }

        public Student(string name, string surname, GenderType gender, string StudentIDNumber) //šis konstruktors tika izstrādāts ar AI rīka palīdzību
        {
            Name = name;
            Surname = surname;
            Gender = gender;
            StudentIdNumber = StudentIDNumber;
        }
        public override string ToString() => $"{base.ToString()}, Student ID: {StudentIdNumber}\n";

    }
}
