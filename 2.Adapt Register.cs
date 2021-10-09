using System;
using System.Collections.Generic;
enum Menu
{
    RegisterNewStudent = 1,
    RegisterNewTecher,
    GetListPersons,
    Exit
}
namespace Adapt_register_activity
{
    class Program
    {
        public static PersonList personList = new PersonList();
        static void Main(string[] args)
        {
            SummationInputMenuFirstScreen.PrintMenuScreen();
        }
        public static void InputNewStudent(int totalStudent)
        {
            for (int i = 0; i < totalStudent; i++)
            {
                Console.Clear();
                PrintHeaderInSystemRegister.PrintHeaderRegisterStudent();
                personList.AddNewPerson(SummationCreateNew.CreateNewStudent());
            }
            Console.Clear();
            SummationInputMenuFirstScreen.PrintMenuScreen();
        }
        public static void InputNewTeacherFromKeyboard(int totalTeacher)
        {
            for (int i = 0; i < totalTeacher; i++)
            {
                Console.Clear();
                PrintHeaderInSystemRegister.PrintHeaderRegisterTeacher();
                Program.personList.AddNewPerson(SummationCreateNew.CreateNewTeacher());
            }
            Console.Clear();
            SummationInputMenuFirstScreen.PrintMenuScreen();
        }
    }
    class PrintHeaderInSystemRegister
    {
        public static void PrintHeader()
        {
            Console.WriteLine("Welcome to register activity.");
            Console.WriteLine("=============================");
        }
        public static void PrintLisMenu()
        {
            Console.WriteLine("1.Register activity new student.");
            Console.WriteLine("2.Register activity new teacher.");
            Console.WriteLine("3.List Persons register activity.");
            Console.WriteLine("4.Exit.");
            Console.WriteLine("=============================");
        }
        public static void PrintHeaderRegisterStudent()
        {
            Console.WriteLine("Register new student.");
            Console.WriteLine("_____________________");
        }
        public static void PrintHeaderRegisterTeacher()
        {
            Console.WriteLine("Register new teacher.");
            Console.WriteLine("_____________________");
        }
    }
    class SummationInputMenuFirstScreen
    {
        public static void PrintMenuScreen()
        {
            Console.Clear();
            PrintHeaderInSystemRegister.PrintHeader();
            PrintHeaderInSystemRegister.PrintLisMenu();
            InputMenuFirstScreen.InputMenuFromKeyboard();
        }
    }
    class InputForRegister
    {
        public static string InputName()
        {
            Console.Write("Name: ");
            return Console.ReadLine();
        }
        public static int InputAge()
        {
            Console.Write("Age: ");
            return int.Parse(Console.ReadLine());
        }
        public static string InputGender()
        {
            Console.WriteLine("Male/Female ?");
                Console.Write("Gender: ");
                return Console.ReadLine();
        }
        public static string InputStudentID()
        {
            Console.Write("Student ID: ");
            return Console.ReadLine();
        }
        public static string InputAddress()
        {
            Console.Write("Address: ");
            return Console.ReadLine();
        }
        public static string InputCitizenID()
        {      
            Console.Write("CitizenID: ");
            return Console.ReadLine();
        }
        public static string InputEmployeeID()
        {
            Console.Write("Employee ID: ");
            return Console.ReadLine();
        }
        public static int TotalNewTeacher()
        {
            Console.Write("Input Total new Teacher: ");
            return int.Parse(Console.ReadLine());
        }
        public static int TotalNewStudents()
        {
            Console.Write("Input Total new Student: ");
            return int.Parse(Console.ReadLine());
        }
    }
    class SummationCreateNew
    {
        public static Student CreateNewStudent()
        {
            return new Student(InputForRegister.InputName(),
            InputForRegister.InputAddress(),
            InputForRegister.InputCitizenID(),
            InputForRegister.InputStudentID(),
            InputForRegister.InputAge(),
            InputForRegister.InputGender());
        }
        public static Teacher CreateNewTeacher()
        {
            return new Teacher(InputForRegister.InputName(),
            InputForRegister.InputAddress(),
            InputForRegister.InputCitizenID(),
            InputForRegister.InputEmployeeID(),
            InputForRegister.InputAge(),
            InputForRegister.InputGender());
        }
    }
    class InputMenuFirstScreen
    {
        public static void InputMenuFromKeyboard()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Please Select Menu: ");
            Menu InputMenu = (Menu)(int.Parse(Console.ReadLine()));
            PresentMenu(InputMenu);
        }
        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.RegisterNewStudent)
            {
                ShowFunctionMenu.ShowInputRegisterNewStudentScreen();
            }
            else if (menu == Menu.RegisterNewTecher)
            {
                ShowFunctionMenu.ShowInputRegisterNewTeacherScreen();
            }
            else if (menu == Menu.GetListPersons)
            {
                ShowFunctionMenu.ShowGetListPersonScreen();
            }
            else if (menu == Menu.Exit) { }
            else
            {
                ShowFunctionMenu.ShowMessageInputMenuIsInCorrect();
                InputMenuFromKeyboard();
            }
        }
    }
    class ShowFunctionMenu
    {
        public static void ShowInputRegisterNewStudentScreen()
        {
            Console.Clear();
            PrintHeaderInSystemRegister.PrintHeaderRegisterStudent();
            Program.InputNewStudent(InputForRegister.TotalNewStudents());
        }
        public static void ShowInputRegisterNewTeacherScreen()
        {
            Console.Clear();
            PrintHeaderInSystemRegister.PrintHeaderRegisterTeacher();
            Program.InputNewTeacherFromKeyboard(InputForRegister.TotalNewTeacher());
        }
        public static void ShowGetListPersonScreen()
        {
            Console.Clear();
            Program.personList.FetchPersonsList();
            InputExit.InputExitFromKeyboard();
        }
        public static void ShowMessageInputMenuIsInCorrect()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("===================================");
            Console.WriteLine("!!Menu Incorrect Please try agian!!");
            Console.WriteLine("===================================");
            PrintHeaderInSystemRegister.PrintLisMenu();
        }
    }
    class InputExit
    {
        public static void InputExitFromKeyboard()
        {
            string Text = "";
            while (Text != "exit")
            {
                Console.Write("Please input text 'Exit'.\nIf you want to exit ? : ");
                string text = Console.ReadLine();
                Text = text.ToLower();
            }
            Console.Clear();
            SummationInputMenuFirstScreen.PrintMenuScreen();
        }
    }
    class Person
    {
        protected string Name;
        protected string Address;
        protected string CitizenID;
        protected int Age;
        protected string Gender;
        public Person(string name, string address, string citizenID,int age,string gender)
        {
            this.Name = name;
            this.Address = address;
            this.CitizenID = citizenID;
            this.Age = age;
            this.Gender = gender;
        }
        public string GetName()
        {
            return this.Name;
        }
        public int GetAge()
        {
            return this.Age;
        }
        public string GetGender()
        {
            return this.Gender;
        }
    }
    class Student : Person
    {
        private string StudentID;

        public Student(string name, string address, string citizenID, string studentID, int age, string gender) : base(name, address, citizenID, age, gender)
        {
            this.StudentID = studentID;
        }
    }
    class Teacher : Person
    {
        private string TeacherID;

        public Teacher(string name, string address, string citizenID, string teacherID, int age, string gender) : base(name, address, citizenID, age, gender)
        {
            this.TeacherID = teacherID;
        }
    }
    class PersonList
    {
        private List<Person> personList;

        public PersonList()
        {
            this.personList = new List<Person>();
        }
        public void AddNewPerson(Person person)
        {
            this.personList.Add(person);
        }
        public void FetchPersonsList()
        {
            Console.WriteLine("List Person");
            Console.WriteLine("___________");
            foreach (Person person in this.personList)
            {
                if (person is Student)
                {
                    Console.WriteLine("Name : {0} \nAge : {1} \nGender : {2} \nType : Student \n",person.GetName(),person.GetAge(), person.GetGender());
                }
                else if (person is Teacher)
                {
                    Console.WriteLine("Name : {0} \nAge : {1} \nGender : {2} \nType : Teacher \n", person.GetName(),person.GetAge(), person.GetGender());
                }
            }
        }
    }
}
