using System;
using System.Collections.Generic;

namespace TelGuide
{
    class Program
    {

        static void Main(string[] args)
        {
            string operation = null;
            while (operation != "0")
            {
                Console.Clear();
                Console.WriteLine("Выберите операцию со справочником:\n1-Добавить запись;\n2-Посмотреть запись;\n3-Удалить запись;\n4-Редактировать запись;\n5-Посмотреть все записи;\n0-Выйти");
                operation = Console.ReadLine();
                switch (operation)
                {
                    case "1":
                        Person.AddRecord();
                        break;
                    case "2":
                        Person.SeeRecord();
                        break;
                    case "3":
                        Person.DeleteRecord();
                        break;
                    case "4":
                        Person.EditRecord();
                        break;
                    case "5":
                        Person.ShowAllRecord();
                        break;
                }
            }
        }
    }
    class Person
    {
        static public List<Person> guide = new List<Person>();
        string family;
        string name;
        string patronymic;
        string country;
        int telephone;
        string dateBirth;
        string organization;
        string employee;
        string other;
        public static void AddRecord()
        {
            Person person = new Person();
            do
            {
                Console.WriteLine("Введите фамилию:");
                person.family = Console.ReadLine();
            }
            while (person.family == "");
            do
            {
                Console.WriteLine("Введите имя:");
                person.name = Console.ReadLine();
            }
            while (person.name == "");
            Console.WriteLine("Введите отчество:");
            person.patronymic = Console.ReadLine();
            do
            {
                Console.WriteLine("Введите номер телефона:");
                try
                {
                    person.telephone = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Заданный номер телефона не соответствует формату");
                }

            }
            while (person.telephone == 0);
            do
            {
                Console.WriteLine("Введите страну:");
                person.country = Console.ReadLine();
            }
            while (person.country == "");
            Console.WriteLine("Введите дату рождения:");
            person.dateBirth = Console.ReadLine();
            Console.WriteLine("Введите организацию:");
            person.organization = Console.ReadLine();
            Console.WriteLine("Введите должность:");
            person.employee = Console.ReadLine();
            Console.WriteLine("Введите прочие заметки:");
            person.other = Console.ReadLine();
            guide.Add(person);
            Console.WriteLine("Запись в справочник добавлена.Нажмите enter");
            Console.ReadLine();
        }

        public static void SeeRecord()
        {
            string findFamily;
            Console.WriteLine("Введите фамилию для просмотра записи:");
            findFamily = Console.ReadLine();
            Person seeRecord = Person.FindRecord(findFamily);
            if (seeRecord == null)
            {
                Console.WriteLine("Надпись не найдена.\nДля продолжения нажмите enter.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Данные записи:");
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7} {8}", seeRecord.family, seeRecord.name, seeRecord.patronymic, seeRecord.telephone, seeRecord.country, seeRecord.dateBirth, seeRecord.organization, seeRecord.employee, seeRecord.other);
                Console.WriteLine("Для продолжения нажмите enter");
                Console.ReadLine();
            }
        }
        public static void DeleteRecord()
        {
            string findFamily;
            Console.WriteLine("Введите фамилию для удаления записи:");
            findFamily = Console.ReadLine();
            Person deleteRecord = Person.FindRecord(findFamily);
            if (deleteRecord == null)
            {
                Console.WriteLine("Надпись не найдена");
                Console.WriteLine("Для продолжения нажмите enter");
                Console.ReadLine();
            }
            else
            {
                guide.Remove(deleteRecord);
                Console.WriteLine("Запись удалена.\nДля продолжения нажмите enter");
                Console.ReadLine();
            }
        }
        public static void EditRecord()
        {
            string findFamily, newInfo;
            Console.WriteLine("Введите фамилию для редактирования записи:");
            findFamily = Console.ReadLine();
            Person editRecord = Person.FindRecord(findFamily);
            if (editRecord == null)
            {
                Console.WriteLine("Надпись не найдена");
                Console.WriteLine("Для продолжения нажмите enter");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Задайте новые данные(чтобы оставить предыдущее значение поля, просто нажмите enter):");
                Console.WriteLine("Фамилия:");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                    editRecord.family = newInfo;
                }
                Console.WriteLine("Имя");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                    editRecord.name = newInfo;
                }
                Console.WriteLine("Отчество:");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                    editRecord.patronymic = newInfo;
                }
                Console.WriteLine("Номер телефона:");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                    try
                    {
                        editRecord.telephone = int.Parse(newInfo);
                    }
                    catch
                    {
                        Console.WriteLine("Заданный номер телефона не соответствует формату");
                    }
                }
                Console.WriteLine("Страна:");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                    editRecord.country = newInfo;
                }
                Console.WriteLine("Дата рождения:");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                    editRecord.dateBirth = newInfo;
                }
                Console.WriteLine("Организация:");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                    editRecord.organization = newInfo;
                }
                Console.WriteLine("Должность:");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                    editRecord.employee = newInfo;
                }
                Console.WriteLine("Прочие заметки:");
                newInfo = Console.ReadLine();
                if (newInfo != "")
                {
                    editRecord.other = newInfo;
                }
                Console.WriteLine("Запись изменена.\nДля продолжения нажмите enter");
                Console.ReadLine();
            }
        }
        public static void ShowAllRecord()
        {
            Console.WriteLine("Справочник:");
            foreach (Person p in guide)
            {

                Console.WriteLine("{0} {1} {2}", p.family, p.name, p.telephone);

            }
            Console.WriteLine("Для продолжения нажмите enter");
            Console.ReadLine();
        }
        public static Person FindRecord(string family)
        {
            Person findP = null;
            foreach (Person p in guide)
            {
                if (p.family == family)
                {
                    findP = p;
                    break;
                }
            }
            return findP;
        }
    }
}